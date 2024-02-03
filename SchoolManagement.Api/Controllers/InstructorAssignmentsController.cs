using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.InstructorAssignments;
using SchoolManagement.Application.Features.InstructorAssignments.Requests.Commands;
using SchoolManagement.Application.Features.InstructorAssignments.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.InstructorAssignment)]
[ApiController]
[Authorize]
public class InstructorAssignmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public InstructorAssignmentController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-instructorAssignments")]
    public async Task<ActionResult<List<InstructorAssignmentDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var InstructorAssignments = await _mediator.Send(new GetInstructorAssignmentListRequest { QueryParams = queryParams });
        return Ok(InstructorAssignments);
    }



    [HttpGet]
    [Route("get-instructorAssignmentDetail/{id}")]
    public async Task<ActionResult<InstructorAssignmentDto>> Get(int id)
    {
        var InstructorAssignment = await _mediator.Send(new GetInstructorAssignmentDetailRequest { InstructorAssignmentId = id });
        return Ok(InstructorAssignment);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-instructorAssignment")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateInstructorAssignmentDto InstructorAssignment)
    {
        var command = new CreateInstructorAssignmentCommand { InstructorAssignmentDto = InstructorAssignment };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-instructorAssignment/{id}")]
    public async Task<ActionResult> Put([FromBody] InstructorAssignmentDto InstructorAssignment)
    {
        var command = new UpdateInstructorAssignmentCommand { InstructorAssignmentDto = InstructorAssignment };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-instructorAssignment/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteInstructorAssignmentCommand { InstructorAssignmentId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedInstructorAssignment")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedInstructorAssignment()
    {
        var InstructorAssignmentValue = await _mediator.Send(new GetSelectedInstructorAssignmentRequest { });
        return Ok(InstructorAssignmentValue);
    }

    [HttpGet]
    [Route("get-instructorAssignmentListByInstructorId")]
    public async Task<ActionResult<List<InstructorAssignmentDto>>> GetinstructorAssignmentListByInstructorIdRequest(int baseSchoolNameId, int courseDurationId, int bnaSubjectNameId, int instructorId)
    {
        var instructorAssignmentsList = await _mediator.Send(new GetInstructorAssignmentListByInstructorIdRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseDurationId = courseDurationId,
            BnaSubjectNameId = bnaSubjectNameId,
            InstructorId = instructorId
        });
        return Ok(instructorAssignmentsList);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("stop-instructorAssignments/{id}")]
    public async Task<ActionResult> StopInstructorAssignments(int id)
    {
        var command = new StopInstructorAssignmentCommand
        {
            InstructorAssignmentId = id
        };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("get-assignmentListForStudent")]
    public async Task<ActionResult> GetStudentAssignmentListFromSpRequest(DateTime CurrentDate, int baseSchoolNameId, int courseNameId, int courseDurationId)
    {
        var assignmentList = await _mediator.Send(new GetStudentAssignmentListFromSpRequest
        {
            CurrentDate = CurrentDate,
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId
        });
        return Ok(assignmentList);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("get-studentSubmittedAssignmentList")]
    public async Task<ActionResult> GetStudentSubmittedAssignmentListFromSpRequest(int instructorAssignmentId, int baseSchoolNameId, int courseNameId, int courseDurationId, int BnaSubjectNameId)
    {
        var submittedAssignmentList = await _mediator.Send(new GetStudentSubmittedAssignmentListFromSpRequest
        {
            InstructorAssignmentId = instructorAssignmentId,
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            BnaSubjectNameId = BnaSubjectNameId
        });
        return Ok(submittedAssignmentList);
    }
}


