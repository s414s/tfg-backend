using Application.DTO;
using Application.Exceptions;
using Domain.Contracts;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Trucks.Query;

public sealed record GetTruckByIdRequest(long TruckId) : IRequest<TruckDTO> { }

public class GetTruckByIdRequestValidator : AbstractValidator<GetTruckByIdRequest>
{
    public GetTruckByIdRequestValidator()
    {
        RuleFor(x => x.TruckId)
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} must be greater than 1.");
    }
}

internal sealed class GetTruckByIdRequestHandler : IRequestHandler<GetTruckByIdRequest, TruckDTO>
{
    private readonly IRepository<Truck> _trucksRepository;

    public GetTruckByIdRequestHandler(IRepository<Truck> trucksRepository)
    {
        _trucksRepository = trucksRepository;
    }

    public async Task<TruckDTO> Handle(GetTruckByIdRequest request, CancellationToken cancellationToken)
    {
        return await _trucksRepository.Query
            .Where(x => x.Id == request.TruckId)
            .Select(x => new TruckDTO
            {
                Id = x.Id,
                Plate = x.Plate,
                Mileage = x.Mileage,
                Consumption = x.Consumption,
                DriverName = x.Driver.Name,
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException($"Truck with id {request.TruckId} could not be found");
    }
}
