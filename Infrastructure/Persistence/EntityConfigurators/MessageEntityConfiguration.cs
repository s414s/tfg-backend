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

        builder.HasData([
            new Message
            {
                Id = 1,
                UserId = 1,
                MessageThreadId = 1,
                Text = "Hey, are you available for a call?",
                IsRead = false,
                Date = DateTime.UtcNow.AddMinutes(-45)
            },
            new Message
            {
                Id = 2,
                UserId = 1,
                MessageThreadId = 1,
                Text = "Yes, I can join in 5 minutes.",
                IsRead = true,
                Date = DateTime.UtcNow.AddMinutes(-30)
            },
            new Message
            {
                Id = 3,
                UserId = 1,
                MessageThreadId = 2,
                Text = "The meeting has been rescheduled to tomorrow.",
                IsRead = false,
                Date = DateTime.UtcNow.AddDays(-1)
            },
            new Message
            {
                Id = 4,
                UserId = 1,
                MessageThreadId = 2,
                Text = "Thanks for the update!",
                IsRead = true,
                Date = DateTime.UtcNow.AddDays(-1).AddMinutes(10)
            }]);
    }
}
