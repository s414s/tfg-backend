using Domain.Entities;

namespace Application.DTO;

public record TruckDTO
{
    public string Plate { get; init; } = "";
    public decimal Mileage { get; init; }
    public decimal Consumption { get; init; }
    public LocationDTO CurrentLocation { get; init; }

    public static TruckDTO MapFromEntity(Truck entity)
    {
        return new TruckDTO
        {
            Plate = entity.Plate,
            Mileage = entity.Mileage,
            Consumption = entity.Consumption
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
