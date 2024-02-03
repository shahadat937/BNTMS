using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaClassSchedule;
using SchoolManagement.Application.Features.BnaClassSchedules.Requests.Commands;
using SchoolManagement.Application.Features.BnaClassSchedules.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaClassSchedule)]
[ApiController]
[Authorize]
public class BnaClassScheduleController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaClassScheduleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaClassSchedules")]
    public async Task<ActionResult<List<BnaClassScheduleDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaClassSchedules = await _mediator.Send(new GetBnaClassScheduleListRequest { QueryParams = queryParams });
        return Ok(BnaClassSchedules);
    }

    [HttpGet]
    [Route("get-bnaClassScheduleDetail/{id}")]
    public async Task<ActionResult<BnaClassScheduleDto>> Get(int id)
    {
        var BnaClassSchedule = await _mediator.Send(new GetBnaClassScheduleDetailRequest { BnaClassScheduleId = id });
        return Ok(BnaClassSchedule);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaClassSchedule")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaClassScheduleDto BnaClassSchedule)
    {
        var command = new CreateBnaClassScheduleCommand { BnaClassScheduleDto = BnaClassSchedule };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaClassSchedule/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaClassScheduleDto BnaClassSchedule)
    {
        var command = new UpdateBnaClassScheduleCommand { BnaClassScheduleDto = BnaClassSchedule };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaClassSchedule/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaClassScheduleCommand { BnaClassScheduleId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

