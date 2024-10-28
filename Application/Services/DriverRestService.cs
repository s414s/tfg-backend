using Domain.Contracts;
using Domain.Entities;

namespace Application.Services;

//https://www.transportes.gob.es/transporte-terrestre/inspeccion-y-seguridad-en-el-transporte/tacografo-digital/legislacion-y-documentacion/resumen-de-la-legislacion-aplicable/tiempos-de-descanso#:~:text=Per%C3%ADodo%20de%20descanso%20semanal%20normal,m%C3%ADnimo%20de%2024%20horas%20consecutivas.
public class DriverRestService
{
    private readonly IUsersRepository _userRepository;
    private long _driverId;

    public DriverRestService(IUsersRepository userRepository)
    {
        _userRepository = userRepository;
    }

    // Período de descanso diario normal: cualquier período de descanso de al menos 11 horas.

    // Alternativamente, el período de descanso diario normal se podrá tomar en dos períodos,
    // - el primero de ellos de al menos tres horas ininterrumpidas
    // - y el segundo de al menos 9 horas ininterrumpidas.

    // Período de descanso diario reducido: cualquier período de descanso de al menos 9 horas, pero inferior a 11 horas

    // Los conductores no podrán tomarse más de tres períodos de descanso diario reducidos entre dos períodos de descanso semanales.

    enum RestType
    {
        Daily,
        DailyReduced,
        Weekly,
    }

    public DriverRestService WithDriver(long driverId)
    {
        _driverId = driverId;
        return this;
    }

    public TimeSpan GetExpectedRestTime(Shift shift)
    {
        return TimeSpan.FromHours(0);
    }

    private RestType GetDailyRestType(DateTime from, DateTime until)
    {
        return (until - from) > TimeSpan.FromHours(9) ? RestType.Daily : RestType.DailyReduced;
    }
}
