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
            ]);
    }
}
