using Domain.Enums;

namespace Application.DTO;

public record ShiftDTO
{
    public long Id { get; init; }
    public ShiftStatus Status { get; init; }
    public TruckDTO? Truck { get; init; }
    public UserDTO? Driver { get; init; }
    public string Route { get; init; } // MAD - VLC - SVL - MAD
};

public record ShiftWithPalletsDTO : ShiftDTO
{
    public IEnumerable<PalletDTO>? Pallets { get; init; }
};
