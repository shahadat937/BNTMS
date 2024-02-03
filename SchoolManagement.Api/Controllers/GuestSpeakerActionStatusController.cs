using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.GuestSpeakerActionStatus;
using SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Requests.Commands;
using SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.GuestSpeakerActionStatus)]
[ApiController]
[Authorize]
public class GuestSpeakerActionStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public GuestSpeakerActionStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-GuestSpeakerActionStatuses")]
    public async Task<ActionResult<List<GuestSpeakerActionStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var GuestSpeakerActionStatuss = await _mediator.Send(new GetGuestSpeakerActionStatusListRequest { QueryParams = queryParams });
        return Ok(GuestSpeakerActionStatuss);
    }



    [HttpGet]
    [Route("get-GuestSpeakerActionStatusDetail/{id}")]
    public async Task<ActionResult<GuestSpeakerActionStatusDto>> Get(int id)
    {
        var GuestSpeakerActionStatus = await _mediator.Send(new GetGuestSpeakerActionStatusDetailRequest { GuestSpeakerActionStatusId = id });
        return Ok(GuestSpeakerActionStatus);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-GuestSpeakerActionStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateGuestSpeakerActionStatusDto GuestSpeakerActionStatus)
    {
        var command = new CreateGuestSpeakerActionStatusCommand { GuestSpeakerActionStatusDto = GuestSpeakerActionStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-GuestSpeakerActionStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] GuestSpeakerActionStatusDto GuestSpeakerActionStatus)
    {
        var command = new UpdateGuestSpeakerActionStatusCommand { GuestSpeakerActionStatusDto = GuestSpeakerActionStatus };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-GuestSpeakerActionStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteGuestSpeakerActionStatusCommand { GuestSpeakerActionStatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedGuestSpeakerActionStatus")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedGuestSpeakerActionStatus()
    {
        var GuestSpeakerActionStatus = await _mediator.Send(new GetSelectedGuestSpeakerActionStatusRequest { });
        return Ok(GuestSpeakerActionStatus);
    }
}

