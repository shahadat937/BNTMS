using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaAttendancePeriod;
using SchoolManagement.Application.Features.BnaAttendancePeriods.Requests.Commands;
using SchoolManagement.Application.Features.BnaAttendancePeriods.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaAttendancePeriod)]
[ApiController]
[Authorize]
public class BnaAttendancePeriodsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaAttendancePeriodsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaAttendancePeriods")]
    public async Task<ActionResult<List<BnaAttendancePeriodDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaAttendancePeriods = await _mediator.Send(new GetBnaAttendancePeriodListRequest { QueryParams = queryParams });
        return Ok(BnaAttendancePeriods);
    }

    [HttpGet]
    [Route("get-bnaAttendancePeriodDetail/{id}")]
    public async Task<ActionResult<BnaAttendancePeriodDto>> Get(int id)
    {
        var BnaAttendancePeriod = await _mediator.Send(new GetBnaAttendancePeriodDetailRequest { BnaAttendancePeriodId = id });
        return Ok(BnaAttendancePeriod);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaAttendancePeriod")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaAttendancePeriodDto BnaAttendancePeriod)
    {
        var command = new CreateBnaAttendancePeriodCommand { BnaAttendancePeriodDto = BnaAttendancePeriod };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaAttendancePeriod/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaAttendancePeriodDto BnaAttendancePeriod)
    {
        var command = new UpdateBnaAttendancePeriodCommand { BnaAttendancePeriodDto = BnaAttendancePeriod };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaAttendancePeriod/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaAttendancePeriodCommand { BnaAttendancePeriodId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBnaAttendancePeriods")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBnaAttendancePeriod()
    {
        var BnaAttendancePeriod = await _mediator.Send(new GetSelectedBnaAttendancePeriodRequest { });
        return Ok(BnaAttendancePeriod);
    }
}

