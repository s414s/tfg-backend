using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

//https://www.logismarket.es/blog/medidas-palets-estandares-extendidos#:~:text=Por%20ello%2C%20la%20fabricaci%C3%B3n%20de,tama%C3%B1os%20de%20palets%20ampliamente%20utilizados.
public class Pallet : EntityBase
{
    public decimal Height { get; set; }
    public decimal Weight { get; private set; }
    public Guid Code { get; init; }
    public PalletType Type { get; set; }
    public DateTime DueDate { get; set; }
    public long OriginId { get; set; }
    public long DestinationId { get; set; }

    public virtual City Origin { get; set; }
    public virtual City Destination { get; set; }

    public decimal Length { get => Type == PalletType.European ? 1200 : 1200; }
    public decimal Width { get => Type == PalletType.European ? 800 : 1000; }
    public decimal StaticLoad { get => Type == PalletType.European ? 5500 : 4500; }
    public decimal DynamicLoad { get => Type == PalletType.European ? 1500 : 1500; }
    public decimal MaxHeight { get => Type == PalletType.European ? 2600 : 2500; }
    public static Pallet New(PalletType Type)
    {
        return new Pallet { Type = Type, Code = Guid.NewGuid() };
    }

    public void SetWeight(decimal Weight)
    {
        if (Weight > DynamicLoad)
            throw new Exception("Too heavy");
    }

    public void StackPallets(params Pallet[] pallets)
    {
        if (pallets.Sum(x => x.Weight) > StaticLoad)
            throw new Exception("Too heavy");
    }
}
