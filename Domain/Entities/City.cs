using System.Collections.ObjectModel;

namespace Domain.Entities;

public class City
{
    public double Lat { get; init; }
    public double Lon { get; init; }
    public string Name { get; set; } = "";
    public string Code { get; set; } = "";

    public virtual Collection<WareHouse> WareHouses { get; set; }
}
