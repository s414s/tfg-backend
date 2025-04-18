using Domain.Entities.Base;

namespace Domain.Entities;

//https://www.logismarket.es/blog/medidas-palets-estandares-extendidos#:~:text=Por%20ello%2C%20la%20fabricaci%C3%B3n%20de,tama%C3%B1os%20de%20palets%20ampliamente%20utilizados.
public class Parcel : EntityBase
{
    public decimal Weight { get; set; }
    public decimal Price { get; set; }
    public long FreightId { get; set; }
    public long OriginId { get; set; }
    public long DestinationId { get; set; }
    public string ContactEmail { get; set; } = "";
    public Guid Guid { get; set; } = new Guid();

    public virtual Freight Freight { get; set; } = null!;
    public virtual City Origin { get; set; } = null!;
    public virtual City Destination { get; set; } = null!;

    public static Parcel Create(long shiftId)
    {
        return new Parcel { FreightId = shiftId };
    }
}
