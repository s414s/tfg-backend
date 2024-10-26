using Domain.Enums;

namespace Application.DTO;

public record PalletDTO
{
    public LocationDTO CurrentLocation { get; init; }
    public DimensionsDTO Dimensions { get; init; }
    public PalletType Type { get; init; }
}
