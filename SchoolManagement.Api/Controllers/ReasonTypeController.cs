using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ReasonType;
using SchoolManagement.Application.Features.ReasonTypes.Requests.Commands;
using SchoolManagement.Application.Features.ReasonTypes.Requests.Queries;
using SchoolManagement.Application.Features.ReasonTypeTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ReasonType)]
[ApiController]
[Authorize]
public class ReasonTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReasonTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-reasonTypes")]
    public async Task<ActionResult<List<ReasonTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ReasonTypes = await _mediator.Send(new GetReasonTypeListRequest { QueryParams = queryParams });
        return Ok(ReasonTypes);
    }

    [HttpGet]
    [Route("get-reasonTypeDetail/{id}")]
    public async Task<ActionResult<ReasonTypeDto>> Get(int id)
    {
        var ReasonType = await _mediator.Send(new GetReasonTypeDetailRequest { ReasonTypeId = id });
        return Ok(ReasonType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-reasonType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateReasonTypeDto ReasonType)
    {
        var command = new CreateReasonTypeCommand { ReasonTypeDto = ReasonType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-reasonType/{id}")]
    public async Task<ActionResult> Put([FromBody] ReasonTypeDto ReasonType)
    {
        var command = new UpdateReasonTypeCommand { ReasonTypeDto = ReasonType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-reasonType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteReasonTypeCommand { ReasonTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedReasonTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedReasonType()
    {
        var resonType = await _mediator.Send(new GetSelectedReasonTypeRequest { });
        return Ok(resonType);
    }
}

