using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class ShiftEntityConfigurator : IEntityTypeConfiguration<Shift>
{
    public void Configure(EntityTypeBuilder<Shift> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(x => x.StartDate)
            .HasColumnType("timestamp without time zone")
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired()
            .HasDefaultValue(ShiftStatus.Scheduled);

        builder
            .HasMany(s => s.Pallets)
            .WithOne(p => p.Shift)
            .HasForeignKey(p => p.ShiftId);
    }
}
