using Domain.Entities.Base;
using Domain.Entities.Common;

namespace Domain.Entities;

public class City : EntityBase
{
    //public double Lat { get; init; }
    //public double Lon { get; init; }
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
    public GeographicCoordinates Location { get; set; }

    public virtual ICollection<Route>? RouteOrigins { get; set; }
    public virtual ICollection<Route>? RouteDestinations { get; set; }
}
