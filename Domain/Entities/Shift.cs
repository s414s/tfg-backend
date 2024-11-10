using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class Shift : EntityBase
{
    public DateTime StartDate { get; set; }
    public DateTime ETA
    {
        get => StartDate
            .AddHours(RouteShifts?.Sum(x => x.Route.Duration.TotalHours) ?? 0);
    }

    public ShiftStatus Status { get; set; }
    public long? TruckId { get; set; }
    public long? TrailerId { get; set; }

    public virtual Truck? Truck { get; set; }
    public virtual Trailer? Trailer { get; set; }
    public virtual ICollection<Pallet>? Pallets { get; set; }
    public virtual ICollection<RouteShift>? RouteShifts { get; set; }


    //public decimal GetTotalWeight() => Load?.Sum(x => x.DynamicLoad) ?? 0;
    //public decimal GetTotalDistance() => Routes?.Sum(x => x.Distance) ?? 0;
    //public TimeSpan GetEstimatedDuration()
    //{
    //    var totalDuration = TimeSpan.Zero;
    //    foreach (var route in Routes)
    //    {
    //        totalDuration.Add(route.GetDuration());
    //    }
    //    return totalDuration;
    //}

}
