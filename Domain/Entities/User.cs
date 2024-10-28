using Domain.Entities.Base;
using Domain.Enums;
using System.Collections.ObjectModel;

namespace Domain.Entities;

public class User : EntityBase
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRoles Role { get; set; }
    public DateOnly BirthDay { get; set; } = new DateOnly();
    public DateTime AvailableFrom { get; set; }
    public long BaseId { get; set; }

    public virtual City Base { get; set; }
    public virtual Collection<Shift> Shifts { get; set; }
}
