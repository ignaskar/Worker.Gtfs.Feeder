using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Worker.Gtfs.Feeder.Persistence.Context;
using Worker.Gtfs.Feeder.Persistence.Repository;

namespace Worker.Gtfs.Feeder.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IFeederRepository, FeederRepository>();
            services.AddDbContext<DatabaseContext>(opt =>
            {
                opt.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
            });

            return services;
        }
    }
}