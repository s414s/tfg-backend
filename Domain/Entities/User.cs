using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class User : EntityBase
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public UserRoles Role { get; set; }

    public virtual ICollection<Freight> Freights { get; set; } = [];
}
