using Application.Exceptions;
using Domain.Contracts;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Application.Handlers.Shifts.Commands;

public sealed record UpdateShiftRequest : IRequest
{
    [JsonIgnore]
    public long ShiftId { get; init; }
    public IEnumerable<long> RouteIds { get; init; }
}

public class UpdateShiftRequestValidator : AbstractValidator<UpdateShiftRequest>
{
    public UpdateShiftRequestValidator()
    {
        RuleFor(x => x.ShiftId)
            .NotEmpty()
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than 0.");
    }
}

internal sealed class UpdateShiftCommandHandler : IRequestHandler<UpdateShiftRequest>
{
    private readonly IRepository<Shift> _shiftsRepository;
    public UpdateShiftCommandHandler(IRepository<Shift> shiftsRepository)
    {
        _shiftsRepository = shiftsRepository;
    }

    public async Task Handle(UpdateShiftRequest request, CancellationToken cancellationToken)
    {
        var shift = await _shiftsRepository.Query
            .FirstOrDefaultAsync(x => x.Id == request.ShiftId, cancellationToken)
            ?? throw new EntityNotFoundException($"Shift with id {request.ShiftId} could not be found");

        await _shiftsRepository.SaveChangesAsync(cancellationToken);
    }
}
