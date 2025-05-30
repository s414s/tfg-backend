namespace Domain.Entities.Base;

public class AuditableEntityBase : EntityBase
{
    public DateTime? DeletedDate { get; set; }
    public long DeletedBy { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public long CreatedBy { get; set; }
    public DateTime LastModified { get; set; } = DateTime.UtcNow;
    public long LastModifiedBy { get; set; }
}
