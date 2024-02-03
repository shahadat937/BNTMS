using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseGradingEntry;
using SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Commands;
using SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CourseGradingEntry)]
[ApiController]
[Authorize]
public class CourseGradingEntryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseGradingEntryController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-CourseGradingEntries")]
    public async Task<ActionResult<List<CourseGradingEntryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CourseGradingEntrys = await _mediator.Send(new GetCourseGradingEntryListRequest { QueryParams = queryParams });
        return Ok(CourseGradingEntrys);
    }



    [HttpGet]
    [Route("get-CourseGradingEntryDetail/{id}")]
    public async Task<ActionResult<CourseGradingEntryDto>> Get(int id)
    {
        var CourseGradingEntry = await _mediator.Send(new GetCourseGradingEntryDetailRequest { CourseGradingEntryId = id });
        return Ok(CourseGradingEntry);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-CourseGradingEntry")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseGradingEntryDto CourseGradingEntry)
    {
        var command = new CreateCourseGradingEntryCommand { CourseGradingEntryDto = CourseGradingEntry };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-CourseGradingEntry/{id}")]
    public async Task<ActionResult> Put([FromBody] CourseGradingEntryDto CourseGradingEntry)
    {
        var command = new UpdateCourseGradingEntryCommand { CourseGradingEntryDto = CourseGradingEntry };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-CourseGradingEntry/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCourseGradingEntryCommand { CourseGradingEntryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedCourseGradingEntry")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseGradingEntry()
    {
        var CourseGradingEntry = await _mediator.Send(new GetSelectedCourseGradingEntryRequest { });
        return Ok(CourseGradingEntry);
    }
    [HttpGet]
    [Route("get-CourseGradingEntryListBySchoolNameIdAndCourseNameId")]
    public async Task<ActionResult<List<CourseGradingEntryDto>>> GetCourseGradingEntryListBySchoolNameIdAndCourseNameId(int baseSchoolNameId, int courseNameId)
    {
        var allowanceCategorys = await _mediator.Send(new GetCourseGradingEntryListBySchoolNameIdAndCourseNameIdRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(allowanceCategorys);
    }
}

