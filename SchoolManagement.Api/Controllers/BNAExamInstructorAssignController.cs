using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaExamInstructorAssign;
using SchoolManagement.Application.Features.BnaExamInstructorAssigns.Requests.Commands;
using SchoolManagement.Application.Features.BnaExamInstructorAssigns.Requests.Queries;

namespace SchoolManagement.Api.Controllers;


[Route(SMSRoutePrefix.BnaExamInstructorAssign)]
[ApiController]
[Authorize]
public class BnaExamInstructorAssignController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaExamInstructorAssignController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaExamInstructorAssigns")]
    public async Task<ActionResult<List<BnaExamInstructorAssignDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaExamInstructorAssigns = await _mediator.Send(new GetBnaExamInstructorAssignListRequest { QueryParams = queryParams });
        return Ok(BnaExamInstructorAssigns);
    }

    [HttpGet]
    [Route("get-bnaExamInstructorAssignDetail/{id}")]
    public async Task<ActionResult<BnaExamInstructorAssignDto>> Get(int id)
    {
        var BnaExamInstructorAssign = await _mediator.Send(new GetBnaExamInstructorAssignDetailRequest { BnaExamInstructorAssignId = id });
        return Ok(BnaExamInstructorAssign);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaExamInstructorAssign")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaExamInstructorAssignDto BnaExamInstructorAssign)
    {
        var command = new CreateBnaExamInstructorAssignCommand { BnaExamInstructorAssignDto = BnaExamInstructorAssign };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaExamInstructorAssign/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaExamInstructorAssignDto BnaExamInstructorAssign)
    {
        var command = new UpdateBnaExamInstructorAssignCommand { BnaExamInstructorAssignDto = BnaExamInstructorAssign };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaExamInstructorAssign/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaExamInstructorAssignCommand { BnaExamInstructorAssignId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-instructorByParameters")]

    public async Task<ActionResult> GetInstructorByParameters(int baseSchoolNameId, int courseNameId, int courseModuleId, int bnaSubjectNameId)
    {
        var InstructorByParameters = await _mediator.Send(new GetInstructorByParametersRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseModuleId = courseModuleId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(InstructorByParameters);
    }

    [HttpGet]
    [Route("get-instructorBySchoolAndCourse")]

    public async Task<ActionResult> InstructorBySchoolAndCourse(int baseSchoolNameId, int courseNameId)
    {
        var InstructorByParameters = await _mediator.Send(new GetInstructorBySchoolAndCourseRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(InstructorByParameters);
    }
}

