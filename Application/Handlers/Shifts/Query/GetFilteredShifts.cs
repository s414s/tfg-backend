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
    private readonly IRepository<Shift> _shiftsRepository;

    public GetFilteredShiftsQueryHandler(IRepository<Shift> shiftsRepository)
    {
        _shiftsRepository = shiftsRepository;
    }

    public async Task<PagedResults<ShiftDTO>> Handle(GetFilteredShiftsRequest request, CancellationToken cancellationToken)
    {
        return await _shiftsRepository.Query
            .Where(x => request.Status == null || x.Status == request.Status)
            .OrderBy(x => x.StartDate)
            .Select(x => new ShiftDTO
            {
                Id = x.Id,
                Status = x.Status,
                Truck = new TruckDTO
                {
                    Id = x.Truck.Id,
                    Plate = x.Truck.Plate,
                },
                Driver = new UserDTO
                {
                    Id = x.Id,
                    Name = x.Truck.Driver.Name,
                    Surname = x.Truck.Driver.Surname,
                    Role = x.Truck.Driver.Role,
                }
            })
            .ToPagedResultsAsync(request.PageIndex, request.PageSize, cancellationToken);
    }
}
