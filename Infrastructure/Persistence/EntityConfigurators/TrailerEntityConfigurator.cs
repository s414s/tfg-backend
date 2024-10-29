using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class TrailerEntityConfigurator
{
    public void Configure(EntityTypeBuilder<Trailer> builder)
    {
        builder.HasKey(t => t.Id);
    }
}
