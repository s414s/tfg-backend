namespace Application.DTO;

public record LocationDTO
{
    public required float Lat { get; init; }
    public required float Lon { get; init; }
}
