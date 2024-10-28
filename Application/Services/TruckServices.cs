using Application.DTO;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class TruckServices
{
    private readonly IRepositoryBase<Truck> _truckRepository;

    public TruckServices(IRepositoryBase<Truck> truckRepository)
    {
        _truckRepository = truckRepository;
    }

    public async Task<TruckDTO> Create(TruckDTO truckInfo)
    {
        return new TruckDTO { };
    }

    public async Task<TruckDTO> Update(TruckDTO updatedTruck)
    {
        var truck = await _truckRepository.Query
            .FirstOrDefaultAsync(x => x.Id == updatedTruck.Id)
            ?? throw new Exception("truck not found");

        truck.Plate = updatedTruck.Plate;

        return TruckDTO.MapFromEntity(truck);
    }

    public async Task Delete(long truckId)
    {
        var truck = await _truckRepository.Query
            .FirstOrDefaultAsync(x => x.Id == truckId)
            ?? throw new Exception("truck not found");

        _truckRepository.Remove(x => x.Id == truck.Id);
    }

    private DateTime GetNextDueMaintainanceDate(Truck truck)
    {
        DateTime result;
        if (truck.Age <= TimeSpan.FromDays(365 * 10)) // Anual
        {
            result = truck.LastMaintenance.AddMonths(12);
        }
        else // Cada 6 meses
        {
            result = truck.LastMaintenance.AddMonths(6);
        }
        return result < DateTime.Now ? DateTime.Now : result;
    }
}
