using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class RouteEntityConfigurator : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.HasKey(t => t.Id);

        builder
            .HasOne(r => r.Origin)
            .WithMany(c => c.RouteOrigins)
            .HasForeignKey(s => s.OriginId)
            ;

        builder
            .HasOne(r => r.Destination)
            .WithMany(c => c.RouteDestinations)
            .HasForeignKey(s => s.DestinationId)
            ;
    }
}

