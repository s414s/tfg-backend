using System.Collections.ObjectModel;

namespace Domain.Entities;

public class Route
{
    public decimal Distance { get; set; } // update on route change
    public decimal AvgSpeed { get; set; } // retro feeding
    public City Origin { get; set; }
    public City Destination { get; set; }

    public virtual Collection<GeographicCoordinates> Points { get; set; }

    public TimeSpan GetDuration()
    {
        return TimeSpan.FromHours(1 / ((double)AvgSpeed / (double)Distance));
    }
}
