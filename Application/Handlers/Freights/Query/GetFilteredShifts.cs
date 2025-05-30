using Application.DTO;
using Application.DTO.Base;
using Application.Extensions;
using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Freights.Query;

public sealed record GetFilteredFreightsRequest : PagedRequest, IRequest<PagedResults<FreightDTO>>
{
    public FreightStatus Status { get; init; } = FreightStatus.Active;
    public long? OriginId { get; init; }
    public long? DestinationId { get; init; }
    public long? DriverId { get; init; }
}

public class GetFilteredShiftsRequestValidator : AbstractValidator<GetFilteredFreightsRequest>
{
    public GetFilteredShiftsRequestValidator()
    {
        RuleFor(x => x.PageIndex)
            .NotEmpty()
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than 0.");

        RuleFor(x => x.PageSize)
            .NotEmpty()
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than 0.");
    }
}

internal sealed class GetFilteredFreightsQueryHandler : IRequestHandler<GetFilteredFreightsRequest, PagedResults<FreightDTO>>
{
    private readonly IRepository<Freight> _freightsRepository;

    public GetFilteredFreightsQueryHandler(IRepository<Freight> freightsRepository)
    {
        _freightsRepository = freightsRepository;
    }

    public async Task<PagedResults<FreightDTO>> Handle(GetFilteredFreightsRequest request, CancellationToken cancellationToken)
    {
        var query = _freightsRepository.Query
            .Where(x => request.OriginId == null || x.StartCityId == request.OriginId)
            .Where(x => request.DestinationId == null || x.Route.DestinationId == request.DestinationId || x.Route.OriginId == request.DestinationId)
            .Where(x => request.DriverId == null || x.DriverId == request.DriverId);

        if (request.Status is FreightStatus.Scheduled)
            query = query.Where(x => x.DueStart > DateTime.UtcNow && x.Status != FreightStatus.Canceled);

        if (request.Status is FreightStatus.Completed)
            query = query.Where(x => x.DueStart < DateTime.UtcNow && x.Status != FreightStatus.Canceled);

        if (request.Status is FreightStatus.Canceled)
            query = query.Where(x => x.Status == request.Status);

        if (request.Status is FreightStatus.Active)
            query = query.Where(x => x.DueStart < DateTime.UtcNow && x.Status != FreightStatus.Canceled);

        return await query
            .OrderBy(x => x.DueStart)
            .Select(x => new FreightDTO
            {
                Id = x.Id,
                Etd = x.DueStart,
                Status = request.Status,
                Origin = x.StartCity.Name,
                TotalDistance = x.Route.Distance * 2,
                DurationMinutes = x.Route.Duration.TotalMinutes,
                Eta = x.GetETA(),
                Destination = x.Route.DestinationId == x.StartCityId ? x.Route.Origin.Name : x.Route.Destination.Name,
                FuelCost = x.TotalFuelCost,
                DriverCost = x.TotalDriverCost,
                TotalCost = x.TotalCost,
                MoneyGenerated = x.Parcels.Sum(x => x.Price),
                Truck = new TruckDTO
                {
                    Id = x.Truck.Id,
                    Plate = x.Truck.Plate,
                    Consumption = x.Truck.Consumption,
                    ManufacturingDateUnix = x.Truck.ManufacturingDate.ToUnixTime(),
                    Mileage = x.Truck.Mileage,
                    Mark = x.Truck.Mark,
                    MaxWeight = x.Truck.MaxWeight,
                    LastMaintenanceDateUnix = x.Truck.LastMaintenance.ToUnixTime(),
                },
                Driver = new UserDTO
                {
                    Id = x.Id,
                    Name = x.Driver.Name,
                    Surname = x.Driver.Surname,
                    Email = x.Driver.Email,
                    Role = x.Driver.Role,
                },
            })
            .ToPagedResultsAsync(request.PageIndex, request.PageSize, cancellationToken);
    }
}
