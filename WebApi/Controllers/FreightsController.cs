using Application.DTO;
using Application.Extensions;
using Application.Handlers.Routes.Query;
using Application.Handlers.Shifts.Commands;
using Application.Handlers.Shifts.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FreightsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FreightsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedResults<FreightDTO>>> GetFilteredShifts([FromQuery] GetFilteredShiftsRequest queryParams)
        => await _mediator.Send(queryParams);

    [HttpGet("{freightId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FreightDTO>> GetShiftById(long freightId)
        => await _mediator.Send(new GetFreightByIdRequest(freightId));

    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task CreateShift([FromBody] CreateFreightRequest body)
        => await _mediator.Send(body);

    [HttpPost("{freightId}/Parcel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task AddParcelToFreight(long freightId, [FromBody] UpdateFreightRequest body)
        => await _mediator.Send(body with { ShiftId = freightId });

    [HttpPut("{freightId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task UpdateFreight(long freightId, [FromBody] UpdateFreightRequest body)
        => await _mediator.Send(body with { ShiftId = freightId });

    [HttpGet("Routes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<RouteDTO>>> GetFilteredRoutes([FromQuery] GetFilteredRoutesRequest queryParams)
    => Ok(await _mediator.Send(queryParams));
}
