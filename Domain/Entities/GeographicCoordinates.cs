namespace Domain.Entities;

public class GeographicCoordinates
{
    public decimal Lat { get; init; }
    public decimal Lon { get; init; }
    public CartesianCoordinates ConvertToCartesianCoordinates()
    {
        // TODO
        return new CartesianCoordinates { X = Lat, Y = Lon };
    }
}