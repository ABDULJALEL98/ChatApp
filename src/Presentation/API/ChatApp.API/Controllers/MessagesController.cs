using ChatApp.Application.Features.Message.Command.AddMessage;
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
    public async Task<ActionResult<MessageReturnDto>> Get(CancellationToken ct)
    {
        var messages = await _mediator.Send(request: new GetAllMessageQuery(),ct);
            return Ok(messages);
    }
    [HttpPost]
    public async Task<ActionResult<AddMessageDto>> Post([FromBody] AddMessageDto addMessageDto,CancellationToken ct)
    {
        try
        {
            if(ModelState.IsValid)
            {
                var command = new AddMessageCommand(addMessageDto);
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Ok(response) : BadRequest(response.Message);
            }
            return BadRequest(error: "Error While Adding New message, Modelstate invalid");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
