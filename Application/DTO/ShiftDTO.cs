using Domain.Enums;

namespace Application.DTO;

public record ShiftDTO
{
    public required long Id { get; init; }
    public required ShiftStatus Status { get; init; }
    public required TruckDTO? Truck { get; init; }
    public required UserDTO? Driver { get; init; }
    public required string Route { get; init; } // MAD - VLC - SVL - MAD
};

public record ShiftWithPalletsDTO : ShiftDTO
{
    public IEnumerable<PalletDTO>? Pallets { get; init; }
};
