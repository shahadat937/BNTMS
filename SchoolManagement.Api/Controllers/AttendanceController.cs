using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Attendance;
using SchoolManagement.Application.DTOs.Attendance.ApprovedAttendance;
using SchoolManagement.Application.Features.Attendances.Requests.Commands;
using SchoolManagement.Application.Features.Attendances.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Attendance)]
[ApiController]
[Authorize]
public class AttendanceController : ControllerBase
{
    private readonly IMediator _mediator;

    public AttendanceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-attendances")]
    public async Task<ActionResult<List<AttendanceDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Attendances = await _mediator.Send(new GetAttendanceListRequest { QueryParams = queryParams });
        return Ok(Attendances);
    }

    [HttpGet] 
    [Route("get-attendancesForUpdate")]
    public async Task<ActionResult<List<AttendanceDto>>> GetAttendancesForUpdate([FromQuery] QueryParams queryParams,int baseSchoolNameId,int courseNameId,int classPeriodId)
    {
        var Attendances = await _mediator.Send(new GetAttendanceListForUpdateRequest
        {
            QueryParams = queryParams,
            BaseSchoolNameId =baseSchoolNameId,
            CourseNameId = courseNameId,
            ClassPeriodId =classPeriodId
        
        });
        return Ok(Attendances);
    }


    [HttpGet]
    [Route("get-attendanceDetail/{id}")]
    public async Task<ActionResult<AttendanceDto>> Get(int id)
    {
        var Attendance = await _mediator.Send(new GetAttendanceDetailRequest { AttendanceId = id });
        return Ok(Attendance);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-attendancelistnstructor")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAttendanceListDtoInstructor attendance)
    {
        var command = new CreateAttendanceListInstructorCommand { AttendanceListInstructorDto = attendance };
        var response = await _mediator.Send(command);
        return Ok();
    }

    [HttpPost] 
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-attendancelist")]

    public async Task<ActionResult<BaseCommandResponse>> SaveAttendanceList([FromBody] List<CreateAttendanceListDto> attendances)
    {
        var command = new CreateAttendanceListCommand { AttendanceListDto = attendances };
        var rrrr = command;
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("approved-attendancelist")]

    public async Task<ActionResult<BaseCommandResponse>> ApprovedAttendanceList([FromBody] ApprovedAttendanceDto attendance)
    {
        var command = new UpdateAttendanceListCommand { ApprovedAttendanceDto = attendance };
        var response = await _mediator.Send(command);
        return Ok();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-attendance/{id}")]
    public async Task<ActionResult> Put([FromBody] AttendanceDto Attendance)
    {
        var command = new UpdateAttendanceCommand { AttendanceDto = Attendance };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-attendance/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAttendanceCommand { AttendanceId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

