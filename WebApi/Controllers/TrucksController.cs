using Application.Contracts;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TrucksController : ControllerBase
{
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public ActionResult<IEnumerable<TruckDTO>> GetAll()
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
