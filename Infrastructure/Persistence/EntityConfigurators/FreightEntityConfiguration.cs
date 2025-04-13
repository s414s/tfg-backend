using Domain.Entities;
using Domain.Enums;
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

        builder.HasData(
            new Freight
            {
                Id = 1,
                TruckId = 1,
                DriverId = 1,
                StartCityId = 3,
                DueStart = new DateTime(2025, 05, 01, 08, 00, 00, DateTimeKind.Utc),
                Status = FreightStatus.Active,
                RouteId = 1,
                Created = DateTime.UtcNow.AddHours(-2),
            },
            new Freight
            {
                Id = 2,
                TruckId = 2,
                DriverId = 2,
                StartCityId = 2,
                DueStart = new DateTime(2025, 05, 02, 09, 30, 00, DateTimeKind.Utc),
                Status = FreightStatus.Active,
                RouteId = 5,
                Created = DateTime.UtcNow.AddHours(-2),
            },
            new Freight
            {
                Id = 3,
                TruckId = 3,
                DriverId = 3,
                StartCityId = 5,
                DueStart = new DateTime(2025, 05, 03, 07, 45, 00, DateTimeKind.Utc),
                Status = FreightStatus.Completed,
                RouteId = 2,
                Created = DateTime.UtcNow.AddHours(-2),
            },
            new Freight
            {
                Id = 4,
                TruckId = 1,
                DriverId = 4,
                StartCityId = 8,
                DueStart = new DateTime(2025, 05, 04, 10, 00, 00, DateTimeKind.Utc),
                Status = FreightStatus.Active,
                RouteId = 6,
                Created = DateTime.UtcNow.AddHours(-2),
            }
        );
    }
}
