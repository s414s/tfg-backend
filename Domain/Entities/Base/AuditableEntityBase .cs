namespace Domain.Entities.Base;

public class AuditableEntityBase : EntityBase
{
    public DateTimeOffset DeletedDate { get; set; }
    public long DeletedBy { get; set; }
    public DateTimeOffset Created { get; set; }
    public long CreatedBy { get; set; }
    public DateTimeOffset LastModified { get; set; }
    public long LastModifiedBy { get; set; }
}
