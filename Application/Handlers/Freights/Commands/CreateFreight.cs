using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Freights.Commands;

public sealed record CreateFreightRequest() : IRequest
{
    public required ShiftStatus Status { get; init; }
    public required DateTime StartDate { get; init; }
    public IEnumerable<long> RoutesIds { get; init; } = [];
}

public class CreateFreightRequestValidator : AbstractValidator<CreateFreightRequest>
{
    public CreateFreightRequestValidator()
    {
        RuleFor(x => x.Status).IsInEnum()
            .WithMessage("{PropertyName} must have a valid value.");

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
        if (request.RoutesIds.Distinct().Count() != request.RoutesIds.Count())
            throw new Exception("Duplicated routes"); // TODO - custom exception

        var routes = await _routesRepository.Query
            .Where(x => request.RoutesIds.Contains(x.Id))
            .Distinct()
            .ToArrayAsync(cancellationToken);

        if (routes.Count() != request.RoutesIds.Count())
            throw new Exception("some routes do not exist"); // TODO - custom exception

        await _freightsRepository
           .AddAndSaveChangesAsync(new Freight
           {
               DueStart = request.StartDate,
               Status = request.Status,
               FreightRoutes = routes.Select(x => new FreightRoute
               {
                   RouteId = x.Id,
               }).ToArray(),
           });
    }
}
