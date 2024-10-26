namespace Domain.Entities.Base;

public class SoftDeleteEntity : EntityBase
{
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}
