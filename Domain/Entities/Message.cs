using Domain.Entities.Base;

namespace Domain.Entities;

public class Message : EntityBase
{
    public long UserId { get; set; }
    public long MessageThreadId { get; set; }
    public string Text { get; set; } = "";

    public virtual User User { get; set; }
    public virtual MessageThread MessageThread { get; set; }
}
