using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class TruckEntityConfigurator : IEntityTypeConfiguration<Truck>
{
    public void Configure(EntityTypeBuilder<Truck> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasAlternateKey(t => t.Plate);

        builder.Property(t => t.Plate)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(t => t.ManufacturingDate)
            .HasColumnType("timestamp without time zone")
            .IsRequired();

        builder.Property(t => t.LastMaintenance)
            .HasColumnType("timestamp without time zone")
            .IsRequired();

        builder
            .HasOne(t => t.Driver)
            .WithOne(u => u.Truck)
            .HasForeignKey<Truck>(t => t.DriverId);

        // Seeder
        builder.HasData([
            new Truck
            {
                Id = 1,
                Plate = "4566KLM",
                Consumption = 25,
                Mileage = 100000,
                //ManufacturingDate = DateTime.SpecifyKind(new DateTime(2020, 5, 3), DateTimeKind.Utc),
                //LastMaintenance = DateTime.SpecifyKind(new DateTime(2020, 5, 3), DateTimeKind.Utc),
                ManufacturingDate = new DateTime(2020, 5, 3),
                LastMaintenance = new DateTime(2020, 5, 3),
                DriverId = 2,
            },
            new Truck
            {
                Id = 2,
                Plate = "8923XYZ",
                Consumption = 30,
                Mileage = 75000,
                ManufacturingDate = new DateTime(2019, 8, 15),
                LastMaintenance = new DateTime(2023, 7, 25),
                DriverId = 3,
            },
            new Truck
            {
                Id = 3,
                Plate = "5634QWE",
                Consumption = 28,
                Mileage = 120000,
                ManufacturingDate = new DateTime(2018, 3, 10),
                LastMaintenance = new DateTime(2023, 2, 15),
                DriverId = 5,
            },
            new Truck
            {
                Id = 4,
                Plate = "1122ABC",
                Consumption = 26,
                Mileage = 95000,
                ManufacturingDate = new DateTime(2021, 1, 21),
                LastMaintenance = new DateTime(2024, 4, 5),
                DriverId = 1,
            },
            new Truck
            {
                Id = 5,
                Plate = "7834LMN",
                Consumption = 27,
                Mileage = 80000,
                ManufacturingDate = new DateTime(2019, 11, 30),
                LastMaintenance = new DateTime(2023, 10, 10),
                DriverId = 4,
            },
            ]);
    }
}
