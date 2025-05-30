using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

internal class SettingsEntityConfigurator : IEntityTypeConfiguration<SettingsEntity>
{
    public void Configure(EntityTypeBuilder<SettingsEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasData([
            new SettingsEntity
            {
                Id = 1,
                PricePerHourDriver = 20,
                PricePerKilogram = 50,
                PricePerLiterFuel = 1.80m,
            }]);
    }
}
