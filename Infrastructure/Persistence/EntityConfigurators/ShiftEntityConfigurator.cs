using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class ShiftEntityConfigurator
{
    public void Configure(EntityTypeBuilder<Shift> builder)
    {
        builder.HasKey(s => s.Id);

        // One-to-many relationship configuration
        builder
            .HasOne(s => s.Driver)
            .WithMany(d => d.Shifts)
            .HasForeignKey(s => s.DriverId)
            .OnDelete(DeleteBehavior.Cascade)
            ;

        // many-to-many relationship configuration
        builder
            .HasMany(s => s.Routes)
            .WithMany(r => r.Shifts)
            ;
    }
}
