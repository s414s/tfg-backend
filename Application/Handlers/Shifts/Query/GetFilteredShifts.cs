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
    ) : PagedRequest, IRequest<PagedResults<FreightDTO>>
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

internal sealed class GetFilteredShiftsQueryHandler : IRequestHandler<GetFilteredShiftsRequest, PagedResults<FreightDTO>>
{
    private readonly IRepository<Freight> _freightsRepository;

    public GetFilteredShiftsQueryHandler(IRepository<Freight> freightsRepository)
    {
        _freightsRepository = freightsRepository;
    }

    public async Task<PagedResults<FreightDTO>> Handle(GetFilteredShiftsRequest request, CancellationToken cancellationToken)
    {
        return await _freightsRepository.Query
            //.Where(x => request.Status == null || x.Status == request.Status)
            .Where(x => request.Status == null)
            .OrderBy(x => x.DueStart)
            .Select(x => new FreightDTO
            {
                Id = x.Id,
                DueStart = x.DueStart,
                Status = ShiftStatus.Active, // TODO
                Truck = new TruckDTO
                {
                    Id = x.Truck.Id,
                    Plate = x.Truck.Plate,
                },
                Driver = new UserDTO
                {
                    Id = x.Id,
                    Name = x.Driver.Name,
                    Surname = x.Driver.Surname,
                    Email = $"{x.Driver.Surname}@gmail.com",
                    Role = x.Driver.Role,
                },
                //Routes = [], // TODO
                //Parcels = [], // TODO
            })
            .ToPagedResultsAsync(request.PageIndex, request.PageSize, cancellationToken);
    }
}
