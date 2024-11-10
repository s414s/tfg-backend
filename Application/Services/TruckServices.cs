using Domain.Entities;

namespace Application.Services;

public static class TruckServices
{
    public static DateTime GetNextDueMaintainanceDate(Truck truck)
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
