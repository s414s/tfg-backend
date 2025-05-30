using Domain.Entities.Base;

namespace Domain.Entities;

public class Message : EntityBase
{
    public long UserId { get; set; }
    public long MessageThreadId { get; set; }
    public string Text { get; set; } = "";
    public bool IsRead { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;

    public virtual User User { get; set; } = null!;
    public virtual MessageThread MessageThread { get; set; } = null!;
}
