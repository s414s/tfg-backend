using Domain.Entities.Base;
using Domain.Entities.Common;
using System.Collections.ObjectModel;

namespace Domain.Entities;

public class City : EntityBase
{
    //public double Lat { get; init; }
    //public double Lon { get; init; }
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
    public GeographicCoordinates Location { get; init; }

    public virtual Collection<WareHouse> WareHouses { get; set; }
    public virtual Collection<Route> RouteOrigins { get; set; }
    public virtual Collection<Route> RouteDestinations { get; set; }
    public virtual Collection<Pallet> PalletOrigins { get; set; }
    public virtual Collection<Pallet> PalletDestinations { get; set; }
}
