using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Parcels.Commands;

public sealed record DeletePalletRequest(long PalletId) : IRequest<Unit> { }

public class DeletePalletRequestValidator : AbstractValidator<DeletePalletRequest>
{
    public DeletePalletRequestValidator()
    {
        RuleFor(x => x.PalletId)
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than 0.");
    }
}

internal sealed class DeletePalletCommandHandler : IRequestHandler<DeletePalletRequest, Unit>
{
    private readonly IRepository<Parcel> _parcelsRepository;
    private readonly IRepository<Freight> _freightsRepository;

    public DeletePalletCommandHandler(IRepository<Parcel> parcelsRepository, IRepository<Freight> freightsRepository)
    {
        _parcelsRepository = parcelsRepository;
        _freightsRepository = freightsRepository;
    }

    public async Task<Unit> Handle(DeletePalletRequest request, CancellationToken cancellationToken)
    {
        var parcel = await _parcelsRepository.Query
            .FirstOrDefaultAsync(x => x.Id == request.PalletId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Parcel));

        var shift = await _freightsRepository.Query
            .FirstOrDefaultAsync(x => x.Id == parcel.FreightId, cancellationToken)
            ?? throw new EntityNotFoundException($"Shift with id {parcel.FreightId} could not be found");

        if (shift.Status != FreightStatus.Scheduled)
            throw new CustomException($"A shift must be in status {nameof(FreightStatus.Scheduled)}");

        await _parcelsRepository.RemoveAsync(request.PalletId);
        await _parcelsRepository.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
