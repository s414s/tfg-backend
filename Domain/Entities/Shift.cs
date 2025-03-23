using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

// TODO - borrar entidad
public class Shift : EntityBase
{
    public DateTime StartDate { get; set; }
    //public DateTime ETA
    //{
    //    get => StartDate.AddHours(RouteShifts?.Sum(x => x.Route.Duration.TotalHours) ?? 0);
    //}

    public ShiftStatus Status { get; set; }
    public virtual ICollection<Pallet> Pallets { get; set; } = [];


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
