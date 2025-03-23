using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

public class MessageThreadEntityConfigurator : IEntityTypeConfiguration<MessageThread>
{
    public void Configure(EntityTypeBuilder<MessageThread> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasMany(c => c.Messages)
            .WithOne(x => x.MessageThread)
            .HasForeignKey(x => x.MessageThreadId);

        builder
            .HasOne(c => c.From)
            .WithMany()
            .HasForeignKey(x => x.FromId);

        builder
            .HasOne(c => c.To)
            .WithMany()
            .HasForeignKey(x => x.ToId);
    }
}
