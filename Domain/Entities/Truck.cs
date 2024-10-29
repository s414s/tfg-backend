using Domain.Entities.Base;

namespace Domain.Entities;

public class Truck : EntityBase
{
    public string Plate { get; set; }
    public decimal Mileage { get; set; }
    //public decimal MaxWeight { get; set; }
    public decimal Consumption { get; set; } // l/km
    public DateTime ManufacturingDate { get; set; }
    public DateTime LastMaintenance { get; set; }

    public TimeSpan Age { get => DateTime.UtcNow - ManufacturingDate; }
}
