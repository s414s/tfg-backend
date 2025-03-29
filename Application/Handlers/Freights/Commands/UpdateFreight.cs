using Application.Exceptions;
using Domain.Contracts;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Application.Handlers.Freights.Commands;

public sealed record UpdateFreightRequest : IRequest
{
    [JsonIgnore]
    public long ShiftId { get; init; }
    public IEnumerable<long> RouteIds { get; init; } = [];
}

public class UpdateFreightRequestValidator : AbstractValidator<UpdateFreightRequest>
{
    public UpdateFreightRequestValidator()
    {
        RuleFor(x => x.ShiftId)
            .NotEmpty()
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than 0.");
    }
}

internal sealed class UpdateFreightCommandHandler : IRequestHandler<UpdateFreightRequest>
{
    private readonly IRepository<Freight> _freightsRepository;
    public UpdateFreightCommandHandler(IRepository<Freight> freightsRepository)
    {
        _freightsRepository = freightsRepository;
    }

    public async Task Handle(UpdateFreightRequest request, CancellationToken cancellationToken)
    {
        var shift = await _freightsRepository.Query
            .FirstOrDefaultAsync(x => x.Id == request.ShiftId, cancellationToken)
            ?? throw new EntityNotFoundException($"Shift with id {request.ShiftId} could not be found");

        await _freightsRepository.SaveChangesAsync(cancellationToken);
    }
}
