using Domain.Entities.Base;

namespace Domain.Entities;

public class Truck : EntityBase
{
    public required string Plate { get; set; }
    public decimal Mileage { get; set; }
    //public decimal MaxWeight { get; set; }
    public decimal Consumption { get; set; } // l/km
    public DateTime ManufacturingDate { get; set; }
    public DateTime LastMaintenance { get; set; }
    public decimal Length { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public int MaxPalletsLoad { get; set; }

    public TimeSpan Age { get => DateTime.Now - ManufacturingDate; }

    public void LoadPallet(Pallet pallet)
    {
        // TODO - check maxWeight
        var area = Width * Length;
        var totalVolume = area * Height;
    }

    public virtual ICollection<Shift> Shifts { get; set; } = [];
    public virtual ICollection<Freight> Freights { get; set; } = [];
}
