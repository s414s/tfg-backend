using Application.DTO;

namespace Application.Contracts;

public interface IRouteServices
{
    Task<IEnumerable<RouteDTO>> GetAll(string? origin, string? destination);
}
