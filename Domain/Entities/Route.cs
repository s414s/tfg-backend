using Domain.Entities.Base;
using System.Text.Json;

namespace Domain.Entities;

public class Route : EntityBase
{
    public double Distance { get; set; } // update on route change
    public double AvgSpeed { get; set; } // retro feeding
    public TimeSpan Duration { get => TimeSpan.FromHours(1 / (AvgSpeed / Distance)); }
    public long OriginId { get; set; }
    public long DestinationId { get; set; }
    /// <summary>
    /// Collection of Geographic Coordinates
    /// </summary>
    public JsonDocument Points { get; set; }

    public virtual City Origin { get; set; }
    public virtual City Destination { get; set; }

    public virtual ICollection<RouteShift>? RouteShifts { get; set; }
}
