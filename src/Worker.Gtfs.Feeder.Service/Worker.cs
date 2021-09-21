using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Worker.Gtfs.Feeder.Service.Services;

namespace Worker.Gtfs.Feeder.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly IFeederService _feederService;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, IFeederService feederService)
        {
            _logger = logger;
            _configuration = configuration;
            _feederService = feederService;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var refreshTime = _configuration.GetValue<int>("RefreshEveryXSeconds");
            
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Starting to feed GTFS data...");
                    await _feederService.Feed(cancellationToken);
                    _logger.LogInformation($"Feed successful! Next feed in: {refreshTime} seconds");
                    await Task.Delay(TimeSpan.FromSeconds(refreshTime), cancellationToken);
                }
                catch
                {
                    _logger.LogError($"Retrying in {refreshTime} seconds");
                    await Task.Delay(TimeSpan.FromSeconds(refreshTime), cancellationToken);
                }
            }
        }
    }
}