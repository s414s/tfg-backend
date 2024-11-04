using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class RouteShiftConfigurator : IEntityTypeConfiguration<RouteShift>
{
    public void Configure(EntityTypeBuilder<RouteShift> builder)
    {
        builder
            .HasOne(x => x.Shift)
            .WithMany(x => x.RouteShifts)
            .HasForeignKey(x => x.ShiftId);

        builder
            .HasOne(x => x.Route)
            .WithMany(x => x.RouteShifts)
            .HasForeignKey(x => x.RouteId);
    }
}
