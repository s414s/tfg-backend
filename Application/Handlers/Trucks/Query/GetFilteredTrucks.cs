using Application.DTO;
using Application.DTO.Base;
using Application.Extensions;
using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using FluentValidation;
using MediatR;
using System.Linq.Expressions;

namespace Application.Handlers.Trucks.Query;

public sealed record GetFilteredTrucksRequest(
    bool? IsAvailable,
    DateTime? StartDate,
    DateTime? EndDate,
    ShiftStatus? Status
    ) : SortedRequest, IRequest<PagedResults<TruckDTO>>
{ }

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

    public GetFilteredTruckRequestHandler(IRepository<Truck> trucksRepository)
    {
        _trucksRepository = trucksRepository;
    }

    public async Task<PagedResults<TruckDTO>> Handle(GetFilteredTrucksRequest request, CancellationToken cancellationToken)
    {
        return await _trucksRepository.Query
            .ApplyOrder(request.OrderBy, request.IsDescending)
            .Select(x => new TruckDTO
            {
                Id = x.Id,
                Plate = x.Plate,
                Mileage = x.Mileage,
                Consumption = x.Consumption,
                DriverName = x.Driver.Name,
            })
            .ToPagedResultsAsync(request.PageIndex, request.PageSize, cancellationToken);
    }

    private Expression<Func<Truck, bool>> GenerateFilter(GetFilteredTrucksRequest request)
    {
        Expression<Func<Truck, bool>> filterQuery = x => true;

        if (request.IsAvailable is bool isA && isA)
        {
            filterQuery = filterQuery.And(x => !x.Shifts.Any(shift =>
                // Check if shift overlaps with requested period
                shift.StartDate <= request.EndDate && shift.ETA >= request.StartDate
            ));
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
