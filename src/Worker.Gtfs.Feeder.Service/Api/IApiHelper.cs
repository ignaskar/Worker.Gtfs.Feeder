using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Worker.Gtfs.Feeder.Library.Models;

namespace Worker.Gtfs.Feeder.Service.Api
{
    public interface IApiHelper
    {
        Task<List<GtfsModel>> GetGtfsDataAsync(CancellationToken cancellationToken);
    }
}