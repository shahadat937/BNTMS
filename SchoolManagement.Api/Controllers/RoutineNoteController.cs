using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.RoutineNote;
using SchoolManagement.Application.Features.RoutineNotes.Requests.Commands;
using SchoolManagement.Application.Features.RoutineNotes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.RoutineNote)]
[ApiController]
[Authorize]
public class RoutineNoteController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoutineNoteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-routineNotes")]
    public async Task<ActionResult<List<RoutineNoteDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var RoutineNotees = await _mediator.Send(new GetRoutineNoteListRequest { 
            QueryParams = queryParams
        });
        return Ok(RoutineNotees);
    }

    [HttpGet]
    [Route("get-routineNotesByBaseSchoolNameId")]
    public async Task<ActionResult<List<RoutineNoteDto>>> GetRoutineNotesByBaseSchoolNameId([FromQuery] QueryParams queryParams, int baseSchoolNameId)
    {
        var Routinenotes = await _mediator.Send(new GetRoutineNoteListByBaseSchoolNameIdRequest
        {
            QueryParams = queryParams,
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(Routinenotes);
    }


    [HttpGet]
    [Route("get-routineNoteDetail/{id}")]
    public async Task<ActionResult<RoutineNoteDto>> Get(int id)
    {
        var RoutineNote = await _mediator.Send(new GetRoutineNoteDetailRequest { RoutineNoteId = id });
        return Ok(RoutineNote);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-routineNote")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateRoutineNoteDto RoutineNote)
    {
        var command = new CreateRoutineNoteCommand { RoutineNoteDto = RoutineNote };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-routineNote/{id}")]
    public async Task<ActionResult> Put([FromBody] CreateRoutineNoteDto RoutineNote)
    {
        var command = new UpdateRoutineNoteCommand { RoutineNoteDto = RoutineNote };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-routineNote/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteRoutineNoteCommand { RoutineNoteId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    //[HttpGet]
    //[Route("get-selectedRoutineNotees")]
    //public async Task<ActionResult<List<SelectedModel>>> GetSelectedRoutineNote()
    //{
    //    var RoutineNote = await _mediator.Send(new GetSelectedRoutineNoteRequest { });
    //    return Ok(RoutineNote);
    //}


    [HttpGet]
    [Route("get-routineNotesForDashboard")]
    public async Task<ActionResult> GetRoutineNotesForDashboard(DateTime current,int baseSchoolNameId, int courseNameId, int courseDurationId)
    {
        var routineId = await _mediator.Send(new GetRoutineNotesForDashboardSpRequest
        {
            Current=current,
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId
        });
        return Ok(routineId);
    }

    [HttpGet]
    [Route("get-routineNotesForWeeklyRoutine")]
    public async Task<ActionResult> GetRoutineNotesForWeeklyRoutine(int baseSchoolNameId, int courseNameId, int courseDurationId, int courseWeekId)
    {
        var routineId = await _mediator.Send(new GetRoutineNotesForRoutineSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            CourseWeekId = courseWeekId
        });
        return Ok(routineId);
    }
}

