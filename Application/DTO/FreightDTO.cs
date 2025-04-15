using Domain.Enums;

namespace Application.DTO;

public record FreightDTO
{
    public required long Id { get; init; }
    public required FreightStatus Status { get; init; }
    public required TruckDTO Truck { get; init; }
    public required string Origin { get; init; }
    public required string Destination { get; init; }
    public required UserDTO Driver { get; init; }
    public required DateTime DueStart { get; init; }
    public required double TotalDistance { get; init; }
    public required double DurationMinutes { get; init; }
    public required DateTime FinishTime { get; init; }
};
