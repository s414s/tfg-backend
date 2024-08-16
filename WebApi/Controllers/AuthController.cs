using Application.Contracts;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthServices _authServices;
    public AuthController(IAuthServices authServices)
    {
        _authServices = authServices;
    }

    [HttpGet("me")]
    public ActionResult Me()
    {
        return Ok();
    }

    [HttpPost("login")]
    public ActionResult<LoginResponseDTO> Login([FromBody] LoginRequestDTO request)
    {
        var result = _authServices.Login(request.Username, request.Password);
        return Ok(result);
    }

    [HttpPost("signup")]
    public ActionResult Signup()
    {
        return Ok();
    }
}
