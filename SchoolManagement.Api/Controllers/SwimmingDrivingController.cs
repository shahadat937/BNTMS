using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SwimmingDriving;
using SchoolManagement.Application.Features.SwimmingDrivings.Requests.Commands;
using SchoolManagement.Application.Features.SwimmingDrivings.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SwimmingDriving)]
[ApiController]
[Authorize]
public class SwimmingDrivingController : ControllerBase
{
    private readonly IMediator _mediator;

    public SwimmingDrivingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-SwimmingDrivings")]
    public async Task<ActionResult<List<SwimmingDrivingDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var SwimmingDrivings = await _mediator.Send(new GetSwimmingDrivingListRequest { QueryParams = queryParams });
        return Ok(SwimmingDrivings);
    }

    [HttpGet]
    [Route("get-SwimmingDrivingDetail/{id}")]
    public async Task<ActionResult<SwimmingDrivingDto>> Get(int id)
    {
        var SwimmingDriving = await _mediator.Send(new GetSwimmingDrivingDetailRequest { SwimmingDrivingId = id });
        return Ok(SwimmingDriving);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-SwimmingDriving")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSwimmingDrivingDto SwimmingDriving)
    {
        //var command = new CreateSwimmingDrivingCommand { SwimmingDrivingDto = SwimmingDriving };
        //var response = await _mediator.Send(command);
        //return Ok(response);
        return Ok();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-SwimmingDriving/{id}")]
    public async Task<ActionResult> Put([FromBody] SwimmingDrivingDto SwimmingDriving)
    {
        var command = new UpdateSwimmingDrivingCommand { SwimmingDrivingDto = SwimmingDriving };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-SwimmingDriving/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSwimmingDrivingCommand { SwimmingDrivingId = id };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<SwimmingDrivingDto>>> getdatabytraineeid(int Traineeid)
    {
        var SwimmingDrivings = await _mediator.Send(new GetSwimmingDrivingListByTraineeRequest { TraineeId = Traineeid });
        return Ok(SwimmingDrivings);
    }

}
