using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TraineeCourseStatus;
using SchoolManagement.Application.Features.TraineeCourseStatuses.Requests.Commands;
using SchoolManagement.Application.Features.TraineeCourseStatuses.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TraineeCourseStatuses)]
[ApiController]
[Authorize]
public class TraineeCourseStatusesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TraineeCourseStatusesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-traineeCourseStatuses")]
    public async Task<ActionResult<List<TraineeCourseStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TraineeCourseStatuses = await _mediator.Send(new GetTraineeCourseStatusesListRequest { QueryParams = queryParams });
        return Ok(TraineeCourseStatuses);
    }

    [HttpGet]
    [Route("get-traineeCourseStatusDetail/{id}")]
    public async Task<ActionResult<TraineeCourseStatusDto>> Get(int id)
    {
        var TraineeCourseStatuses = await _mediator.Send(new GetTraineeCourseStatusesDetailRequest { Id = id });
        return Ok(TraineeCourseStatuses);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-traineeCourseStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTraineeCourseStatusDto TraineeCourseStatus)
    {
        var command = new CreateTraineeCourseStatusesCommand { TraineeCourseStatusDto = TraineeCourseStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-traineeCourseStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] TraineeCourseStatusDto TraineeCourseStatus)
    {
        var command = new UpdateTraineeCourseStatusCommand { TraineeCourseStatusDto = TraineeCourseStatus };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-traineeCourseStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTraineeCourseStatusCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedTraineeCourseStatuses")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedTraineeCourseStatus()
    {
        var TraineeCourseStatus = await _mediator.Send(new GetSelectedTraineeCourseStatusRequest { });
        return Ok(TraineeCourseStatus);
    }
}

