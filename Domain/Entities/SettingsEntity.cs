using Domain.Entities.Base;

namespace Domain.Entities;

public class SettingsEntity : EntityBase
{
    public decimal PricePerKilogram { get; set; }
    public decimal PricePerLiterFuel { get; set; }
    public decimal PricePerHourDriver { get; set; }
}
