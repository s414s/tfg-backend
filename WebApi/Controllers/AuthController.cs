using Application.DTO;
using Application.Handlers.Users.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("me")]
    public async Task<ActionResult<UserDTO>> GetActiveUserInfo([FromBody] GetUserInformationRequest request)
        => await _mediator.Send(request);

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] CreateUserTokenRequest request)
        => await _mediator.Send(request);
}
