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

        builder.HasData([
            new MessageThread
            {
                Id = 1,
                FromId = 1,
                ToId = 2,
                Subject = "Project Kickoff",
                Teaser = "Let's schedule a kickoff meeting for the new project.",
                Created = DateTime.UtcNow,
                CreatedBy = 1,
                LastModified = DateTime.UtcNow.AddDays(-1),
                LastModifiedBy = 1,
            },
            new MessageThread
            {
                Id = 2,
                FromId = 1,
                ToId = 2,
                Subject = "Meeting Reminder",
                Teaser = "Don't forget about our meeting tomorrow at 10 AM.",
                Created = DateTime.UtcNow.AddHours(-2),
                CreatedBy = 1,
                LastModified = DateTime.UtcNow.AddDays(-1),
                LastModifiedBy = 1,
            },
            new MessageThread
            {
                Id = 3,
                FromId = 1,
                ToId = 2,
                // This instance uses the default subject ("No Subject") and an empty teaser.
                Created = DateTime.UtcNow.AddDays(-1),
                CreatedBy = 1,
                LastModified = DateTime.UtcNow.AddDays(-1),
                LastModifiedBy = 1,
            },
            new MessageThread
            {
                Id = 4,
                FromId = 1,
                ToId = 2,
                Subject = "Follow-up on Proposal",
                Teaser = "Please review the attached proposal document.",
                Created = DateTime.UtcNow.AddMinutes(-30),
                CreatedBy = 1,
                LastModified = DateTime.UtcNow.AddDays(-1),
                LastModifiedBy = 1,
            }]);
    }
}
