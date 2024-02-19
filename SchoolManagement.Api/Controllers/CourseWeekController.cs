using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseWeeks;
using SchoolManagement.Application.Features.CourseWeekAll.Requests.Commands;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Commands;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CourseWeeks)]
[ApiController]
[Authorize]
public class CourseWeekController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseWeekController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-courseWeeks")]
    public async Task<ActionResult<List<CourseWeekAllDto>>> Get([FromQuery] QueryParams queryParams, int baseSchoolNameId, int courseDurationId)
    {
        var CourseWeeks = await _mediator.Send(new GetCourseWeekListRequest { QueryParams = queryParams, BaseSchoolNameId = baseSchoolNameId, CourseDurationId = courseDurationId });
        return Ok(CourseWeeks);
    }



    [HttpGet]
    [Route("get-courseWeekDetail/{id}")]
    public async Task<ActionResult<CourseWeekAllDto>> Get(int id)
    {
        var CourseWeek = await _mediator.Send(new GetCourseWeekDetailRequest { CourseWeekId = id });
        return Ok(CourseWeek);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-courseWeek")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseWeekDto CourseWeek)
    {
        var command = new CreateCourseWeekCommand { CourseWeekDto = CourseWeek };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-courseWeek/{id}")]
    public async Task<ActionResult> Put([FromBody] CourseWeekAllDto CourseWeek)
    {
        var command = new UpdateCourseWeekCommand { CourseWeekDto = CourseWeek };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-courseWeek/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCourseWeekCommand { CourseWeekId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedCourseWeeks")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedCourseWeek(int baseSchoolNameId, int courseDurationId, int courseNameId, int? status)
    {
        var selectedCourseWeek = await _mediator.Send(new GetSelectedCourseWeekRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseDurationId = courseDurationId,
            CourseNameId = courseNameId,
            Status = status
        });
        return Ok(selectedCourseWeek);
    }

    [HttpGet]
    [Route("get-selectedBnaCourseWeeks")]
    public async Task<ActionResult> getselectedBnaCourseWeek(int baseSchoolNameId, int courseDurationId, int courseNameId, int bnaSemesterId, int? status)
    {
        var selectedCourseWeek = await _mediator.Send(new GetSelectedCourseWeekBnaRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseDurationId = courseDurationId,
            CourseNameId = courseNameId,
            BnaSemesterId = bnaSemesterId,
            Status = status
        });
        return Ok(selectedCourseWeek);
    }

    [HttpGet]
    [Route("get-selectedCourseWeekForEvaluation")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseWeek()
    {
        var selectedCourseWeek = await _mediator.Send(new GetSelectedCourseWeekForEvaluationRequest { });
        return Ok(selectedCourseWeek);
    }

    [HttpGet]
    [Route("get-dataForPrintWeeklyRoutine")]

    public async Task<ActionResult> GetDataForPrintWeeklyRoutine(int courseWeekId)
    {
        var dataForPrintWeeklyRoutine = await _mediator.Send(new GetDataForPrintWeeklyRoutineFromSpRequest
        {
            CourseWeekId = courseWeekId
        });
        return Ok(dataForPrintWeeklyRoutine);
    }

    [HttpGet]
    [Route("get-courseWeekByDuration")]

    public async Task<ActionResult> GetCourseWeekByDuration(int courseDurationId)
    {
        var courseWeekByDuration = await _mediator.Send(new GetCourseWeekByDurationSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(courseWeekByDuration);
    }

    [HttpGet]
    [Route("genarate-autoWeek")]

    public async Task<ActionResult> GenarateAutoCourseWeek(int courseDurationId)
    {
        var genarateAutoCourseWeek = await _mediator.Send(new GetAutoCourseWeekCountRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(genarateAutoCourseWeek);
    }

    [HttpGet]
    [Route("genarate-autoWeekForBna")]

    public async Task<ActionResult> GenarateAutoCourseWeekForBna(int bnaSemesterDurationId)
    {
        var genarateAutoCourseWeek = await _mediator.Send(new GetAutoCourseWeekCountForBnaRequest
        {
            BnaSemesterDurationId = bnaSemesterDurationId
        });
        return Ok(genarateAutoCourseWeek);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("change-courseWeekStatus")]
    public async Task<ActionResult> ChangeCourseWeekStatus(int courseWeekId, int Status)
    {
        var command = new ChangeCourseWeekStatusCommand
        {
            CourseWeekId = courseWeekId,
            Status = Status
        };
        await _mediator.Send(command);
        return NoContent();
    }
}

