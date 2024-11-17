using Application.DTO;
using Domain.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Routes.Query;

public sealed record GetAllCitiesRequest : IRequest<IEnumerable<CityDTO>> { }

internal sealed class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesRequest, IEnumerable<CityDTO>>
{
    private readonly IRepository<City> _citiesRepository;

    public GetAllCitiesQueryHandler(IRepository<City> citiesRepository)
    {
        _citiesRepository = citiesRepository;
    }

    public async Task<IEnumerable<CityDTO>> Handle(GetAllCitiesRequest request, CancellationToken cancellationToken)
    {
        return await _citiesRepository.Query
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
