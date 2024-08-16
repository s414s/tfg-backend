using Domain.Entities.Base;

namespace Domain.Entities;

public class User : EntityBase
{
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
