using Domain.Entities.Base;

namespace Domain.Entities;

public class Truck : EntityBase
{
    public required string Plate { get; set; }
    public decimal Mileage { get; set; }
    public decimal Consumption { get; set; } // l/km
    public decimal MaxWeight { get; set; }
    public string Mark { get; set; } = string.Empty;
    public DateTime ManufacturingDate { get; set; }
    public DateTime LastMaintenance { get; set; }

    public TimeSpan Age { get => DateTime.Now - ManufacturingDate; }

    public virtual ICollection<Freight> Freights { get; set; } = [];
}
