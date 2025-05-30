namespace Application.DTO;

public sealed record SettingsDTO
{
    public required decimal PricePerKilogram { get; init; }
    public required decimal PricePerLiterFuel { get; init; }
    public required decimal PricePerHourDriver { get; init; }
}
