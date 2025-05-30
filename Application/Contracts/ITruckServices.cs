using Application.DTO;

namespace Application.Contracts;

public interface ITruckServices
{
    Task<IReadOnlyList<TruckDTO>> GetAll();
    Task Create(TruckDTO truck);
    Task Delete(long truckId);
}
