using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseTask;
using SchoolManagement.Application.Features.CourseTasks.Requests.Commands;
using SchoolManagement.Application.Features.CourseTasks.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CourseTask)]
[ApiController]
[Authorize]
public class CourseTaskController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseTaskController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-courseTasks")]
    public async Task<ActionResult<List<CourseTaskDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CourseTasks = await _mediator.Send(new GetCourseTaskListRequest { QueryParams = queryParams });
        return Ok(CourseTasks);
    }



    [HttpGet]
    [Route("get-courseTaskDetail/{id}")]
    public async Task<ActionResult<CourseTaskDto>> Get(int id)
    {
        var CourseTask = await _mediator.Send(new GetCourseTaskDetailRequest { CourseTaskId = id });
        return Ok(CourseTask);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-courseTask")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseTaskDto CourseTask)
    {
        var command = new CreateCourseTaskCommand { CourseTaskDto = CourseTask };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-courseTask/{id}")]
    public async Task<ActionResult> Put([FromBody] CourseTaskDto CourseTask)
    {
        var command = new UpdateCourseTaskCommand { CourseTaskDto = CourseTask };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-courseTask/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCourseTaskCommand { CourseTaskId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedCourseTask")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseTask()
    {
        var CourseTask = await _mediator.Send(new GetSelectedCourseTaskRequest { });
        return Ok(CourseTask);
    }
    [HttpGet]
    [Route("get-courseTaskListBySchoolIdCourseNameIdAndSubjectNameId")]
    public async Task<ActionResult<List<CourseTaskDto>>> GetCourseTaskListBySchoolIdCourseNameIdAndSubjectNameId(int baseSchoolNameId, int courseNameId, int bnaSubjectNameId)
    {
        var familyInfos = await _mediator.Send(new GetCourseTaskListBySchoolIdCourseNameIdAndSubjectNameIdRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(familyInfos);
    }
    [HttpGet]
    [Route("get-subjectNameFromCourseTaskBySchoolIdAndCourseNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSubjectNameFromCourseTaskBySchoolIdAndCourseNameId(int baseSchoolNameId, int courseNameId)
    {
        var subjects = await _mediator.Send(new GetSelectedSubjectNameFromCourseTaskBySchoolIdAndCourseNameIdRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(subjects);
    }
}

