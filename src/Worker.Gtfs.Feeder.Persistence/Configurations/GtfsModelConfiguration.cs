using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Worker.Gtfs.Feeder.Library.Models;

namespace Worker.Gtfs.Feeder.Persistence.Configurations
{
    public class GtfsModelConfiguration : IEntityTypeConfiguration<GtfsModel>
    {
        public void Configure(EntityTypeBuilder<GtfsModel> builder)
        {
            builder.HasKey(e => e.CarNumber);
        }
    }
}