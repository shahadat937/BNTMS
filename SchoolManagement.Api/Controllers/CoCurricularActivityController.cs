using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CoCurricularActivity;
using SchoolManagement.Application.Features.CoCurricularActivities.Requests.Commands;
using SchoolManagement.Application.Features.CoCurricularActivities.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CoCurricularActivity)]
[ApiController]
[Authorize]
public class CoCurricularActivityController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoCurricularActivityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-coCurricularActivities")]
    public async Task<ActionResult<List<CoCurricularActivityDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CoCurricularActivities = await _mediator.Send(new GetCoCurricularActivityListRequest { QueryParams = queryParams });
        return Ok(CoCurricularActivities);
    }

    [HttpGet]
    [Route("get-coCurricularActivityDetail/{id}")]
    public async Task<ActionResult<CoCurricularActivityDto>> Get(int id)
    {
        var CoCurricularActivities = await _mediator.Send(new GetCoCurricularActivityDetailRequest { CoCurricularActivityId = id });
        return Ok(CoCurricularActivities);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-coCurricularActivity")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCoCurricularActivityDto CoCurricularActivity)
    {
        var command = new CreateCoCurricularActivityCommand { CoCurricularActivityDto = CoCurricularActivity };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-coCurricularActivity/{id}")]
    public async Task<ActionResult> Put([FromBody] CoCurricularActivityDto CoCurricularActivity)
    {
        var command = new UpdateElectionCommand { CoCurricularActivityDto = CoCurricularActivity };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-coCurricularActivity/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCoCurricularActivityCommand { CoCurricularActivityId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    //new 

    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<CoCurricularActivityDto>>> getdatabytraineeid(int Traineeid)
    {
        var CoCurricularActivitys = await _mediator.Send(new GetCoCurricularActivityListByTraineeRequest { Traineeid = Traineeid });
        return Ok(CoCurricularActivitys);
    }
}

