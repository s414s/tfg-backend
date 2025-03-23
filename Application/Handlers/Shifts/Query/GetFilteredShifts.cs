using Application.DTO;
using Application.DTO.Base;
using Application.Extensions;
using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using MediatR;

namespace Application.Handlers.Shifts.Query;

public sealed record GetFilteredShiftsRequest(
    ShiftStatus? Status
    ) : PagedRequest, IRequest<PagedResults<ShiftDTO>>
{ }

public class GetFilteredShiftsRequestValidator : AbstractValidator<GetFilteredShiftsRequest>
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

internal sealed class GetFilteredShiftsQueryHandler : IRequestHandler<GetFilteredShiftsRequest, PagedResults<ShiftDTO>>
{
    private readonly IRepository<Freight> _freightsRepository;

    public GetFilteredShiftsQueryHandler(IRepository<Freight> freightsRepository)
    {
        _freightsRepository = freightsRepository;
    }

    public async Task<PagedResults<ShiftDTO>> Handle(GetFilteredShiftsRequest request, CancellationToken cancellationToken)
    {
        return await _freightsRepository.Query
            //.Where(x => request.Status == null || x.Status == request.Status)
            .Where(x => request.Status == null)
            //.OrderBy(x => x.StartDate)
            .Select(x => new ShiftDTO
            {
                Id = x.Id,
                Status = ShiftStatus.Active, // TODO
                Truck = new TruckDTO
                {
                    Id = x.Truck.Id,
                    Plate = x.Truck.Plate,
                    CurrentLocation = new LocationDTO { Lat = 1, Lon = 2 },
                },
                Driver = new UserDTO
                {
                    Id = x.Id,
                    Name = x.Driver.Name,
                    Surname = x.Driver.Surname,
                    Email = $"{x.Driver.Surname}@gmail.com",
                    Role = x.Driver.Role,
                },
                Route = "TODO",
            })
            .ToPagedResultsAsync(request.PageIndex, request.PageSize, cancellationToken);
    }
}
