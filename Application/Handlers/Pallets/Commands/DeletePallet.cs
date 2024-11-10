using Application.Exceptions;
using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Pallets.Commands;

public sealed record DeletePalletRequest(long PalletId) : IRequest { }

public class DeletePalletRequestValidator : AbstractValidator<DeletePalletRequest>
{
    public DeletePalletRequestValidator()
    {
        RuleFor(x => x.PalletId)
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than 0.");
    }
}

internal sealed class DeletePalletCommandHandler : IRequestHandler<DeletePalletRequest>
{
    private readonly IRepository<Pallet> _palletsRepository;
    private readonly IRepository<Shift> _shiftsRepository;

    public DeletePalletCommandHandler(
        IRepository<Pallet> palletsRepository,
        IRepository<Shift> shiftsRepository)
    {
        _palletsRepository = palletsRepository;
        _shiftsRepository = shiftsRepository;
    }

    public async Task Handle(DeletePalletRequest request, CancellationToken cancellationToken)
    {
        var pallet = await _palletsRepository.Query
            .FirstOrDefaultAsync(x => x.Id == request.PalletId, cancellationToken)
            ?? throw new EntityNotFoundException($"Pallet with id {request.PalletId} could not be found");

        var shift = await _shiftsRepository.Query
            .FirstOrDefaultAsync(x => x.Id == pallet.ShiftId, cancellationToken)
            ?? throw new EntityNotFoundException($"Shift with id {pallet.ShiftId} could not be found");

        if (shift.Status != ShiftStatus.Scheduled)
            throw new ShiftStatusException($"A shift must be in status {nameof(ShiftStatus.Scheduled)}");

        await _palletsRepository.RemoveAsync(request.PalletId);
        await _palletsRepository.SaveChangesAsync(cancellationToken);
    }
}
