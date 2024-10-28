using Domain.Entities.Base;

namespace Domain.Entities;

public class WareHouse : EntityBase
{
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string Name { get; set; } = "";
    public TimeSpan UnloadTime { get; set; }
    public long CityId { get; set; }

    public virtual City City { get; set; }
}
