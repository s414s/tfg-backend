using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class TruckEntityConfigurator
{
    public void Configure(EntityTypeBuilder<Truck> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Plate)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(t => t.ManufacturingDate)
            .IsRequired();
    }
}
