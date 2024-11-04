using Domain.Entities.Base;
using System.Collections.ObjectModel;

namespace Domain.Entities;

public class Trailer : EntityBase
{
    public decimal Length { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }

    public virtual Collection<Shift>? Shifts { get; set; }
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
