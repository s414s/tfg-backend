using Application.DTO;
using Application.DTO.Base;
using Application.Extensions;
using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.Handlers.Trucks.Query;

public sealed record GetFilteredTrucksRequest : SortedRequest, IRequest<PagedResults<TruckDTO>>
{
    public bool? IsAvailable { get; init; }
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public FreightStatus? Status { get; init; }
}

public class GetFilteredTrucksRequestValidator : AbstractValidator<GetFilteredTrucksRequest>
{
    public GetFilteredTrucksRequestValidator()
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

internal sealed class GetFilteredTruckRequestHandler : IRequestHandler<GetFilteredTrucksRequest, PagedResults<TruckDTO>>
{
    private readonly IRepository<Truck> _trucksRepository;
    private readonly IRepository<Freight> _freightsRepository;

    public GetFilteredTruckRequestHandler(IRepository<Truck> trucksRepository, IRepository<Freight> freightsRepository)
    {
        _trucksRepository = trucksRepository;
        _freightsRepository = freightsRepository;
    }

    public async Task<PagedResults<TruckDTO>> Handle(GetFilteredTrucksRequest request, CancellationToken cancellationToken)
    {
        List<long>? unavailableTrucksIds = null;

        if (request.StartDate is DateTime start && request.EndDate is DateTime end)
        {
            var scheduledFreights = await _freightsRepository.Query
               .Include(x => x.Route)
               .Where(x => x.Status == FreightStatus.Scheduled)
               .ToListAsync(cancellationToken);

            unavailableTrucksIds = scheduledFreights
                 .Where(x => (x.DueStart > start && x.GetETA() > start) || (x.DueStart > end && x.GetETA() > end))
                 .Select(x => x.DriverId)
                 .Distinct()
                 .ToList();
        }

        return await _trucksRepository.Query
            .Where(x => unavailableTrucksIds == null || !unavailableTrucksIds.Contains(x.Id))
            .ApplyOrder(request.OrderBy, request.IsDescending)
            .Select(x => new TruckDTO
            {
                Id = x.Id,
                Plate = x.Plate,
                Mileage = x.Mileage,
                Consumption = x.Consumption,
                MaxWeight = x.MaxWeight,
                Mark = x.Mark,
                LastMaintenanceDateUnix = x.LastMaintenance.ToUnixTime(),
                ManufacturingDateUnix = x.ManufacturingDate.ToUnixTime(),
            })
            .ToPagedResultsAsync(request.PageIndex, request.PageSize, cancellationToken);
    }

    private Expression<Func<Truck, bool>> GenerateFilter(GetFilteredTrucksRequest request)
    {
        Expression<Func<Truck, bool>> filterQuery = x => true;

        if (request.IsAvailable is bool isA && isA)
        {
            //filterQuery = filterQuery.And(x => !x.Shifts.Any(shift =>
            // Check if shift overlaps with requested period
            //shift.StartDate <= request.EndDate && shift.ETA >= request.StartDate
            //true
            //));
        }

        //if (request.IsAvailable is bool a)
        //    filterQuery = filterQuery.And(d => d.Nationality == request.Nationality);

        return filterQuery;
    }

    //private Expression<Func<Shift, bool>> GenerateShiftFilter(GetFilteredTrucksRequest request)
    //{
    //    Expression<Func<Shift, bool>> filterQuery = x => x.StartDate >= request.StartDate;

    //    if (request.IsAvailable is bool isA && isA)
    //    {
    //        filterQuery = filterQuery.And(x =>
    //        // Check if shift overlaps with requested period
    //        x.StartDate <= request.EndDate && x.EndDate >= request.StartDate
    //        );

    //        filterQuery = filterQuery.And(x => x.StartDate <= request.StartDate);

    //        filterQuery = filterQuery.And(x => x.StartDate.Add(x.RouteShifts
    //            .Sum(rs => rs.Route.AvgSpeed / rs.Route.Distance)) <= request.EndDate);
    //    }

    //    Expression<Func<Truck, bool>> filterQuery = x =>
    //        request.Name == null || x.Name.Contains(request.Name);

    //    return filterQuery;
    //}

}
