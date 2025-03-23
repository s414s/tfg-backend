using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Shifts.Commands;

public sealed record CreateShiftRequest(
    ShiftStatus Status,
    DateTime StartDate
    ) : IRequest
{ }

public class CreateShiftRequestValidator : AbstractValidator<CreateShiftRequest>
{
    public CreateShiftRequestValidator()
    {
        RuleFor(x => x.Status).IsInEnum()
            .WithMessage("{PropertyName} must have a valid value.");

        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(DateTime.Today.AddDays(1))
            .WithMessage("{PropertyName} shifts can only be sheduled one day in advance minimum.");
    }
}

internal sealed class CreateShiftCommandHandler : IRequestHandler<CreateShiftRequest>
{
    private readonly IRepository<Freight> _freightsRepository;

    public CreateShiftCommandHandler(IRepository<Freight> freightsRepository)
    {
        _freightsRepository = freightsRepository;
    }

    public async Task Handle(CreateShiftRequest request, CancellationToken cancellationToken)
    {
        await _freightsRepository
           .AddAndSaveChangesAsync(new Freight
           {
               DueStart = request.StartDate,
               Status = request.Status,
           });
    }
}
