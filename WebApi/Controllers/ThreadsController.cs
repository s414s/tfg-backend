using Application.DTO;
using Application.Handlers.Messages.Query;
using Application.Handlers.Threads.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ThreadsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ThreadsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //[Authorize]
    [HttpGet("{threadId:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ThreadDTO>> GetThreadMessages(long threadId)
        => await _mediator.Send(new GetThreadMessagesRequest(threadId));

    [HttpPost("/{threadId:long}/Message")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<long>> CreateThreadMessage(long threadId, [FromBody] CreateThreadMessageRequest request)
        => await _mediator.Send(request with { ThreadId = threadId });

    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<long>> CreateThread([FromBody] CreateThreadRequest request)
        => await _mediator.Send(request);
}
