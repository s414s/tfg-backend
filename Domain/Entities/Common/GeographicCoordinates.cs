namespace Domain.Entities.Common;

public class GeographicCoordinates
{
    private readonly double[] LatRange = [-90, 90];
    private readonly double[] LonRange = [-180, 180];

    public double Lat { get; private set; }
    public double Lon { get; private set; }

    private GeographicCoordinates() { }

    public GeographicCoordinates(double lat, double lon)
    {
        if (!LatRange.Contains(lat))
            throw new ArgumentOutOfRangeException(nameof(lat),
                $"Latitude must be between {LatRange.First()} and {LatRange.Last()} degrees.");

        if (!LonRange.Contains(lon))
            throw new ArgumentOutOfRangeException(nameof(lon),
                $"Longitude must be between {LonRange.First()} and {LonRange.Last()} degrees.");

        Lat = lat;
        Lon = lon;
    }

    public CartesianCoordinates ToCartesianCoordinates()
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