using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class PalletEntityConfigurator : IEntityTypeConfiguration<Pallet>
{
    public void Configure(EntityTypeBuilder<Pallet> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(x => x.Height).IsRequired();
        builder.Property(x => x.Weight).IsRequired();

        builder
            .HasOne(p => p.Shift)
            .WithMany(s => s.Pallets)
            .HasForeignKey(p => p.ShiftId);
    }
}




