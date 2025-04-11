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

        //builder.ComplexProperty(x => x.Location);

        builder.OwnsOne(c => c.Location, loc =>
        {
            // You can still configure properties on the owned type here.
            loc.Property(l => l.Lat);
            loc.Property(l => l.Lon);

            // Seed data for the owned type.
            loc.HasData(
                new { CityId = 1L, Latitude = 41.6488, Longitude = -0.8891 },
                new { CityId = 2L, Latitude = 41.3851, Longitude = 2.1734 },
                new { CityId = 3L, Latitude = 40.4168, Longitude = -3.7038 },
                new { CityId = 4L, Latitude = 39.4699, Longitude = -0.3763 },
                new { CityId = 5L, Latitude = 37.3891, Longitude = -5.9845 },
                new { CityId = 6L, Latitude = 37.8882, Longitude = -4.7794 },
                new { CityId = 7L, Latitude = 37.9922, Longitude = -1.1307 },
                new { CityId = 8L, Latitude = 41.6176, Longitude = 0.6200 },
                new { CityId = 9L, Latitude = 38.9943, Longitude = -1.8561 },
                new { CityId = 10L, Latitude = 38.9861, Longitude = -3.9269 },
                new { CityId = 11L, Latitude = 37.18817, Longitude = -3.60667 },
                new { CityId = 12L, Latitude = 40.3453, Longitude = -1.1068 }
            );
        });

        //builder.Property(c => c.Location) .HasConversion(x => (x.Lat, x.Lon), value => GeographicCoordinates.Create(value.Lat, value.Lon));

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(50);

        // Seeder
        // Seed City entities without setting the Location property
        builder.HasData(
            new City { Id = 1, Name = "Zaragoza", Code = "ZAR" },
            new City { Id = 2, Name = "Barcelona", Code = "BCN" },
            new City { Id = 3, Name = "Madrid", Code = "MAD" },
            new City { Id = 4, Name = "Valencia", Code = "VAL" },
            new City { Id = 5, Name = "Sevilla", Code = "SEV" },
            new City { Id = 6, Name = "Cordoba", Code = "COR" },
            new City { Id = 7, Name = "Murcia", Code = "MUR" },
            new City { Id = 8, Name = "Lerida", Code = "LER" },
            new City { Id = 9, Name = "Albacete", Code = "ALB" },
            new City { Id = 10, Name = "Ciudad Real", Code = "CR" },
            new City { Id = 11, Name = "Granada", Code = "GRA" },
            new City { Id = 12, Name = "Teruel", Code = "TER" }
        );

        //builder.HasData([
        //    new City
        //    {
        //        Id = 1,
        //        Name = "Zaragoza",
        //        Location = GeographicCoordinates.Create(41.6488, -0.8891)
        //    },
        //    new City
        //    {
        //        Id = 2,
        //        Name = "Barcelona",
        //        Location = GeographicCoordinates.Create(41.3851, 2.1734)
        //    },
        //    new City
        //    {
        //        Id = 3,
        //        Name = "Madrid",
        //        Location = GeographicCoordinates.Create(40.4168, -3.7038)
        //    },
        //    new City
        //    {
        //        Id = 4,
        //        Name = "Valencia",
        //        Location = GeographicCoordinates.Create(39.4699, -0.3763)
        //    },
        //    new City
        //    {
        //        Id = 5,
        //        Name = "Sevilla",
        //        Location = GeographicCoordinates.Create(37.3891, -5.9845)
        //    },
        //    new City
        //    {
        //        Id = 6,
        //        Name = "Cordoba",
        //        Location = GeographicCoordinates.Create(37.8882, -4.7794)
        //    },
        //    new City
        //    {
        //        Id = 7,
        //        Name = "Murcia",
        //        Location = GeographicCoordinates.Create(37.9922, -1.1307)
        //    },
        //    new City
        //    {
        //        Id = 8,
        //        Name = "Lerida",
        //        Location = GeographicCoordinates.Create(41.6176, 0.6200)
        //    },
        //    new City
        //    {
        //        Id = 9,
        //        Name = "Albacete",
        //        Location = GeographicCoordinates.Create(38.9943, -1.8561)
        //    },
        //    new City
        //    {
        //        Id = 10,
        //        Name = "Ciudad Real",
        //        Location = GeographicCoordinates.Create(38.9861, -3.9269)
        //    },
        //    new City
        //    {
        //        Id = 11,
        //        Name = "Granada",
        //        Location = GeographicCoordinates.Create(37.18817, -3.60667)
        //    },
        //    new City
        //    {
        //        Id = 12,
        //        Name = "Teruel",
        //        Location = GeographicCoordinates.Create(40.3453, -1.1068)
        //    }
        //    ]);
    }
}
