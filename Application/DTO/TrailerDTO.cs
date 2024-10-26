namespace Application.DTO;

public record TrailerDTO
{
    public string Plate { get; init; }
    public LocationDTO CurrentLocation { get; init; }
    public DimensionsDTO Dimensions { get; init; }
}

public record DimensionsDTO
{
    public decimal Length { get; init; }
    public decimal Width { get; init; }
    public decimal Height { get; init; }
}

public record LocationDTO
{
    public float Lat { get; init; }
    public float Lon { get; init; }
}
