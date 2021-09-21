using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Worker.Gtfs.Feeder.Library.Models;

namespace Worker.Gtfs.Feeder.Persistence.Repository
{
    public interface IFeederRepository
    {
        Task UpsertManyAsync(IEnumerable<GtfsModel> entities, CancellationToken cancellationToken);
    }
}