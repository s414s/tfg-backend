namespace Domain.Entities;

public readonly struct CartesianCoordinates
{
    public double X { get; init; }
    public double Y { get; init; }

    public double DistanceTo(CartesianCoordinates point)
    {
        return Math.Sqrt(Math.Pow(point.X - X, 2) + Math.Pow(point.Y, 2));
    }
}
