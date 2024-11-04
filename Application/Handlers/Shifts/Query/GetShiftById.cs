using Application.DTO;
using Domain.Contracts;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Shifts.Query;

public sealed record GetShiftByIdRequest(long ShiftId) : IRequest<ShiftDTO> { }

public class GetShiftByIdRequestValidator : AbstractValidator<GetShiftByIdRequest>
{
    public GetShiftByIdRequestValidator()
    {
        RuleFor(x => x.ShiftId)
            .NotEmpty()
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than 0.");
    }
}

internal sealed class GetShiftByIdQueryHandler : IRequestHandler<GetShiftByIdRequest, ShiftDTO>
{
    private readonly IRepository<Shift> _shiftsRepository;

    public GetShiftByIdQueryHandler(IRepository<Shift> shiftsRepository)
    {
        _shiftsRepository = shiftsRepository;
    }

    public async Task<ShiftDTO> Handle(GetShiftByIdRequest request, CancellationToken cancellationToken)
    {
        return await _shiftsRepository.Query
            .Where(x => x.Id == request.ShiftId)
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
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new Exception();
    }
}
