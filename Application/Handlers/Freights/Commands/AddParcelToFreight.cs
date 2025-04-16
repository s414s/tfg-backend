using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Application.Handlers.Freights.Commands;

public sealed record AddParcelToFreightCommand() : IRequest
{
    [JsonIgnore]
    public long FreightId { get; init; }
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
    private readonly IRepository<City> _citiessRepository;

    public AddParcelToFreightCommandHandler(IRepository<Freight> freightsRepository, IRepository<City> citiesRepository)
    {
        _freightsRepository = freightsRepository;
        _citiessRepository = citiesRepository;
    }

    public async Task Handle(AddParcelToFreightCommand request, CancellationToken cancellationToken)
    {
        if (request.OriginId == request.DestinationId)
            throw new CustomException("Origin and destination cannot be the same location");

        if (!await _citiessRepository.Query.AnyAsync(x => x.Id == request.OriginId, cancellationToken))
            throw new CustomException("Origin does not exist");

        if (!await _citiessRepository.Query.AnyAsync(x => x.Id == request.DestinationId, cancellationToken))
            throw new CustomException("Destination does not exist");

        var freight = await _freightsRepository.Query
            .Include(x => x.Parcels)
            .Include(x => x.Truck)
            .Include(x => x.Route)
            .FirstOrDefaultAsync(x => x.Id == request.FreightId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Freight));

        if (freight.Status != FreightStatus.Scheduled)
            throw new CustomException("The freight is not available");

        // TODO - calculate price
        decimal priceRate = 0.15m;

        var newParcel = new Parcel
        {
            Price = (decimal)freight.GetTotalDistance() * priceRate, // TODO - calculate price
            Weight = request.ParcelWeight,
            FreightId = freight.Id,
            OriginId = request.OriginId,
            DestinationId = request.DestinationId,
        };

        // TODO - freight - add Parcel
        freight.AddParcel(newParcel);

        await _freightsRepository.SaveChangesAsync();
    }
}
