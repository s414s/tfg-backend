using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurators;

internal class MessageEntityConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .HasOne(c => c.MessageThread)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.MessageThreadId);

        builder
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
    }
}
