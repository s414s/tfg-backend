namespace Application.DTO;

public record ParcelDTO
{
    public required long Id { get; init; }
    public required decimal Weight { get; init; }
    public required string Origin { get; init; }
    public required string Destination { get; init; }
    public required string ContactEmail { get; init; }
    public required DateTime ETA { get; init; }
    public required DateTime ETD { get; init; }
    public required Guid Guid { get; init; }
    public required decimal Price { get; init; }
}
