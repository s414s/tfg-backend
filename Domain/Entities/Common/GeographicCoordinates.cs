namespace Domain.Entities.Common;

public readonly struct GeographicCoordinates
{
    public double Lat { get; init; }
    public double Lon { get; init; }
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