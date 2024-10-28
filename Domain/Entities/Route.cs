using Domain.Entities.Base;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Domain.Entities;

public class Route : EntityBase
{
    public decimal Distance { get; set; } // update on route change
    public decimal AvgSpeed { get; set; } // retro feeding
    public long OriginId { get; set; }
    public long DestinationId { get; set; }
    /// <summary>
    /// Collection of Geographic Coordinates
    /// </summary>
    public JsonDocument Points { get; set; }

    public virtual City Origin { get; set; }
    public virtual City Destination { get; set; }

    public virtual Collection<Shift> Shifts { get; set; }

    public TimeSpan GetDuration() => TimeSpan.FromHours(1 / ((double)AvgSpeed / (double)Distance));
}
