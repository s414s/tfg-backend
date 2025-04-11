using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class RouteEntityConfigurator : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.HasKey(t => t.Id);

        builder
            .HasOne(r => r.Origin)
            .WithMany(c => c.RouteOrigins)
            .HasForeignKey(s => s.OriginId)
            ;

        builder
            .HasOne(r => r.Destination)
            .WithMany(c => c.RouteDestinations)
            .HasForeignKey(s => s.DestinationId)
            ;

        // Seeder
        builder.HasData([
            new Route
            {
                Id = 1,
                Distance = 320.0,    // Zaragoza (1) -> Madrid (3)
                AvgSpeed = 100.0,
                OriginId = 1,
                DestinationId = 3
            },
            new Route
            {
                Id = 2,
                Distance = 530.0,    // Madrid (3) -> Sevilla (5)
                AvgSpeed = 95.0,
                OriginId = 3,
                DestinationId = 5
            },
            new Route
            {
                Id = 3,
                Distance = 400.0,    // Sevilla (5) -> Murcia (7)
                AvgSpeed = 90.0,
                OriginId = 5,
                DestinationId = 7
            },
            new Route
            {
                Id = 4,
                Distance = 240.0,    // Murcia (7) -> Valencia (4)
                AvgSpeed = 100.0,
                OriginId = 7,
                DestinationId = 4
            },
            new Route
            {
                Id = 5,
                Distance = 350.0,    // Valencia (4) -> Barcelona (2)
                AvgSpeed = 100.0,
                OriginId = 4,
                DestinationId = 2
            },
            new Route
            {
                Id = 6,
                Distance = 150.0,    // Barcelona (2) -> Lerida (8)
                AvgSpeed = 100.0,
                OriginId = 2,
                DestinationId = 8
            },
            new Route
            {
                Id = 7,
                Distance = 150.0,    // Lerida (8) -> Zaragoza (1)
                AvgSpeed = 100.0,
                OriginId = 8,
                DestinationId = 1
            },
            new Route
            {
                Id = 8,
                Distance = 200.0,    // Zaragoza (1) -> Teruel (12)
                AvgSpeed = 90.0,
                OriginId = 1,
                DestinationId = 12
            },
            new Route
            {
                Id = 9,
                Distance = 250.0,    // Teruel (12) -> Valencia (4)
                AvgSpeed = 90.0,
                OriginId = 12,
                DestinationId = 4
            },
            new Route
            {
                Id = 10,
                Distance = 150.0,    // Murcia (7) -> Albacete (9)
                AvgSpeed = 90.0,
                OriginId = 7,
                DestinationId = 9
            },
            new Route
            {
                Id = 11,
                Distance = 170.0,    // Albacete (9) -> Valencia (4)
                AvgSpeed = 90.0,
                OriginId = 9,
                DestinationId = 4
            },
            new Route
            {
                Id = 12,
                Distance = 400.0,    // Albacete (9) -> Madrid (3)
                AvgSpeed = 100.0,
                OriginId = 9,
                DestinationId = 3
            },
            new Route
            {
                Id = 13,
                Distance = 240.0,    // Duplicate: Murcia (7) -> Valencia (4) (if intended)
                AvgSpeed = 100.0,
                OriginId = 7,
                DestinationId = 4
            },
            new Route
            {
                Id = 14,
                Distance = 130.0,    // Albacete (9) -> Ciudad Real (10)
                AvgSpeed = 90.0,
                OriginId = 9,
                DestinationId = 10
            },
            new Route
            {
                Id = 15,
                Distance = 180.0,    // Cordoba (6) -> Ciudad Real (10)
                AvgSpeed = 90.0,
                OriginId = 6,
                DestinationId = 10
            },
            new Route
            {
                Id = 16,
                Distance = 140.0,    // Cordoba (6) -> Sevilla (5)
                AvgSpeed = 90.0,
                OriginId = 6,
                DestinationId = 5
            },
            new Route
            {
                Id = 17,
                Distance = 200.0,    // Cordoba (6) -> Granada (11)
                AvgSpeed = 90.0,
                OriginId = 6,
                DestinationId = 11
            },
            new Route
            {
                Id = 18,
                Distance = 200.0,    // Ciudad Real (10) -> Madrid (3)
                AvgSpeed = 90.0,
                OriginId = 10,
                DestinationId = 3
            }
        ]);
    }
}

