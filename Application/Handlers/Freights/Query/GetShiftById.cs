using Application.DTO;
using Application.Extensions;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Freights.Query;

public sealed record GetFreightByIdRequest(long FreightId) : IRequest<FreightDTO> { }

public class GetFreightByIdRequestValidator : AbstractValidator<GetFreightByIdRequest>
{
    public GetFreightByIdRequestValidator()
    {
        RuleFor(x => x.FreightId)
            .NotEmpty()
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than 0.");
    }
}

internal sealed class GetFreightByIdQueryHandler : IRequestHandler<GetFreightByIdRequest, FreightDTO>
{
    private readonly IRepository<Freight> _freightsRepository;

    public GetFreightByIdQueryHandler(IRepository<Freight> freightsRepository)
    {
        _freightsRepository = freightsRepository;
    }

    public async Task<FreightDTO> Handle(GetFreightByIdRequest request, CancellationToken cancellationToken)
    {
        return await _freightsRepository.Query
            .Where(x => x.Id == request.FreightId)
            .Select(x => new FreightDTO
            {
                Id = x.Id,
                Status = x.Status,
                Etd = x.DueStart,
                Origin = x.StartCity.Name,
                TotalDistance = x.Route.Distance * 2,
                DurationMinutes = x.Route.Duration.TotalMinutes,
                Eta = x.GetETA(),
                Destination = x.Route.DestinationId == x.StartCityId ? x.Route.Origin.Name : x.Route.Destination.Name,
                FuelCost = x.TotalFuelCost,
                DriverCost = x.TotalDriverCost,
                TotalCost = x.TotalCost,
                Truck = new TruckDTO
                {
                    Id = x.Truck.Id,
                    Plate = x.Truck.Plate,
                    Mark = x.Truck.Mark,
                    Consumption = x.Truck.Consumption,
                    Mileage = x.Truck.Mileage,
                    ManufacturingDateUnix = x.Truck.ManufacturingDate.ToUnixTime(),
                    LastMaintenanceDateUnix = x.Truck.LastMaintenance.ToUnixTime(),
                },
                Driver = new UserDTO
                {
                    Id = x.Id,
                    Name = x.Driver.Name,
                    Surname = x.Driver.Surname,
                    Email = $"{x.Driver.Surname}@gmail.com",
                    Role = x.Driver.Role,
                }
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException($"Shift with id {request.FreightId} could not be found");
    }
}
