using Application.Extensions;
using Domain.Entities;

namespace Application.DTO;

public record TruckDTO
{
    public long Id { get; init; }
    public string Plate { get; init; } = "";
    public decimal Mileage { get; init; }
    public decimal Consumption { get; init; }
    public long ManufacturingDateUnix { get; init; }
    public long LastMaintenanceDateUnix { get; init; }
    public LocationDTO CurrentLocation { get; init; }

    public static TruckDTO MapFromEntity(Truck entity)
    {
        return new TruckDTO
        {
            Plate = entity.Plate,
            Mileage = entity.Mileage,
            Consumption = entity.Consumption,
            ManufacturingDateUnix = entity.ManufacturingDate.ToUnixTime(),
        };
    }
};

public record TruckWithTrailerDTO : TruckDTO
{
    public TrailerDTO? Trailer { get; init; }

    public static TruckWithTrailerDTO MapFromEntity(Truck entity, TrailerDTO? trailer)
    {
        return new TruckWithTrailerDTO
        {
            Plate = entity.Plate,
            Mileage = entity.Mileage,
            Consumption = entity.Consumption,
            Trailer = trailer,
        };
    }
}
