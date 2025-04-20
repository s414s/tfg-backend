using Application.Handlers.Trucks.Query;
using Application.Handlers.Users.Query;
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
    //public required DateTimeOffset StartDate { get; init; }
    public required DateTime StartDate { get; init; }
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
    private readonly IMediator _mediatr;

    public CreateFreightCommandHandler(
        IRepository<Freight> freightsRepository,
        IRepository<Route> routesRepository,
        IRepository<SettingsEntity> settingsRepository,
        IRepository<User> usersRepository,
        IMediator mediatr)
    {
        _freightsRepository = freightsRepository;
        _routesRepository = routesRepository;
        _settingsRepository = settingsRepository;
        _usersRepository = usersRepository;
        _mediatr = mediatr;
    }

    public async Task<Unit> Handle(CreateFreightRequest request, CancellationToken cancellationToken)
    {
        if (DateTime.UtcNow.AddDays(1) - request.StartDate > TimeSpan.FromDays(1))
            throw new CustomException("You need to have at least one day notice to drivers");

        if (request.StartDate < DateTime.UtcNow)
            throw new CustomException("You can only plan future freights");

        if (DateTime.UtcNow.AddDays(1) - request.StartDate > TimeSpan.FromDays(1))
            throw new CustomException("You need to have at least one day notice to drivers");

        var route = await _routesRepository.Query
            .FirstOrDefaultAsync(x =>
                (x.OriginId == request.OriginId || x.OriginId == request.DestinationId)
                && (x.DestinationId == request.OriginId || x.DestinationId == request.DestinationId)
            )
            ?? throw new EntityNotFoundException(nameof(Route));

        var availableDrivers = await _mediatr.Send(new GetUsersRequest
        {
            Role = UserRoles.Driver,
            StartDate = request.StartDate,
            //StartDate = request.StartDate.UtcDateTime,
            EndDate = request.StartDate.Add(route.Duration),
            //EndDate = request.StartDate.UtcDateTime.Add(route.Duration),
        }, cancellationToken);

        if (!availableDrivers.Data.Any())
            throw new CustomException("No drivers available");

        var availableTrucks = await _mediatr.Send(new GetFilteredTrucksRequest
        {
            StartDate = request.StartDate,
            //StartDate = request.StartDate.UtcDateTime,
            EndDate = request.StartDate.Add(route.Duration),
            //EndDate = request.StartDate.UtcDateTime.Add(route.Duration),
        }, cancellationToken);

        if (!availableTrucks.Data.Any())
            throw new CustomException("No trucks available");

        // Treat the incoming DateTime as already UTC:
        //var dueUtc = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc);
        var dueUtcDto = new DateTimeOffset(request.StartDate, TimeSpan.Zero);
        Console.WriteLine($"Saving DueStart = {dueUtcDto:O} (Offset = {dueUtcDto.Offset})");

        var newFreight = new Freight
        {
            //DueStart = request.StartDate.ToUniversalTime(),
            //DueStart = new DateTime(request.StartDate.Year, request.StartDate.Month, request.StartDate.Day),
            //DueStart = new DateTime(request.StartDate.Year, request.StartDate.Month, request.StartDate.Day, 09, 30, 00, DateTimeKind.Utc),
            //DueStart = request.StartDate,
            DueStart = dueUtcDto.UtcDateTime,
            StartCityId = request.OriginId,
            RouteId = route.Id,
            Status = FreightStatus.Scheduled,
            DriverId = availableDrivers.Data[0].Id,
            TruckId = availableTrucks.Data[0].Id,
            PricePerDriverHour = (await _settingsRepository.Query.FirstAsync(cancellationToken)).PricePerHourDriver,
            PricePerLiterFuel = (await _settingsRepository.Query.FirstAsync(cancellationToken)).PricePerLiterFuel,
        };

        await _freightsRepository.AddAsync(newFreight, cancellationToken);
        await _freightsRepository.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
