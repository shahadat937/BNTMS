using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Event;
using SchoolManagement.Application.Features.Events.Requests.Commands;
using SchoolManagement.Application.Features.Events.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Event)]
[ApiController]
[Authorize]
public class EventController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-events")]
    public async Task<ActionResult<List<EventDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Eventes = await _mediator.Send(new GetEventListRequest { QueryParams = queryParams });
        return Ok(Eventes);
    }

    [HttpGet]
    [Route("get-eventDetail/{id}")]
    public async Task<ActionResult<EventDto>> Get(int id)
    {
        var Event = await _mediator.Send(new GetEventDetailRequest { EventId = id });
        return Ok(Event);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-event")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateEventDto Event)
    {
        var command = new CreateEventCommand { EventDto = Event };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-event/{id}")]
    public async Task<ActionResult> Put([FromBody] EventDto Event)
    {
        var command = new UpdateEventCommand { EventDto = Event };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-event/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteEventCommand { EventId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedClassEventBySchool")]
    public async Task<ActionResult<List<EventDto>>> GetSelectedEventByschool(int baseSchoolNameId)
    {
        var ClassPeriodName = await _mediator.Send(new GetSelectedEventBySchoolRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
        });
        return Ok(ClassPeriodName);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("change-eventStatus")]
    public async Task<ActionResult> ChangeEventStatus(int eventId, int status)
    {
        var command = new ChangeEventStatusCommand
        {
            EventId = eventId,
            Status = status
        };
        await _mediator.Send(command);
        return NoContent();
    }

    //[HttpGet]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesDefaultResponseType]
    //[Route("stop-Events/{id}")]
    //public async Task<ActionResult> StopEvents(int id)
    //{
    //    var command = new StopEventCommand { EventId = id };
    //    await _mediator.Send(command);
    //    return NoContent();
    //}

}

