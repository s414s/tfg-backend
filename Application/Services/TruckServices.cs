using Application.DTO;

namespace Application.Services;

public class TruckServices
{
    private readonly IRepository<Truck> _truckRepository;
    public async TruckInformationDTO CreateNew(TruckInformationDTO truckInfo)
    {

    }

    public async TruckInformationDTO Update(long truckId)
    {
        // TODO - check for plate

    }

    public async void Delete(long truckId)
    {

    }
}
