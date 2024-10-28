using Domain.Entities.Base;
using Domain.Enums;
using System.Collections.ObjectModel;

namespace Domain.Entities;

public class Shift : EntityBase
{
    public DateTime StartDate { get; init; }
    public ShiftStatus Status { get; init; }
    public long? DriverId { get; init; }

    public virtual User? Driver { get; init; }
    public virtual Collection<Route> Routes { get; init; }

    public decimal GetTotalDistance() => Routes.Sum(x => x.Distance);

    public TimeSpan GetEstimatedDuration()
    {
        var totalDuration = TimeSpan.Zero;
        foreach (var route in Routes)
        {
            totalDuration.Add(route.GetDuration());
        }
        return totalDuration;
    }
}
