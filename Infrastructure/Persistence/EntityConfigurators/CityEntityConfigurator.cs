using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class CityEntityConfigurator : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.Id);

        builder.OwnsOne(c => c.Location);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(50);

        // Seeder
        builder.HasData([
            new City
            {
                Id = 1,
                Name = "Zaragoza",
                Location = GeographicCoordinates.Create(41.6488, -0.8891)
            },
            new City
            {
                Id = 2,
                Name = "Barcelona",
                Location = GeographicCoordinates.Create(41.3851, 2.1734)
            },
            new City
            {
                Id = 3,
                Name = "Madrid",
                Location = GeographicCoordinates.Create(40.4168, -3.7038)
            },
            new City
            {
                Id = 4,
                Name = "Valencia",
                Location = GeographicCoordinates.Create(39.4699, -0.3763)
            },
            new City
            {
                Id = 5,
                Name = "Sevilla",
                Location = GeographicCoordinates.Create(37.3891, -5.9845)
            },
            new City
            {
                Id = 6,
                Name = "Cordoba",
                Location = GeographicCoordinates.Create(37.8882, -4.7794)
            },
            new City
            {
                Id = 7,
                Name = "Murcia",
                Location = GeographicCoordinates.Create(37.9922, -1.1307)
            }
            ]);
    }
}
