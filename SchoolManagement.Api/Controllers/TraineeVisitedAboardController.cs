using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TraineeVisitedAboard;
using SchoolManagement.Application.Features.TraineeVisitedAboards.Requests.Commands;
using SchoolManagement.Application.Features.TraineeVisitedAboards.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TraineeVisitedAboard)]
[ApiController]
[Authorize]
public class TraineeVisitedAboardController : ControllerBase
{
    private readonly IMediator _mediator;

    public TraineeVisitedAboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-traineeVisitedAboards")]
    public async Task<ActionResult<List<TraineeVisitedAboardDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TraineeVisitedAboards = await _mediator.Send(new GetTraineeVisitedAboardListRequest { QueryParams = queryParams });
        return Ok(TraineeVisitedAboards);
    }

    [HttpGet]
    [Route("get-listBytrainee")]
    public async Task<ActionResult<List<TraineeVisitedAboardDto>>> getdatabytraineeid(int Traineeid)
    {
        var TraineeMemberships = await _mediator.Send(new GetTraineeVisitedAboardListByTraineeRequest { Traineeid = Traineeid });
        return Ok(TraineeMemberships);
    }

    [HttpGet]
    [Route("get-traineeVisitedAboardDetail/{id}")]
    public async Task<ActionResult<TraineeVisitedAboardDto>> Get(int id)
    {
        var TraineeVisitedAboard = await _mediator.Send(new GetTraineeVisitedAboardDetailRequest { TraineeVisitedAboardId = id });
        return Ok(TraineeVisitedAboard);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-traineeVisitedAboard")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTraineeVisitedAboardDto TraineeVisitedAboard)
    {
        var command = new CreateTraineeVisitedAboardCommand { TraineeVisitedAboardDto = TraineeVisitedAboard };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-traineeVisitedAboard/{id}")]
    public async Task<ActionResult> Put([FromBody] TraineeVisitedAboardDto TraineeVisitedAboard)
    {
        var command = new UpdateTraineeVisitedAboardCommand { TraineeVisitedAboardDto = TraineeVisitedAboard };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-traineeVisitedAboard/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTraineeVisitedAboardCommand { TraineeVisitedAboardId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
