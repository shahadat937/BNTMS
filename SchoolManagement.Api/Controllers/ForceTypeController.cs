using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ForceType;
using SchoolManagement.Application.Features.ForceTypes.Requests.Commands;
using SchoolManagement.Application.Features.ForceTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ForceType)]
[ApiController]
[Authorize]
public class ForceTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ForceTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-forceTypes")]
    public async Task<ActionResult<List<ForceTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ForceTypes = await _mediator.Send(new GetForceTypeListRequest { QueryParams = queryParams });
        return Ok(ForceTypes);
    }



    [HttpGet]
    [Route("get-forceTypeDetail/{id}")]
    public async Task<ActionResult<ForceTypeDto>> Get(int id)
    {
        var ForceType = await _mediator.Send(new GetForceTypeDetailRequest { ForceTypeId = id });
        return Ok(ForceType);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-forceType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateForceTypeDto ForceType)
    {
        var command = new CreateForceTypeCommand { ForceTypeDto = ForceType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-forceType/{id}")]
    public async Task<ActionResult> Put([FromBody] ForceTypeDto ForceType)
    {
        var command = new UpdateForceTypeCommand { ForceTypeDto = ForceType };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-forceType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteForceTypeCommand { ForceTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedForceType")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedForceType()
    {
        var forceTypeValue = await _mediator.Send(new GetSelectedForceTypeRequest { });
        return Ok(forceTypeValue);
    }
}

