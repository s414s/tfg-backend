using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Trucks.Commands;

public sealed record CreateNewTruckCommandRequest : IRequest<bool>
{
    public string Plate { get; init; } = string.Empty;
    public decimal Mileage { get; init; }
    public decimal Consumption { get; init; }
    public decimal MaxWeight { get; init; }
    public string Mark { get; init; } = string.Empty;
    public DateTime LastMaintenance { get; init; }
    public DateTime ManufacturingDate { get; init; }
}

public class GetFilteredTrucksRequestValidator : AbstractValidator<CreateNewTruckCommandRequest>
{
    public GetFilteredTrucksRequestValidator()
    {
        RuleFor(x => x.Plate).NotEmpty().WithMessage("{PropertyName} is required.");
        RuleFor(x => x.Mark).NotEmpty().WithMessage("{PropertyName} is required.");
        RuleFor(x => x.Mileage).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        RuleFor(x => x.Consumption).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        RuleFor(x => x.MaxWeight).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
    }
}

internal sealed class GetFilteredTruckRequestHandler : IRequestHandler<CreateNewTruckCommandRequest, bool>
{
    private readonly IRepository<Truck> _trucksRepository;

    public GetFilteredTruckRequestHandler(IRepository<Truck> trucksRepository)
    {
        _trucksRepository = trucksRepository;
    }

    public async Task<bool> Handle(CreateNewTruckCommandRequest request, CancellationToken cancellationToken)
    {
        if (await _trucksRepository.Query.AnyAsync(x => x.Plate == request.Plate, cancellationToken))
            throw new CustomException("A truck with the same plate number already exists");

        if (request.ManufacturingDate >= DateTime.UtcNow)
            throw new CustomException("A truck can not be manufactured in the future");

        if (request.LastMaintenance >= DateTime.UtcNow)
            throw new CustomException("A trucks last maintenance can not be in the future");

        var newTruck = new Truck
        {
            Plate = request.Plate,
            Mileage = request.Mileage,
            Consumption = request.Consumption,
            Mark = request.Mark,
            MaxWeight = request.MaxWeight,
            ManufacturingDate = DateTime.SpecifyKind(request.ManufacturingDate, DateTimeKind.Unspecified),
            LastMaintenance = DateTime.SpecifyKind(request.LastMaintenance, DateTimeKind.Unspecified),
        };

        await _trucksRepository.AddAsync(newTruck, cancellationToken);
        return await _trucksRepository.SaveChangesAsync(cancellationToken);
    }
}
