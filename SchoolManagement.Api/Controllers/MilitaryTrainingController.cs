using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.MilitaryTraining;
using SchoolManagement.Application.Features.MilitaryTrainings.Requests.Commands;
using SchoolManagement.Application.Features.MilitaryTrainings.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MilitaryTraining)]
[ApiController]
[Authorize]
public class MilitaryTrainingController : ControllerBase
{
    private readonly IMediator _mediator;

    public MilitaryTrainingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-MilitaryTrainings")]
    public async Task<ActionResult<List<MilitaryTrainingDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MilitaryTraininges = await _mediator.Send(new GetMilitaryTrainingListRequest { QueryParams = queryParams });
        return Ok(MilitaryTraininges);
    }

    [HttpGet]
    [Route("get-MilitaryTrainingDetail/{id}")]
    public async Task<ActionResult<MilitaryTrainingDto>> Get(int id)
    {
        var MilitaryTraining = await _mediator.Send(new GetMilitaryTrainingDetailRequest { Id = id });
        return Ok(MilitaryTraining);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-MilitaryTraining")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMilitaryTrainingDto MilitaryTraining)
    {
        var command = new CreateMilitaryTrainingCommand { MilitaryTrainingDto = MilitaryTraining };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-MilitaryTraining/{id}")]
    public async Task<ActionResult> Put([FromBody] MilitaryTrainingDto MilitaryTraining)
    {
        var command = new UpdateMilitaryTrainingCommand { MilitaryTrainingDto = MilitaryTraining };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-MilitaryTraining/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMilitaryTrainingCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<MilitaryTrainingDto>>> getdatabytraineeid(int Traineeid)
    {
        var MilitaryTraining = await _mediator.Send(new GetMilitaryTrainingListByTraineeRequest { Traineeid = Traineeid });
        return Ok(MilitaryTraining);
    }
}

