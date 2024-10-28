using Application.Contracts;
using Application.DTO;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Implementations;

public class AuthServices : IAuthServices
{
    private readonly string _privateKey;
    public AuthServices()
    {
        _privateKey = "todo-sacaralappconfigyasegurarmedequesealosuficientementesegura";
    }

    public void SignUp(string email, string password, string passwordRepeat)
    {
        if (!password.Equals(passwordRepeat))
            throw new Exception("passwords are not the same");
    }

    public LoginResponseDTO Login(string email, string password)
    {
        var user = new User
        {
            Id = 2,
            Name = "pepito",
            Email = "email",
            //Role = "miRole",
        };

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
        //ci.AddClaim(new Claim(ClaimTypes.Role, user.Role));

        //foreach (var role in user.Roles)
        //    ci.AddClaim(new Claim(ClaimTypes.Role, role));

        return ci;
    }
}
