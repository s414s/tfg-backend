using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class CityEntityConfigurator
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

        // One-to-many relationship configuration
        builder
            .HasMany(c => c.WareHouses)
            .WithOne(w => w.City)
            .HasForeignKey(w => w.CityId)
            .OnDelete(DeleteBehavior.Cascade)
            ;
    }
}
