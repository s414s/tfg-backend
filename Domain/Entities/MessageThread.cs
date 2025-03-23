using Domain.Entities.Base;
using System.Runtime.InteropServices;

namespace Domain.Entities;

public class MessageThread : AuditableEntityBase
{
    public long FromId { get; set; }
    public long ToId { get; set; }
    public string Subject { get; set; } = "No Subject";
    public string Teaser { get; set; } = "";

    public virtual User From { get; set; }
    public virtual User To { get; set; }
    public virtual ICollection<Message> Messages { get; set; } = [];

    public static MessageThread Create(long author, long to, string subject, Message message)
    {
        if (author == to)
        {
            throw new Exception("Can not be same user"); // TODO - custom exception
        }

        return new MessageThread()
        {
            FromId = author,
            ToId = to,
            Teaser = message.Text,
            Subject = subject,
            Messages = [message],
        };
    }
}
