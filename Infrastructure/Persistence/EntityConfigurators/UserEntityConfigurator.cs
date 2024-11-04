using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Persistence.EntityConfigurators;

public class UserEntityConfigurator : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.Role)
            .IsRequired()
            .HasDefaultValue(UserRoles.Driver);

        // TODO hashear contraseñas
        builder.HasData([
            new User
            {
                Id = 1,
                Name = "alberto",
                Surname = "salas",
                Password = "root",
                Email = "alberto@gmail.com",
                Role = UserRoles.Admin,
            },
            new User
            {
                Id = 2,
                Name = "ana",
                Surname = "salas",
                Password = "root",
                Email = "ana@gmail.com",
                Role = UserRoles.Driver,
            },
            ]);
    }
}
