using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class Freight : AuditableEntityBase
{
    public long TruckId { get; set; }
    public long DriverId { get; set; }
    public DateTime DueStart { get; set; }
    public DateTime DueEnd { get; set; }
    public ShiftStatus Status { get; set; }

    public decimal TotalRevenue { get => Pallets.Sum(x => x.Price); }
    public decimal GetTotalWeight() => Pallets.Sum(x => x.Weight);
    public double GetTotalDistance() => FreightRoutes.Sum(x => x.Route.Distance);

    public virtual Truck Truck { get; set; } = null!;
    public virtual User Driver { get; set; } = null!;
    public virtual ICollection<Pallet> Pallets { get; set; } = [];
    public virtual ICollection<FreightRoute> FreightRoutes { get; set; } = [];
}

public class FreightRoute : EntityBase
{
    public int Order { get; set; }
    public long FreightId { get; set; }
    public long RouteId { get; set; }

    public virtual Freight Freight { get; set; } = null!;
    public virtual Route Route { get; set; } = null!;
}
