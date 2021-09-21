using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Worker.Gtfs.Feeder.Persistence.Repository;
using Worker.Gtfs.Feeder.Service.Api;

namespace Worker.Gtfs.Feeder.Service.Services
{
    public class FeederService : IFeederService
    {
        private readonly ILogger<FeederService> _logger;
        private readonly IApiHelper _apiHelper;
        private readonly IFeederRepository _feederRepository;

        public FeederService(ILogger<FeederService> logger, IApiHelper apiHelper, IFeederRepository feederRepository)
        {
            _logger = logger;
            _apiHelper = apiHelper;
            _feederRepository = feederRepository;
        }
        
        public async Task Feed(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Feeding GTFS Data from API to DB");
                var data = await _apiHelper.GetGtfsDataAsync(cancellationToken);
                await _feederRepository.UpsertManyAsync(data, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Feed Failed: {ex.Message}", ex);
                throw;
            }
        }
    }
}