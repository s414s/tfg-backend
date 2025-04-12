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
            .HasOne(c => c.Route)
            .WithMany()
            .HasForeignKey(x => x.RouteId);

        builder
            .HasOne(c => c.StartCity)
            .WithMany()
            .HasForeignKey(x => x.StartCityId);
    }
}
