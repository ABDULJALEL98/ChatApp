using ChatApp.Application.Features.Message.Query.GetAllMessages;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : BaseController
{
    private readonly IMediator _mediator;

    public MessagesController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult<MessageReturnDto>> Get()
    {
        var messages = await _mediator.Send(request: new GetAllMessageQuery());
            return Ok(messages);
    }
}
