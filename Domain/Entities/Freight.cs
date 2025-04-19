using Domain.Entities.Base;
using Domain.Enums;
using Domain.Exceptions;

namespace Domain.Entities;

public class Freight : AuditableEntityBase
{
    public long TruckId { get; set; }
    public long DriverId { get; set; }
    public long StartCityId { get; set; }
    public DateTime DueStart { get; set; }
    public FreightStatus Status { get; set; }
    public long RouteId { get; set; }
    public required decimal PricePerDriverHour { get; set; }
    public required decimal PricePerLiterFuel { get; set; }

    // Computed Properties
    public decimal TotalRevenue { get => Parcels.Sum(x => x.Price); }
    public decimal TotalWeight { get => Parcels.Sum(x => x.Weight); }
    //public decimal GetTotalWeight() => Parcels.Sum(x => x.Weight);
    public double TotalDistance { get => 2 * Route.Distance; }
    //public double GetTotalDistance() => 2 * Route.Distance;
    public decimal TotalFuelCost { get => (decimal)TotalDistance * PricePerLiterFuel; }
    public decimal TotalDriverCost { get => (decimal)GetTotalDuration().TotalHours * PricePerDriverHour; }
    public decimal TotalCost { get => TotalDriverCost + TotalFuelCost; }
    public TimeSpan GetTotalDuration() => TimeSpan.FromHours(Route.AvgSpeed / TotalDistance);
    public DateTime GetETA() => DueStart.Add(GetTotalDuration() / 2);
    public FreightStatus GetStatus()
    {
        if (Status == FreightStatus.Canceled)
            return FreightStatus.Canceled;

        if (DateTime.UtcNow < DueStart)
            return FreightStatus.Scheduled;

        if (DateTime.UtcNow > GetETA())
            return FreightStatus.Completed;

        return FreightStatus.Active;
    }

    // Navigation Properties
    public virtual Truck Truck { get; set; } = null!;
    public virtual Route Route { get; set; } = null!;
    public virtual User Driver { get; set; } = null!;
    public virtual City StartCity { get; set; } = null!;
    public virtual ICollection<Parcel> Parcels { get; set; } = [];

    public void AddParcel(Parcel parcel)
    {
        if (TotalWeight + parcel.Weight > Truck.MaxWeight)
            throw new CustomException("there is not enough room");

        if (StartCityId != parcel.OriginId)
            throw new CustomException("the freight origin does not match");

        if (Route.OriginId != parcel.OriginId && Route.DestinationId != parcel.DestinationId)
            throw new CustomException("the freight destination does not match");

        Parcels.Add(parcel);
    }
}
