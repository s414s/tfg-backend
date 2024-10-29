namespace Domain.Entities.Common;

public class GeographicCoordinates
{
    public double Lat { get; set; }
    public double Lon { get; set; }
    public CartesianCoordinates ConvertToCartesianCoordinates()
    {
        // Convert latitude and longitude from degrees to radians
        double latRadians = Lat * Math.PI / 180;
        double lonRadians = Lon * Math.PI / 180;

        const double earthRadius = 6371000; // Earth radius in meters

        return new CartesianCoordinates
        {
            X = earthRadius * Math.Cos(latRadians) * Math.Cos(lonRadians),
            Y = earthRadius * Math.Cos(latRadians) * Math.Sin(lonRadians),
        };
    }
}