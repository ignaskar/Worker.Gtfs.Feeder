using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Worker.Gtfs.Feeder.Persistence.Extensions;
using Worker.Gtfs.Feeder.Service.Api;
using Worker.Gtfs.Feeder.Service.Services;

namespace Worker.Gtfs.Feeder.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting GTFS Feeder service");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Error($"Failed to start Feeder service: {ex.Message}", ex);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
        
        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(builder =>
                {
                    builder
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddCommandLine(args);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddPersistence(context.Configuration);
                    services.AddSingleton<IFeederService, FeederService>();
                    services.AddHttpClient<IApiHelper, ApiHelper>(client =>
                    {
                        client.BaseAddress = new Uri(context.Configuration.GetValue<string>("BaseAddress"));
                    });
                    services.AddHostedService<Worker>();
                })
                .UseSerilog();
    }
}