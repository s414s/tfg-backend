using Application.Handlers.Pallets.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PalletsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PalletsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{shiftId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task CreatePallet(long shiftId, [FromBody] CreatePalletRequest body)
        => await _mediator.Send(body with { ShiftId = shiftId });

    [HttpDelete("{shiftId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task UpdatePallet(long shiftId)
        => await _mediator.Send(new DeletePalletRequest(shiftId));
}
