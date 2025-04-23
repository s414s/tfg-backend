namespace Application.DTO;

public sealed record TruckDTO
{
    public required long Id { get; init; }
    public required string Plate { get; init; }
    public required decimal Mileage { get; init; }
    public required decimal Consumption { get; init; }
    public required long ManufacturingDateUnix { get; init; }
    public required long LastMaintenanceDateUnix { get; init; }
    public required string Mark { get; init; }
    public required decimal MaxWeight { get; init; }
};
