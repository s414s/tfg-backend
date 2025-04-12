using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class Freight : AuditableEntityBase
{
    public long TruckId { get; set; }
    public long DriverId { get; set; }
    public long StartCityId { get; set; }
    public DateTime DueStart { get; set; }
    public FreightStatus Status { get; set; }
    public long RouteId { get; set; }

    public decimal TotalRevenue { get => Parcels.Sum(x => x.Price); }
    public decimal GetTotalWeight() => Parcels.Sum(x => x.Weight);
    public double GetTotalDistance() => 2 * Route.Distance;
    public TimeSpan GetTotalDuration() => TimeSpan.FromHours(Route.AvgSpeed / GetTotalDistance());
    public DateTime GetETA() => DueStart.Add(GetTotalDuration() / 2);

    public virtual Truck Truck { get; set; } = null!;
    public virtual Route Route { get; set; } = null!;
    public virtual User Driver { get; set; } = null!;
    public virtual City StartCity { get; set; } = null!;
    public virtual ICollection<Parcel> Parcels { get; set; } = [];
    //public virtual ICollection<FreightRoute> FreightRoutes { get; set; } = [];

    public void AddParcel(Parcel parcel)
    {
        if (GetTotalWeight() + parcel.Weight > Truck.MaxWeight)
            throw new Exception("there is not enough room"); // TODO - custom exception

        if (StartCityId != parcel.OriginId)
            throw new Exception("the freight origin does not match"); // TODO - custom exception

        if (Route.OriginId != parcel.OriginId && Route.DestinationId != parcel.DestinationId)
            throw new Exception("the freight destination does not match"); // TODO - custom exception

        Parcels.Add(parcel);
    }
}

//public class FreightRoute : EntityBase
//{
//    public int Order { get; set; }
//    public long FreightId { get; set; }
//    public long RouteId { get; set; }

//    public virtual Freight Freight { get; set; } = null!;
//    public virtual Route Route { get; set; } = null!;
//}
