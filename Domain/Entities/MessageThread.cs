using Domain.Entities.Base;

namespace Domain.Entities;

public class MessageThread : AuditableEntityBase
{
    public long UserId { get; set; }
    public string Text { get; set; } = "";
    public string Subject { get; set; } = "";
    public string Teaser { get; set; } = "";
    public virtual bool IsRead { get; set; }
    public virtual User User { get; set; }
}
