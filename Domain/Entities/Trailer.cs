using System.Collections.ObjectModel;

namespace Domain.Entities;

public class Trailer
{
    public decimal Length { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public string Plate { get; set; }

    public virtual Collection<Pallet> Load { get; init; }
    public decimal GetTotalWeight() => Load.Sum(x => x.DynamicLoad);
    public void LoadPallet()
    {
        // TODO - check maxWeight
        var area = Width * Length;
        var totalVolume = area * Height;

    }

    public void UnLoadPallet()
    {

    }

}
