using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class PalletEntityConfigurator : IEntityTypeConfiguration<Parcel>
{
    public void Configure(EntityTypeBuilder<Parcel> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(x => x.Weight).IsRequired();

        builder.HasOne(x => x.Origin)
            .WithMany()
            .HasForeignKey(x => x.OriginId);

        builder.HasOne(x => x.Destination)
            .WithMany()
            .HasForeignKey(x => x.DestinationId);
    }
}




