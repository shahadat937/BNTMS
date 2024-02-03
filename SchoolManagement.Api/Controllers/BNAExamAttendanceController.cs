using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaExamAttendance;
using SchoolManagement.Application.Features.BnaExamAttendances.Requests.Commands;
using SchoolManagement.Application.Features.BnaExamAttendances.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaExamAttendance)]
[ApiController]
[Authorize]
public class BnaExamAttendanceController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaExamAttendanceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaExamAttendances")]
    public async Task<ActionResult<List<BnaExamAttendanceDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaExamAttendances = await _mediator.Send(new GetBnaExamAttendanceListRequest { QueryParams = queryParams });
        return Ok(BnaExamAttendances);
    }

    [HttpGet]
    [Route("get-bnaExamAttendanceDetail/{id}")]
    public async Task<ActionResult<BnaExamAttendanceDto>> Get(int id)
    {
        var BnaExamAttendance = await _mediator.Send(new GetBnaExamAttendanceDetailRequest { BnaExamAttendanceId = id });
        return Ok(BnaExamAttendance);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaExamAttendance")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaExamAttendanceDto BnaExamAttendance)
    {
        var command = new CreateBnaExamAttendanceCommand { BnaExamAttendanceDto = BnaExamAttendance };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaExamAttendance/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaExamAttendanceDto BnaExamAttendance)
    {
        var command = new UpdateBnaExamAttendanceCommand { BnaExamAttendanceDto = BnaExamAttendance };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaExamAttendance/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaExamAttendanceCommand { BnaExamAttendanceId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

