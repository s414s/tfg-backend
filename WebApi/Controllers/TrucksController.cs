using Application.DTO;
using Application.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TrucksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TrucksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedResults<TruckDTO>>> GetAll([FromQuery] long queryParams)
    {
        List<TruckDTO> mock = [
            new TruckDTO { Id = 1, Plate="XXILN" },
            new TruckDTO { Id = 2, Plate="XXLLL" }
            ];
        return Ok(mock);
    }

    [HttpGet("{truckId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public ActionResult GetTruckById(long truckId)
    {
        var mock = new TruckDTO();
        return Ok(mock);
    }

    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public ActionResult<TruckDTO> CreateNewTruck([FromBody] LoginRequestDTO request)
    {
        var mock = new TruckDTO();
        return Ok(mock);
    }

    [HttpDelete("")]
    //[ProducesResponseType(typeof(TruckDTO), 200)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public ActionResult DeleteTruck()
    {
        return Ok();
    }
}
