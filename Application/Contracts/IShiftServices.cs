namespace Application.Contracts;

public interface IShiftServices
{
    Task Create(IEnumerable<long> routeIds);
    Task Preview(IEnumerable<long> routeIds);
    Task Detele(long shiftId);
    Task Update(long shiftId);
}
