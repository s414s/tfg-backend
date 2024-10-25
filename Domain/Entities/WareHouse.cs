using Domain.Entities.Base;

namespace Domain.Entities;

public class WareHouse
{
    public decimal Lat { get; set; }
    public decimal Len { get; set; }
    public string Name { get; set; } = "";
    public TimeSpan UnloadTime { get; set; }

    public virtual City City { get; set; }
}
