using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MarkType;
using SchoolManagement.Application.Features.MarkTypes.Requests.Commands;
using SchoolManagement.Application.Features.MarkTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MarkType)]
[ApiController]
[Authorize]
public class MarkTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public MarkTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-marktypes")]
    public async Task<ActionResult<List<MarkTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MarkTypee = await _mediator.Send(new GetMarkTypeListRequest { QueryParams = queryParams });
        return Ok(MarkTypee);
    }

    [HttpGet]
    [Route("get-marktypedetail/{id}")]
    public async Task<ActionResult<MarkTypeDto>> Get(int id)
    {
        var MarkType = await _mediator.Send(new GetMarkTypeDetailRequest { Id = id });
        return Ok(MarkType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-marktype")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMarkTypeDto MarkType)
    {
        var command = new CreateMarkTypeCommand { MarkTypeDto = MarkType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-marktype/{id}")]
    public async Task<ActionResult> Put([FromBody] MarkTypeDto MarkType)
    {
        var command = new UpdateMarkTypeCommand { MarkTypeDto = MarkType };
        await _mediator.Send(command);
        return NoContent(); 
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-marktype/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMarkTypeCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedmarktypes")] 
    public async Task<ActionResult<List<SelectedModel>>> getselectedmaritialstatus()
    {
        var relationType = await _mediator.Send(new GetSelectedMarkTypeRequest { });
        return Ok(relationType);
    }


}

