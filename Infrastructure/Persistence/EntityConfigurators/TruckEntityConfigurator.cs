using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class TruckEntityConfigurator
{
    public void Configure(EntityTypeBuilder<Truck> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasAlternateKey(t => t.Plate);

        builder.Property(t => t.Plate)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(t => t.ManufacturingDate)
            .IsRequired();

        // Populate Data
        builder.HasData([
            new Truck{Id = 1, Plate = "4566KLM", Consumption = 25},
            ]);
    }
}
