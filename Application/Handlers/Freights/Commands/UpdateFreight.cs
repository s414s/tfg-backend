using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Application.Handlers.Freights.Commands;

public sealed record UpdateFreightRequest : IRequest<Unit>
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

internal sealed class UpdateFreightCommandHandler : IRequestHandler<UpdateFreightRequest, Unit>
{
    private readonly IRepository<Freight> _freightsRepository;
    public UpdateFreightCommandHandler(IRepository<Freight> freightsRepository)
    {
        _freightsRepository = freightsRepository;
    }

    public async Task<Unit> Handle(UpdateFreightRequest request, CancellationToken cancellationToken)
    {
        var freight = await _freightsRepository.Query
            .FirstOrDefaultAsync(x => x.Id == request.ShiftId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Freight));

        // TODO - update freight

        await _freightsRepository.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
