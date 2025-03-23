using Application.DTO;
using Application.Exceptions;
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
    private readonly IRepository<Freight> _freightsRepository;

    public GetShiftByIdQueryHandler(IRepository<Freight> freightsRepository)
    {
        _freightsRepository = freightsRepository;
    }

    public async Task<ShiftDTO> Handle(GetShiftByIdRequest request, CancellationToken cancellationToken)
    {
        return await _freightsRepository.Query
            .Where(x => x.Id == request.ShiftId)
            .Select(x => new ShiftDTO
            {
                Id = x.Id,
                Status = Domain.Enums.ShiftStatus.Canceled, // TODO
                Route = "TODO",
                Truck = new TruckDTO
                {
                    Id = x.Truck.Id,
                    Plate = x.Truck.Plate,
                    CurrentLocation = new LocationDTO { Lat = 1, Lon = 1 },
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
            ?? throw new EntityNotFoundException($"Shift with id {request.ShiftId} could not be found");
    }
}
