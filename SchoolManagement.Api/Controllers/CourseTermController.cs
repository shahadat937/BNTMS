using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseTerm;
using SchoolManagement.Application.Features.CourseTerms.Requests.Commands;
using SchoolManagement.Application.Features.CourseTerms.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CourseTerm)]
[ApiController]
[Authorize]
public class CourseTermController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseTermController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-courseTerms")]
    public async Task<ActionResult<List<CourseTermDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CourseTerms = await _mediator.Send(new GetCourseTermListRequest { QueryParams = queryParams });
        return Ok(CourseTerms);
    }

    [HttpGet]
    [Route("get-courseTermDetail/{id}")]
    public async Task<ActionResult<CourseTermDto>> Get(int id)
    {
        var CourseTerms = await _mediator.Send(new GetCourseTermDetailRequest { CourseTermId = id });
        return Ok(CourseTerms);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-courseTerm")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseTermDto CourseTerm)
    {
        var command = new CreateCourseTermCommand { CourseTermDto = CourseTerm };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-courseTerm/{id}")]
    public async Task<ActionResult> Put([FromBody] CourseTermDto CourseTerm)
    {
        var command = new UpdateCourseTermCommand { CourseTermDto = CourseTerm };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-courseTerm/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCourseTermCommand { CourseTermId = id };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [Route("get-selectedCourseTerms")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseTerm()
    {
        var bloodgroup = await _mediator.Send(new GetSelectedCourseTermRequest { });
        return Ok(bloodgroup);
    }
}

