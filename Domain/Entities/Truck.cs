namespace Domain.Entities;

public class Truck
{
    public string Plate { get; set; }
    public decimal MaxWeight { get; set; }
    public decimal Consumption { get; set; } // l/km
    public decimal ExtraConsumptionPerKg { get; set; } // l/kg
    public int NumberAxles { get; set; } // l/kg
}
