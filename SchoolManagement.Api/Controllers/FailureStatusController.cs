using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.FailureStatus;
using SchoolManagement.Application.Features.FailureStatuses.Requests.Commands;
using SchoolManagement.Application.Features.FailureStatuses.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.FailureStatus)]
[ApiController]
[Authorize]
public class FailureStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public FailureStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-failureStatuses")]
    public async Task<ActionResult<List<FailureStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var FailureStatuses = await _mediator.Send(new GetFailureStatusListRequest { QueryParams = queryParams });
        return Ok(FailureStatuses);
    }


    [HttpGet]
    [Route("get-failureStatusDetail/{id}")]
    public async Task<ActionResult<FailureStatusDto>> Get(int id)
    {
        var FailureStatuses = await _mediator.Send(new GetFailureStatusDetailRequest { FailureStatusId = id });
        return Ok(FailureStatuses);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-failureStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateFailureStatusDto FailureStatus)
    {
        var command = new CreateFailureStatusCommand { FailureStatusDto = FailureStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-failureStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] FailureStatusDto FailureStatus)
    {
        var command = new UpdateFailureStatusCommand { FailureStatusDto = FailureStatus };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-failureStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteFailureStatusCommand { FailureStatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }



    [HttpGet]
    [Route("get-selectedFailureStatus")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedFailureStatus()
    {
        var failureStatus = await _mediator.Send(new GetSelectedFailureStatusRequest { });
        return Ok(failureStatus);
    }
}

