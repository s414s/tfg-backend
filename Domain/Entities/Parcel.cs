using Domain.Entities.Base;

namespace Domain.Entities;

public class Parcel : EntityBase
{
    public decimal Weight { get; set; }
    public decimal Price { get; set; }
    public long FreightId { get; set; }
    public long OriginId { get; set; }
    public long DestinationId { get; set; }
    public string ContactEmail { get; set; } = "";
    public Guid Guid { get; set; } = Guid.NewGuid();

    public virtual Freight Freight { get; set; } = null!;
    public virtual City Origin { get; set; } = null!;
    public virtual City Destination { get; set; } = null!;

    public static Parcel Create(long shiftId)
    {
        return new Parcel { FreightId = shiftId };
    }
}
