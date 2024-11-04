using Domain.Entities.Base;

namespace Domain.Entities;

public class RouteShift : EntityBase
{
    public long RouteId { get; set; }
    public long ShiftId { get; set; }

    public virtual Route Route { get; set; }
    public virtual Shift Shift { get; set; }
}
