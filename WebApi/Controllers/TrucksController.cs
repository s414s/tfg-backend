using Application.Contracts;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TrucksController : ControllerBase
{
    [HttpGet("")]
    public ActionResult<IEnumerable<TruckDTO>> GetAll()
    {
        List<TruckDTO> mock = [
            new TruckDTO { Id = 1, Plate="XXILN" },
            new TruckDTO { Id = 2, Plate="XXLLL" }
            ];
        return Ok(mock);
    }

    [HttpGet("{truckId}")]
    public ActionResult GetTruckById(long truckId)
    {
        var mock = new TruckDTO();
        return Ok(mock);
    }

    [HttpPost("")]
    public ActionResult<TruckDTO> CreateNewTruck([FromBody] LoginRequestDTO request)
    {
        var mock = new TruckDTO();
        return Ok(mock);
    }

    [HttpDelete("")]
    public ActionResult DeleteTruck()
    {
        return Ok();
    }
}
