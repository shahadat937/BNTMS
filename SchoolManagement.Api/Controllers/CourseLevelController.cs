using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseLevel;
using SchoolManagement.Application.Features.CourseLevels.Requests.Commands;
using SchoolManagement.Application.Features.CourseLevels.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CourseLevel)]
[ApiController]
[Authorize]
public class CourseLevelController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseLevelController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-courseLevels")]
    public async Task<ActionResult<List<CourseLevelDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CourseLevels = await _mediator.Send(new GetCourseLevelListRequest { QueryParams = queryParams });
        return Ok(CourseLevels);
    }

    [HttpGet]
    [Route("get-courseLevelDetail/{id}")]
    public async Task<ActionResult<CourseLevelDto>> Get(int id)
    {
        var CourseLevels = await _mediator.Send(new GetCourseLevelDetailRequest { CourseLevelId = id });
        return Ok(CourseLevels);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-courseLevel")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseLevelDto CourseLevel)
    {
        var command = new CreateCourseLevelCommand { CourseLevelDto = CourseLevel };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-courseLevel/{id}")]
    public async Task<ActionResult> Put([FromBody] CourseLevelDto CourseLevel)
    {
        var command = new UpdateCourseLevelCommand { CourseLevelDto = CourseLevel };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-courseLevel/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCourseLevelCommand { CourseLevelId = id };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [Route("get-selectedCourseLevels")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseLevel()
    {
        var bloodgroup = await _mediator.Send(new GetSelectedCourseLevelRequest { });
        return Ok(bloodgroup);
    }
}

