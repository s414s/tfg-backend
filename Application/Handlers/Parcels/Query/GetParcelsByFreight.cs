using Application.DTO;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Parcels.Query;

public sealed record GetParcelsByFreightRequest(long FreightId) : IRequest<IEnumerable<ParcelDTO>> { }

internal sealed class CreatePalletCommandHandler : IRequestHandler<GetParcelsByFreightRequest, IEnumerable<ParcelDTO>>
{
    private readonly IRepository<Parcel> _parcelsRepository;
    private readonly IRepository<Freight> _freightsRepository;

    public CreatePalletCommandHandler(IRepository<Parcel> palletsRepository, IRepository<Freight> freightsRepository)
    {
        _parcelsRepository = palletsRepository;
        _freightsRepository = freightsRepository;
    }

    public async Task<IEnumerable<ParcelDTO>> Handle(GetParcelsByFreightRequest request, CancellationToken cancellationToken)
    {
        if (!await _freightsRepository.Query.AnyAsync(x => x.Id == request.FreightId, cancellationToken))
            throw new EntityNotFoundException($"Freight with id {request.FreightId} could not be found");

        var x = await _parcelsRepository.Query
            .Where(x => x.FreightId == request.FreightId)
            .Select(x => new ParcelDTO
            {
                Id = x.Id,
                Guid = x.Guid,
                Weight = x.Weight,
                ETD = x.Freight.DueStart,
                ETA = x.Freight.GetETA(),
                Origin = x.Origin.Name,
                Destination = x.Destination.Name,
                ContactEmail = x.ContactEmail,
            })
            .ToListAsync(cancellationToken);

        return x;
    }
}

