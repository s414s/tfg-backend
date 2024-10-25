using System.Collections.ObjectModel;

namespace Domain.Entities;

public class Shift
{
    public DateTime StartDate { get; init; }
    public long PilotId { get; init; }
    public long CoPilotId { get; init; }

    public virtual Collection<Route> Routes { get; init; }
    public virtual User Pilot { get; init; }
    public virtual User CoPilot { get; init; }
}
