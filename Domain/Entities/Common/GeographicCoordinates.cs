namespace Domain.Entities.Common;

public record GeographicCoordinates
{
    public double Lat { get; init; }
    public double Lon { get; init; }

    private GeographicCoordinates() { }

    //public GeographicCoordinates(double lat, double lon)
    //{
    //    if (!LatRange.Contains(lat))
    //        throw new ArgumentOutOfRangeException(nameof(lat),
    //            $"Latitude must be between {LatRange.First()} and {LatRange.Last()} degrees.");

    //    if (!LonRange.Contains(lon))
    //        throw new ArgumentOutOfRangeException(nameof(lon),
    //            $"Longitude must be between {LonRange.First()} and {LonRange.Last()} degrees.");

    //    Lat = lat;
    //    Lon = lon;
    //}

    public static GeographicCoordinates Create(double lat, double lon)
    {
        var minLat = -90;
        var maxLat = -90;
        var minLong = -180;
        var maxLong = 180;

        if (lat < minLat || lat > maxLat)
            throw new ArgumentOutOfRangeException(nameof(lat),
                $"Latitude must be between {minLat} and {maxLat} degrees.");

        if (lon < minLong || lon > maxLong)
            throw new ArgumentOutOfRangeException(nameof(lon),
                $"Longitude must be between {minLong} and {maxLong} degrees.");

        return new GeographicCoordinates { Lat = lat, Lon = lon };
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