using System.Collections.ObjectModel;

namespace Domain.Entities;

public class City
{
    public decimal Lat { get; init; }
    public decimal Lon { get; init; }
    public string Name { get; set; } = "";

    public virtual Collection<WareHouse> WareHouses { get; set; }
}
