using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.UtofficerType;
using SchoolManagement.Application.Features.UtofficerTypes.Requests.Commands;
using SchoolManagement.Application.Features.UtofficerTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.UtofficerType)]
[ApiController]
[Authorize]
public class UtofficerTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public UtofficerTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-utOfficerTypes")]
    public async Task<ActionResult<List<UtofficerTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var UtofficerType = await _mediator.Send(new GetUtofficerTypeListRequest { QueryParams = queryParams });
        return Ok(UtofficerType);
    }

    [HttpGet]
    [Route("get-utOfficerTypeDetail/{id}")]
    public async Task<ActionResult<UtofficerTypeDto>> Get(int id)
    {
        var UtofficerType = await _mediator.Send(new GetUtofficerTypeDetailRequest { UtofficerTypeId = id });
        return Ok(UtofficerType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-utOfficerType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateUtofficerTypeDto UtofficerType)
    {
        var command = new CreateUtofficerTypeCommand { UtofficerTypeDto = UtofficerType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-utOfficerType/{id}")]
    public async Task<ActionResult> Put([FromBody] UtofficerTypeDto UtofficerType)
    {
        var command = new UpdateUtofficerTypeCommand { UtofficerTypeDto = UtofficerType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-utOfficerType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteUtofficerTypeCommand { UtofficerTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [Route("get-selectedUtOfficerTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedUtofficerType()
    {
        var UtofficerType = await _mediator.Send(new GetSelectedUtofficerTypeRequest { });
        return Ok(UtofficerType);
    }
}
