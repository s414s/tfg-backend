using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Freights.Commands;

public sealed record CreateFreightRequest() : IRequest<Unit>
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

internal sealed class CreateFreightCommandHandler : IRequestHandler<CreateFreightRequest, Unit>
{
    private readonly IRepository<Freight> _freightsRepository;
    private readonly IRepository<Route> _routesRepository;
    private readonly IRepository<SettingsEntity> _settingsRepository;
    private readonly IRepository<User> _usersRepository;

    public CreateFreightCommandHandler(
        IRepository<Freight> freightsRepository,
        IRepository<Route> routesRepository,
        IRepository<SettingsEntity> settingsRepository,
        IRepository<User> usersRepository)
    {
        _freightsRepository = freightsRepository;
        _routesRepository = routesRepository;
        _settingsRepository = settingsRepository;
        _usersRepository = usersRepository;
    }

    public async Task<Unit> Handle(CreateFreightRequest request, CancellationToken cancellationToken)
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

        if (DateTime.UtcNow.AddDays(1) - request.StartDate > TimeSpan.FromDays(1))
            throw new CustomException("You need to have at least one day notice to drivers");

        if (!await _usersRepository.Query.AnyAsync(x => x.Id == request.DriverId && x.Role == UserRoles.Driver, cancellationToken))
            throw new EntityNotFoundException(nameof(User));

        // TODO - assign truck from driver

        var newFreight = new Freight
        {
            DueStart = request.StartDate,
            StartCityId = request.OriginId,
            RouteId = route.Id,
            Status = FreightStatus.Active,
            DriverId = request.DriverId,
            TruckId = 1, // TODO
            PricePerDriverHour = (await _settingsRepository.Query.FirstAsync(cancellationToken)).PricePerHourDriver,
            PricePerLiterFuel = (await _settingsRepository.Query.FirstAsync(cancellationToken)).PricePerLiterFuel,
        };

        await _freightsRepository.AddAndSaveChangesAsync(newFreight);
        return Unit.Value;
    }
}
