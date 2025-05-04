using Application.DTO;
using Application.Extensions;
using Application.Handlers.Freights.Commands;
using Application.Handlers.Freights.Query;
using Application.Handlers.Parcels.Query;
using Application.Handlers.Routes.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class FreightsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    //[Authorize(Policy = "AdminOnly")]
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedResults<FreightDTO>>> GetFilteredShifts([FromQuery] GetFilteredFreightsRequest queryParams)
        => await _mediator.Send(queryParams);

    [HttpGet("{freightId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FreightDTO>> GetShiftById(long freightId)
        => await _mediator.Send(new GetFreightByIdRequest(freightId));

    [HttpGet("{freightId}/Parcels")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<ParcelDTO>>> GetFreightParcels(long freightId)
        => Ok(await _mediator.Send(new GetParcelsByFreightRequest(freightId)));

    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Unit>> CreateShift([FromBody] CreateFreightRequest body)
        => await _mediator.Send(body);

    [HttpPost("{freightId}/Parcels")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Unit>> AddParcelToFreight(long freightId, [FromBody] AddParcelToFreightCommand body)
        => await _mediator.Send(body with { FreightId = freightId });

    [HttpPut("{freightId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Unit>> UpdateFreight(long freightId, [FromBody] UpdateFreightRequest body)
        => await _mediator.Send(body with { ShiftId = freightId });

    [HttpGet("Routes")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<RouteDTO>>> GetFilteredRoutes([FromQuery] GetFilteredRoutesRequest queryParams)
    => Ok(await _mediator.Send(queryParams));
}
