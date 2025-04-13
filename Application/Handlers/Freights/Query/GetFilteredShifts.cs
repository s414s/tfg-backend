using Application.DTO;
using Application.DTO.Base;
using Application.Extensions;
using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Freights.Query;

public sealed record GetFilteredFreightsRequest(
    FreightStatus? Status,
    long? OriginId,
    long? DestinationId
    ) : PagedRequest, IRequest<PagedResults<FreightDTO>>
{ }

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
        return await _freightsRepository.Query
            .Where(x => request.Status == null || x.Status == request.Status)
            .Where(x => request.OriginId == null || x.StartCityId == request.OriginId)
            .Where(x => request.DestinationId == null || x.Route.DestinationId == request.DestinationId || x.Route.OriginId == request.DestinationId)
            .OrderByDescending(x => x.DueStart)
            .Select(x => new FreightDTO
            {
                Id = x.Id,
                DueStart = x.DueStart,
                Status = x.Status,
                Origin = x.StartCity.Name,
                Destination = x.StartCity.Name, // TODO - change this 
                Truck = new TruckDTO
                {
                    Id = x.Truck.Id,
                    Plate = x.Truck.Plate,
                    Consumption = x.Truck.Consumption,
                    ManufacturingDateUnix = x.Truck.ManufacturingDate.ToUnixTime(),
                    Mileage = x.Truck.Mileage,
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
