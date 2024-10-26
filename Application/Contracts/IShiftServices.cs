using Application.DTO;

namespace Application.Contracts;

public interface IShiftServices
{
    Task Create(RouteDTO route);
    Task Detele(long shiftId);
    Task Update(long shiftId);
}
