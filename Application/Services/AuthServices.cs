using Application.Contracts;
using Application.DTO;
using Domain.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Implementations;

public class AuthServices : IAuthServices
{
    private readonly string _privateKey;
    private readonly IHttpContextAccessor _httpContext;
    public AuthServices(IHttpContextAccessor httpContext)
    {
        _privateKey = "todo-sacaralappconfigyasegurarmedequesealosuficientementesegura";
        _httpContext = httpContext;
    }

    public void SignUp(string email, string password, string passwordRepeat)
    {
        if (!password.Equals(passwordRepeat))
            throw new Exception("passwords are not the same");
    }

    public string GenerateJWT(UserDTO userInfo)
    {
        var privateKey = Encoding.UTF8.GetBytes(_privateKey);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(privateKey), SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(1),
            Subject = GenerateClaims(userInfo)
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

    //public static UserDTO GetUserInfo(string token)
    //{
    //    var claimsPrincipal = GetClaimsPrincipalFromToken(token);
    //    return new UserDTO
    //    {
    //        Id = long.Parse(claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "id")?.Value),
    //        Name = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "name")?.Value ?? "",
    //        Surname = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "surname")?.Value ?? "",
    //        Email = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "email")?.Value ?? "",
    //        Role = Enum.Parse<UserRoles>(claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "role")?.Value),
    //    };
    //}

    public UserDTO GetUserInfo()
    {
        ClaimsPrincipal? claimsPrincipal = _httpContext.HttpContext?.User;

        return new UserDTO
        {
            Id = long.Parse(claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "id")?.Value ?? "0"),
            Name = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "name")?.Value ?? "",
            Surname = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "surname")?.Value ?? "",
            Email = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "email")?.Value ?? "",
            Role = Enum.Parse<UserRoles>(claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "0"),
        };
    }

}
