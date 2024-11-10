using Application.DTO;
using Application.Exceptions;
using Domain.Contracts;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Handlers.Users.Query;

public sealed record CreateUserTokenRequest(
    string Email,
    string Password
    ) : IRequest<LoginResponseDTO>
{ }

public class CreateUserTokenRequestValidator : AbstractValidator<CreateUserTokenRequest>
{
    public CreateUserTokenRequestValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("{PropertyName} must be a valid email.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("{PropertyName} can not be empty.");
    }
}

internal sealed class CreateUserTokenQueryHandler : IRequestHandler<CreateUserTokenRequest, LoginResponseDTO>
{
    private readonly IRepository<User> _usersRepository;
    private readonly string _privateKey = "todo-sacaralappconfigyasegurarmedequesealosuficientementesegura";

    public CreateUserTokenQueryHandler(IRepository<User> usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<LoginResponseDTO> Handle(CreateUserTokenRequest request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.Query
            .FirstOrDefaultAsync(x => x.Email == request.Email && x.Password == request.Password, cancellationToken)
            ?? throw new EntityNotFoundException("User or password incorrect");

        var privateKey = Encoding.UTF8.GetBytes(_privateKey);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(privateKey), SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(1),
            Subject = GenerateClaims(user)
        };

        var handler = new JwtSecurityTokenHandler();
        var token = handler.CreateToken(tokenDescriptor);
        return new LoginResponseDTO(handler.WriteToken(token));
    }

    private static ClaimsIdentity GenerateClaims(User user)
    {
        var ci = new ClaimsIdentity();

        ci.AddClaim(new Claim("id", user.Id.ToString()));
        ci.AddClaim(new Claim(ClaimTypes.Name, user.Name));
        ci.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));
        ci.AddClaim(new Claim(ClaimTypes.Email, user.Email));

        ci.AddClaim(new Claim(ClaimTypes.Role, nameof(user.Role)));

        //foreach (var role in user.Roles)
        //    ci.AddClaim(new Claim(ClaimTypes.Role, role));

        return ci;
    }
}
