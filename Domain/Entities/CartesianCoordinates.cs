namespace Domain.Entities;

public class CartesianCoordinates
{
    public decimal X { get; init; }
    public decimal Y { get; init; }

    public double DistanceTo(CartesianCoordinates point)
    {
        return Math.Sqrt(Math.Pow((double)point.X, 2) + Math.Pow((double)point.Y, 2));
    }
}
