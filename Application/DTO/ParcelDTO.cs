using Domain.Enums;

namespace Application.DTO;

public record ParcelDTO
{
    public required decimal Weight { get; init; }
    public required LocationDTO CurrentLocation { get; init; }
    public required DimensionsDTO Dimensions { get; init; }
    public required CityDTO Origin { get; init; }
    public required CityDTO Destination { get; init; }
}
