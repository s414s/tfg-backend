using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Application.Handlers.Freights.Commands;

public sealed record CancelFreightRequest : IRequest<Unit>
{
    [JsonIgnore]
    public long FreightId { get; init; }
}

internal sealed class CancelFreightRequestHandler : IRequestHandler<CancelFreightRequest, Unit>
{
    private readonly IRepository<Freight> _freightsRepository;
    public CancelFreightRequestHandler(IRepository<Freight> freightsRepository)
    {
        _freightsRepository = freightsRepository;
    }

    public async Task<Unit> Handle(CancelFreightRequest request, CancellationToken cancellationToken)
    {
        var freight = await _freightsRepository.Query
            .FirstOrDefaultAsync(x => x.Id == request.FreightId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Freight));

        freight.Status = FreightStatus.Canceled;

        await _freightsRepository.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
