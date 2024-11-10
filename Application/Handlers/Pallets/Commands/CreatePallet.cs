using Application.Exceptions;
using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Application.Handlers.Pallets.Commands;

public sealed record CreatePalletRequest : IRequest
{
    [JsonIgnore]
    public long ShiftId { get; init; }
    public PalletType Type { get; init; }
}

public class CreatePalletCommandRequestValidator : AbstractValidator<CreatePalletRequest>
{
    public CreatePalletCommandRequestValidator()
    {
        RuleFor(x => x.ShiftId)
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than 0.");

        RuleFor(x => x.Type)
            .IsInEnum()
            .WithMessage("{PropertyName} must be a valid value.");
    }
}

internal sealed class CreatePalletCommandHandler : IRequestHandler<CreatePalletRequest>
{
    private readonly IRepository<Pallet> _palletsRepository;
    private readonly IRepository<Shift> _shiftsRepository;

    public CreatePalletCommandHandler(
        IRepository<Pallet> palletsRepository,
        IRepository<Shift> shiftsRepository)
    {
        _palletsRepository = palletsRepository;
        _shiftsRepository = shiftsRepository;
    }

    public async Task Handle(CreatePalletRequest request, CancellationToken cancellationToken)
    {
        if (!await _shiftsRepository.Query.AnyAsync(x => x.Id == request.ShiftId, cancellationToken))
            throw new EntityNotFoundException($"Shift with id {request.ShiftId} could not be found");

        var newPallet = Pallet.New(request.Type, request.ShiftId);
        await _palletsRepository.AddAndSaveChangesAsync(newPallet, cancellationToken);
    }
}
