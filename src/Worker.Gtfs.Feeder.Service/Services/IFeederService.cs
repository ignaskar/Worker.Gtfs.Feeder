using System.Threading;
using System.Threading.Tasks;

namespace Worker.Gtfs.Feeder.Service.Services
{
    public interface IFeederService
    {
        Task Feed(CancellationToken cancellationToken);
    }
}