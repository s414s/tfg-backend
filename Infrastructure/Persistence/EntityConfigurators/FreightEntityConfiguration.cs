using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class FreightEntityConfiguration : IEntityTypeConfiguration<Freight>
{
    public void Configure(EntityTypeBuilder<Freight> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasOne(c => c.Driver)
            .WithMany(x => x.Freights)
            .HasForeignKey(x => x.DriverId);

        builder
            .HasOne(c => c.Truck)
            .WithMany(x => x.Freights)
            .HasForeignKey(x => x.TruckId);

        builder
            .HasMany(c => c.FreightRoutes)
            .WithOne(x => x.Freight)
            .HasForeignKey(x => x.FreightId);
    }
}
