using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.WithdrawnDoc;
using SchoolManagement.Application.Features.WithdrawnDocs.Requests.Commands;
using SchoolManagement.Application.Features.WithdrawnDocs.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.WithdrawnDocs)]
[ApiController]
[Authorize]
public class WithdrawnDocsController : ControllerBase
{
    private readonly IMediator _mediator;

    public WithdrawnDocsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-withdrawnDocs")]
    public async Task<ActionResult<List<WithdrawnDocDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var WithdrawnDocs = await _mediator.Send(new GetWithdrawnDocsListRequest { QueryParams = queryParams });
        return Ok(WithdrawnDocs);
    }

    [HttpGet]
    [Route("get-withdrawnDocsDetail/{id}")]
    public async Task<ActionResult<WithdrawnDocDto>> Get(int id)
    {
        var WithdrawnDocs = await _mediator.Send(new GetWithdrawnDocsDetailRequest { Id = id });
        return Ok(WithdrawnDocs);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-withdrawnDoc")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateWithdrawnDocDto WithdrawnDoc)
    {
        var command = new CreateWithdrawnDocsCommand { WithdrawnDocDto = WithdrawnDoc };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-withdrawnDoc/{id}")]
    public async Task<ActionResult> Put([FromBody] WithdrawnDocDto WithdrawnDoc)
    {
        var command = new UpdateWithdrawnDocCommand { WithdrawnDocDto = WithdrawnDoc };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-withdrawnDoc/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteWithdrawnDocCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedWithDrawnDocs")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedWithdrawnDoc()
    {
        var WithdrawnDoc = await _mediator.Send(new GetSelectedWithdrawnDocRequest { });
        return Ok(WithdrawnDoc);
    }
}

