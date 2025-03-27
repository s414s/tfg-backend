using Domain.Contracts;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Application.Handlers.Shifts.Commands;

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
            .Where(x => x.Id == request.FreightId)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new Exception("Freight not found"); // TODO - custom exception

        // TODO - check that there is a lorry assigned
        if (freight.Truck is null)
            throw new Exception("No truck assigned"); // TODO

        // TODO - check if there is still room
        if (freight.GetTotalWeight() + request.ParcelWeight > freight.Truck.MaxWeight)
            throw new Exception("there is not enough room"); // TODO

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
