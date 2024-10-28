namespace Application.DTO;

public record CityDTO
{
    public double Lat { get; init; }
    public double Lon { get; init; }
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";
}
