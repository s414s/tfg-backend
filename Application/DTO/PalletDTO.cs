using Domain.Enums;

namespace Application.DTO;

public record PalletDTO
{
    public required decimal Weight { get; init; }
    public required LocationDTO CurrentLocation { get; init; }
    public required DimensionsDTO Dimensions { get; init; }
    public required PalletType Type { get; init; }
    public required CityDTO Origin { get; init; }
    public required CityDTO Destination { get; init; }
}
