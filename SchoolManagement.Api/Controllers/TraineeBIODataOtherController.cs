using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TraineeBioDataOther;
using SchoolManagement.Application.Features.TraineeBioDataOthers.Requests.Commands;
using SchoolManagement.Application.Features.TraineeBioDataOthers.Requests.Queries;

namespace SchoolManagement.Api.Controllers;
 
[Route(SMSRoutePrefix.TraineeBioDataOther)]
[ApiController]
[Authorize]
public class TraineeBioDataOtherController : ControllerBase
{
    private readonly IMediator _mediator; 

    public TraineeBioDataOtherController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-traineeBioDataOthers")]
    public async Task<ActionResult<List<TraineeBioDataOtherDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TraineeBioDataOthers = await _mediator.Send(new GetTraineeBioDataOtherListRequest { QueryParams = queryParams });
        return Ok(TraineeBioDataOthers);
    }

    [HttpGet]
    [Route("get-traineeBiodataOtherDetail/{id}")]
    public async Task<ActionResult<TraineeBioDataOtherDto>> Get(int id)
    {
        var TraineeBioDataOther = await _mediator.Send(new GetTraineeBioDataOtherDetailRequest { TraineeBioDataOtherId = id });
        return Ok(TraineeBioDataOther);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-traineeBiodataOther")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTraineeBioDataOtherDto TraineeBioDataOther)
    {
        var command = new CreateTraineeBioDataOtherCommand { TraineeBioDataOtherDto = TraineeBioDataOther };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-traineeBiodataOther/{id}")]
    public async Task<ActionResult> Put([FromBody] TraineeBioDataOtherDto TraineeBioDataOther)
    {
        var command = new UpdateTraineeBioDataOtherCommand { TraineeBioDataOtherDto = TraineeBioDataOther };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-traineeBiodataOther/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTraineeBioDataOtherCommand { TraineeBioDataOtherId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<TraineeBioDataOtherDto>>> getdatabytraineeid(int Traineeid)
    {
        var TraineeBioDataOthers = await _mediator.Send(new GetTraineeBioDataOtherListByTraineeRequest { TraineeId = Traineeid });
        return Ok(TraineeBioDataOthers);
    }
}
