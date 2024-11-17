using Application.Contracts;
using Application.DTO;
using Domain.Enums;
using Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Implementations;

public class AuthServices : IAuthServices
{
    private readonly IHttpContextAccessor _httpContext;
    private readonly JwtSettings _jwtSettings;

    public AuthServices(IHttpContextAccessor httpContext, IOptions<JwtSettings> jwtSettings)
    {
        _httpContext = httpContext;
        _jwtSettings = jwtSettings.Value;
    }

    public void SignUp(string email, string password, string passwordRepeat)
    {
        if (!password.Equals(passwordRepeat))
            throw new Exception("passwords are not the same");
    }

    public string GenerateJWT(UserDTO userInfo)
    {
        var privateKey = Encoding.UTF8.GetBytes(_jwtSettings.Key);

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(privateKey),
            SecurityAlgorithms.HmacSha256
        );

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(1),
            Subject = GenerateClaims(userInfo),

            // testing
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience
        };

        var handler = new JwtSecurityTokenHandler();
        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }

    private static ClaimsIdentity GenerateClaims(UserDTO user)
    {
        IReadOnlyList<Claim> claims = [
            new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Surname, user.Surname),
            new Claim(ClaimTypes.GivenName,  user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
            ];

        return new ClaimsIdentity(claims, "JWT");
    }

    public async Task<ClaimsPrincipal> GetClaimsPrincipalFromTokenAsync()
    {
        var token = await _httpContext.HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "Authentication");
        var handler = new JwtSecurityTokenHandler();
        var claimsPrincipal = handler.ValidateToken(token, new TokenValidationParameters
        {
            // Validation parameters go here
            // Esto creo que sobra por estar en el program.cs
        }, out var validatedToken);

        return claimsPrincipal;
    }

    public UserDTO GetUserInfo()
    {
        ClaimsPrincipal? claimsPrincipal = _httpContext.HttpContext?.User;

        var id = claimsPrincipal?.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
        var name = claimsPrincipal?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        var surname = claimsPrincipal?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value;
        var email = claimsPrincipal?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        var role = claimsPrincipal?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

        return new UserDTO
        {
            Id = long.Parse(id ?? "0"),
            Name = name ?? "",
            Surname = surname ?? "",
            Email = email ?? "",
            Role = Enum.Parse<UserRoles>(role ?? "0"),
        };
    }
}
