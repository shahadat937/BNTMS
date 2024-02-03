using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.JoiningReasons;
using SchoolManagement.Application.Features.JoiningReasons.Requests.Commands;
using SchoolManagement.Application.Features.JoiningReasons.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.JoiningReason)]
[ApiController]
[Authorize]
public class JoiningReasonController : ControllerBase
{
    private readonly IMediator _mediator;

    public JoiningReasonController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-joiningReasons")]
    public async Task<ActionResult<List<JoiningReasonDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var JoiningReasones = await _mediator.Send(new GetJoiningReasonListRequest { QueryParams = queryParams });
        return Ok(JoiningReasones);
    }


    [HttpGet]
    [Route("get-joiningReasonDetail/{id}")]
    public async Task<ActionResult<JoiningReasonDto>> Get(int id)
    {
        var JoiningReason = await _mediator.Send(new GetJoiningReasonDetailRequest { Id = id });
        return Ok(JoiningReason);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-joiningReason")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateJoiningReasonDto JoiningReason)
    {
        var command = new CreateJoiningReasonCommand { JoiningReasonDto = JoiningReason };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-joiningReason/{id}")]
    public async Task<ActionResult> Put([FromBody] JoiningReasonDto JoiningReason)
    {
        var command = new UpdateJoiningReasonCommand { JoiningReasonDto = JoiningReason };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-joiningReason/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteJoiningReasonCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<JoiningReasonDto>>> getdatabytraineeid(int Traineeid)
    {
        var JoiningReason = await _mediator.Send(new GetJoiningReasonListByTraineeRequest { Traineeid = Traineeid });
        return Ok(JoiningReason);
    }

}

