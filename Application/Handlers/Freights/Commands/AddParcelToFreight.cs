using Domain.Contracts;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Application.Handlers.Freights.Commands;

public sealed record AddParcelToFreightCommand() : IRequest
{
    [JsonIgnore]
    public required long FreightId { get; init; }
    public required decimal ParcelWeight { get; init; }
    public required long OriginId { get; init; }
    public required long DestinationId { get; init; }
}

public class AddParcelToFreightCommandValidator : AbstractValidator<AddParcelToFreightCommand>
{
    public AddParcelToFreightCommandValidator()
    {
        RuleFor(x => x.ParcelWeight).GreaterThan(0);
    }
}

internal sealed class AddParcelToFreightCommandHandler : IRequestHandler<AddParcelToFreightCommand>
{
    private readonly IRepository<Freight> _freightsRepository;
    private readonly IRepository<Route> _routesRepository;
    private readonly IRepository<City> _citiessRepository;
    private readonly IRepository<FreightRoute> _freightRouteRepository;

    public AddParcelToFreightCommandHandler(IRepository<Freight> freightsRepository, IRepository<Route> routesRepository, IRepository<City> citiessRepository)
    {
        _freightsRepository = freightsRepository;
        _routesRepository = routesRepository;
        _citiessRepository = citiessRepository;
    }

    public async Task Handle(AddParcelToFreightCommand request, CancellationToken cancellationToken)
    {
        var origin = await _citiessRepository.Query.Where(x => x.Id == request.OriginId).FirstOrDefaultAsync(cancellationToken)
            ?? throw new Exception("Origin does not exist"); // TODO - custom exception

        var destination = await _citiessRepository.Query.Where(x => x.Id == request.OriginId).FirstOrDefaultAsync(cancellationToken)
            ?? throw new Exception("Destination does not exist"); // TODO - custom exception

        var freight = await _freightsRepository.Query
            .Include(x => x.Parcels)
            .Include(x => x.Truck)
            .FirstOrDefaultAsync(x => x.Id == request.FreightId, cancellationToken)
            ?? throw new Exception("Freight not found"); // TODO - custom exception

        // TODO - check that there is a lorry assigned
        if (freight.Truck is null)
            throw new Exception("No truck assigned"); // TODO - custom exception

        // TODO - check if there is still room
        if (freight.GetTotalWeight() + request.ParcelWeight > freight.Truck.MaxWeight)
            throw new Exception("there is not enough room"); // TODO - custom exception

        // TODO - check the freight is going from the origin to the destination
        var routesIds = freight.FreightRoutes.Select(x => x.RouteId);
        var cities = await _freightRouteRepository.Query
            .Where(x => routesIds.Contains(x.RouteId))
            .Select(x => new { x.Route.OriginId, x.Route.DestinationId })
            .ToListAsync(cancellationToken);

        if (!cities.Exists(x => x.OriginId == request.OriginId) || !cities.Exists(x => x.DestinationId == request.DestinationId))
            throw new Exception("the freight is not going through the cities required"); // TODO - custom exception

        // TODO - calculate price

        // TODO - check for route price euro/km

        var newParcel = new Parcel
        {
            Price = 10, // TODO
            Weight = request.ParcelWeight,
        };

        freight.Parcels.Add(newParcel);

        await _freightsRepository.SaveChangesAsync();
    }
}
