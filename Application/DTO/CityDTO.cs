namespace Application.DTO;

public record CityDTO
{
    public required long Id { get; init; }
    public required double Lat { get; init; }
    public required double Lon { get; init; }
    public required string Name { get; set; }
    public required string Code { get; set; }
}
