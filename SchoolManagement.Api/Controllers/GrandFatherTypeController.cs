using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.GrandFatherType;
using SchoolManagement.Application.Features.GrandFatherTypes.Requests.Commands;
using SchoolManagement.Application.Features.GrandFatherTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.GrandFatherType)]
[ApiController]
[Authorize]
public class GrandFatherTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public GrandFatherTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-grandFatherTypes")]
    public async Task<ActionResult<List<GrandFatherTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var GrandFatherTypes = await _mediator.Send(new GetGrandFatherTypeListRequest { QueryParams = queryParams });
        return Ok(GrandFatherTypes);
    }

    [HttpGet]
    [Route("get-grandFatherTypeDetail/{id}")]
    public async Task<ActionResult<GrandFatherTypeDto>> Get(int id)
    {
        var GrandFatherTypes = await _mediator.Send(new GetGrandFatherTypeDetailRequest { GrandfatherTypeId = id });
        return Ok(GrandFatherTypes);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-grandFatherType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateGrandFatherTypeDto GrandFatherType)
    {
        var command = new CreateGrandFatherTypeCommand { GrandFatherTypeDto = GrandFatherType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-grandFatherType/{id}")]
    public async Task<ActionResult> Put([FromBody] GrandFatherTypeDto GrandFatherType)
    {
        var command = new UpdateGrandFatherTypeCommand { GrandFatherTypeDto = GrandFatherType };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-grandFatherType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteGrandFatherTypeCommand { GrandfatherTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedGrandFatherType")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedGrandFatherType()
    {
        var grandfatherByType = await _mediator.Send(new GetSelectedGrandFatherTypeRequest { });
        return Ok(grandfatherByType);
    }
}

