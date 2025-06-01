using Application.DTO;
using Domain.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Routes.Query;

public sealed record GetAllCitiesRequest(long? OriginId) : IRequest<IEnumerable<CityDTO>> { }

internal sealed class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesRequest, IEnumerable<CityDTO>>
{
    private readonly IRepository<City> _citiesRepository;
    private readonly IRepository<Route> _routesRepository;

    public GetAllCitiesQueryHandler(IRepository<City> citiesRepository, IRepository<Route> routesRepository)
    {
        _citiesRepository = citiesRepository;
        _routesRepository = routesRepository;
    }

    public async Task<IEnumerable<CityDTO>> Handle(GetAllCitiesRequest request, CancellationToken cancellationToken)
    {
        List<long>? reacheableCitiesIds = null;

        if (request.OriginId is long cityId)
        {
            reacheableCitiesIds = await _routesRepository.Query
                .Where(x => x.OriginId == cityId || x.DestinationId == cityId)
                .Select(x => x.OriginId == cityId ? x.DestinationId : x.OriginId)
                .Distinct()
                .ToListAsync(cancellationToken);
        }

        return await _citiesRepository.Query
            .Where(x => reacheableCitiesIds == null || reacheableCitiesIds.Contains(x.Id))
            .Select(x => new CityDTO
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Lon = x.Location.Lon,
                Lat = x.Location.Lat,
            })
            .ToArrayAsync(cancellationToken);
    }
}
