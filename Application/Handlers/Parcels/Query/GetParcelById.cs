using Application.DTO;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Parcels.Query;

public sealed record GetParcelByIdRequest(long ParcelId) : IRequest<ParcelDTO> { }

internal sealed class GetParcelByIdQueryHandler : IRequestHandler<GetParcelByIdRequest, ParcelDTO>
{
    private readonly IRepository<Parcel> _parcelsRepository;

    public GetParcelByIdQueryHandler(IRepository<Parcel> palletsRepository)
    {
        _parcelsRepository = palletsRepository;
    }

    public async Task<ParcelDTO> Handle(GetParcelByIdRequest request, CancellationToken cancellationToken)
    {
        return await _parcelsRepository.Query
            .Where(x => x.Id == request.ParcelId)
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
                Price = x.Price,
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Parcel));
    }
}

