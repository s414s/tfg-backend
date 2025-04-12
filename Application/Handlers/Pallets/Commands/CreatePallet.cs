using Application.Exceptions;
using Domain.Contracts;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Application.Handlers.Pallets.Commands;

public sealed record CreatePalletRequest : IRequest
{
    [JsonIgnore]
    public long ShiftId { get; init; }
}

public class CreatePalletCommandRequestValidator : AbstractValidator<CreatePalletRequest>
{
    public CreatePalletCommandRequestValidator()
    {
        RuleFor(x => x.ShiftId)
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than 0.");
    }
}

internal sealed class CreatePalletCommandHandler : IRequestHandler<CreatePalletRequest>
{
    private readonly IRepository<Parcel> _palletsRepository;
    private readonly IRepository<Freight> _freightsRepository;

    public CreatePalletCommandHandler(
        IRepository<Parcel> palletsRepository,
        IRepository<Freight> freightsRepository)
    {
        _palletsRepository = palletsRepository;
        _freightsRepository = freightsRepository;
    }

    public async Task Handle(CreatePalletRequest request, CancellationToken cancellationToken)
    {
        if (!await _freightsRepository.Query.AnyAsync(x => x.Id == request.ShiftId, cancellationToken))
            throw new EntityNotFoundException($"Shift with id {request.ShiftId} could not be found");

        var newPallet = Parcel.Create(request.ShiftId);
        await _palletsRepository.AddAndSaveChangesAsync(newPallet, cancellationToken);
    }
}
