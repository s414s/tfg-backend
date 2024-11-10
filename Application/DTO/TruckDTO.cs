namespace Application.DTO;

public record TruckDTO
{
    public long Id { get; init; }
    public string Plate { get; init; } = "";
    public decimal Mileage { get; init; }
    public decimal Consumption { get; init; }
    public string DriverName { get; init; } = "";
    public long ManufacturingDateUnix { get; init; }
    public long LastMaintenanceDateUnix { get; init; }
    public LocationDTO CurrentLocation { get; init; }
};

public record TruckWithTrailerDTO : TruckDTO
{
    public TrailerDTO? Trailer { get; init; }
}
