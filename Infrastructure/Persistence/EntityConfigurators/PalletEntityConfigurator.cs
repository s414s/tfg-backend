using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class PalletEntityConfigurator
{
    public void Configure(EntityTypeBuilder<Pallet> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .HasOne(p => p.Origin)
            .WithMany(d => d.PalletOrigins)
            .HasForeignKey(p => p.OriginId)
            ;

        builder
            .HasOne(p => p.Destination)
            .WithMany(d => d.PalletDestinations)
            .HasForeignKey(p => p.DestinationId)
            ;
    }
}




