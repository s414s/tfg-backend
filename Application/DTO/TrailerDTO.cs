namespace Application.DTO;

public record DimensionsDTO
{
    public decimal Length { get; init; }
    public decimal Width { get; init; }
    public decimal Height { get; init; }
}

public record LocationDTO
{
    public required float Lat { get; init; }
    public required float Lon { get; init; }
}
