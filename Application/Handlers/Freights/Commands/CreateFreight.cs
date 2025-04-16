using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Freights.Commands;

public sealed record CreateFreightRequest() : IRequest
{
    public required long OriginId { get; init; }
    public required long DestinationId { get; init; }
    public required DateTime StartDate { get; init; }
    public required long DriverId { get; init; }
}

public class CreateFreightRequestValidator : AbstractValidator<CreateFreightRequest>
{
    public CreateFreightRequestValidator()
    {
        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(DateTime.Today.AddDays(1))
            .WithMessage("{PropertyName} shifts can only be sheduled one day in advance minimum.");
    }
}

internal sealed class CreateFreightCommandHandler : IRequestHandler<CreateFreightRequest>
{
    private readonly IRepository<Freight> _freightsRepository;
    private readonly IRepository<Route> _routesRepository;

    public CreateFreightCommandHandler(IRepository<Freight> freightsRepository, IRepository<Route> routesRepository)
    {
        _freightsRepository = freightsRepository;
        _routesRepository = routesRepository;
    }

    public async Task Handle(CreateFreightRequest request, CancellationToken cancellationToken)
    {
        if (DateTime.UtcNow.AddDays(1) - request.StartDate > TimeSpan.FromDays(1))
            throw new CustomException("You need to have at least one day notice to drivers");

        if (request.StartDate < DateTime.UtcNow)
            throw new CustomException("You can only plan future freights");

        var route = await _routesRepository.Query
            .FirstOrDefaultAsync(x =>
                (x.OriginId == request.OriginId || x.OriginId == request.DestinationId)
                && (x.DestinationId == request.OriginId || x.DestinationId == request.DestinationId)
            )
            ?? throw new EntityNotFoundException(nameof(Route));

        // TODO - check and assignd driver
        // TODO - make sure there is a driver assigned

        // TODO - assign truck from driver

        var newFreight = new Freight
        {
            DueStart = request.StartDate,
            StartCityId = request.OriginId,
            RouteId = route.Id,
            Status = FreightStatus.Active,
            DriverId = request.DriverId,
        };

        await _freightsRepository.AddAndSaveChangesAsync(newFreight);
    }
}
