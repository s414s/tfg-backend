using Application.Contracts;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TrucksController : ControllerBase
{
    private readonly IAuthServices _authServices;
    public TrucksController(IAuthServices authServices)
    {
        _authServices = authServices;
    }

    [HttpGet("{truckId}")]
    public ActionResult GetTruckById(long truckId)
    {
        return Ok();
    }

    [HttpPost("")]
    public ActionResult<TruckInformationDTO> CreateNewTruck([FromBody] LoginRequestDTO request)
    {
        var result = _authServices.Login(request.Username, request.Password);
        return Ok(result);
    }

    [HttpDelete("")]
    public ActionResult DeleteTruck()
    {
        return Ok();
    }
}
