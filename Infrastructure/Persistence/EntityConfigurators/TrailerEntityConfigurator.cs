using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class TrailerEntityConfigurator : IEntityTypeConfiguration<Trailer>
{
    public void Configure(EntityTypeBuilder<Trailer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Length).IsRequired();
        builder.Property(x => x.Height).IsRequired();

        // Seeder
        builder.HasData([
            new Trailer
            {
                Id = 1,
                Length = 12m,
                Width = 2.5m,
                Height = 4m,
            },
            ]);
    }
}
