using Domain.Enums;

namespace Application.DTO;

public record FreightDTO
{
    public required long Id { get; init; }
    public required ShiftStatus Status { get; init; }
    public required TruckDTO? Truck { get; init; }
    public required UserDTO? Driver { get; init; }
    public required DateTime DueStart { get; init; }
    public IEnumerable<RouteDTO> Routes { get; init; } = []; // MAD - VLC - SVL - MAD
    public IEnumerable<ParcelDTO> Parcels { get; init; } = [];
};
