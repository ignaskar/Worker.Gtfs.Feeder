using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Worker.Gtfs.Feeder.Library.Models;
using Worker.Gtfs.Feeder.Persistence.Context;

namespace Worker.Gtfs.Feeder.Persistence.Repository
{
    public class FeederRepository: IFeederRepository
    {
        private readonly ILogger<FeederRepository> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public FeederRepository(ILogger<FeederRepository> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }
        
        public async Task UpsertManyAsync(IEnumerable<GtfsModel> entities, CancellationToken cancellationToken)
        {
            if (entities is null)
            {
                _logger.LogError($"{nameof(UpsertManyAsync)} entity list cannot be null");
                throw new ArgumentNullException(nameof(entities), "entity list cannot be null");
            }
            
            try
            {
                var scope = _scopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                await dbContext.Set<GtfsModel>().UpsertRange(entities).RunAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Repository Failure: {ex.Message}", ex);
                throw new Exception($"{nameof(entities)} could not be updated");
            }
        }
    }
}