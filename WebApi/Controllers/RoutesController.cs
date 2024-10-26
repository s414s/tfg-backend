﻿using Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RoutesController : ControllerBase
{
    private readonly IAuthServices _authServices;
    public RoutesController(IAuthServices authServices)
    {
        _authServices = authServices;
    }

    [HttpGet("")]
    public ActionResult GetAllRoutes()
    {
        return Ok();
    }

    [HttpPost("{cityName}")]
    public ActionResult<string> GetRoutesFrom(string cityName)
    {
        return Ok(cityName);
    }

    [HttpDelete("{routeId}")]
    public ActionResult DeleteRoute(long routeId)
    {
        return Ok();
    }
}