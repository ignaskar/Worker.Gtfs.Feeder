using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Worker.Gtfs.Feeder.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var refreshTime = _configuration.GetValue<int>("RefreshEveryXSeconds");
            
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Starting to feed GTFS data...");
                await Task.Delay(1500, stoppingToken);
                _logger.LogInformation($"Feed successful! Next feed in: {refreshTime} seconds");
                await Task.Delay(TimeSpan.FromSeconds(refreshTime), stoppingToken);
            }
        }
    }
}