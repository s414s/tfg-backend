using Application.DTO;
using Domain.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Routes.Query;

public record GetFilteredRoutesRequest : IRequest<IEnumerable<RouteDTO>>
{
    public string? Origin { get; init; }
    public string? Destination { get; init; }
}

internal sealed class GetFilteredRoutesQueryHandler : IRequestHandler<GetFilteredRoutesRequest, IEnumerable<RouteDTO>>
{
    private readonly IRepository<Route> _routesRepository;

    public GetFilteredRoutesQueryHandler(IRepository<Route> routesRepository)
    {
        _routesRepository = routesRepository;
    }

    public async Task<IEnumerable<RouteDTO>> Handle(GetFilteredRoutesRequest request, CancellationToken cancellationToken)
    {
        return await _routesRepository.Query
            .Where(x => request.Origin == null
                || x.Origin.Name == request.Origin
                || x.Destination.Name == request.Origin)
            .Where(x => request.Destination == null
                || x.Destination.Name == request.Destination
                || x.Origin.Name == request.Destination)
            .Select(x => new RouteDTO
            {
                Id = x.Id,
                Distance = x.Distance,
                Origin = request.Origin ?? x.Origin.Name,
                Destination = request.Destination ?? x.Destination.Name,
            })
            .ToArrayAsync(cancellationToken);
    }
}
