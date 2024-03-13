using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityFrameworkCore.Configuration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles").HasKey(v => v.Id);

            builder.HasOne(v => v.Model);
            builder.HasOne(v => v.VehicleType);
            builder.HasOne(v => v.Brand);
        }
    }
}
