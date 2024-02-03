using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.EmploymentBeforeJoinBna;
using SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Requests.Commands;
using SchoolManagement.Application.Features.EmploymentBeforeJoinBnas.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.EmploymentBeforeJoinBna)]
[ApiController]
[Authorize]
public class EmploymentBeforeJoinBnaController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmploymentBeforeJoinBnaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-employmentBeforeJoinBna")]
    public async Task<ActionResult<List<EmploymentBeforeJoinBnaDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var EmploymentBeforeJoinBnas = await _mediator.Send(new GetEmploymentBeforeJoinBnaListRequest { QueryParams = queryParams });
        return Ok(EmploymentBeforeJoinBnas);
    }


    [HttpGet]
    [Route("get-employmentBeforeJoinBnaDetail/{id}")]
    public async Task<ActionResult<EmploymentBeforeJoinBnaDto>> Get(int id)
    {
        var EmploymentBeforeJoinBna = await _mediator.Send(new GetEmploymentBeforeJoinBnaDetailRequest { EmploymentBeforeJoinBnaId = id });
        return Ok(EmploymentBeforeJoinBna);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-employmentBeforeJoinBna")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateEmploymentBeforeJoinBnaDto EmploymentBeforeJoinBna)
    {
        var command = new CreateEmploymentBeforeJoinBnaCommand { EmploymentBeforeJoinBnaDto = EmploymentBeforeJoinBna };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-employmentBeforeJoinBna/{id}")]
    public async Task<ActionResult> Put([FromBody] EmploymentBeforeJoinBnaDto EmploymentBeforeJoinBna)
    {
        var command = new UpdateEmploymentBeforeJoinBnaCommand { EmploymentBeforeJoinBnaDto = EmploymentBeforeJoinBna };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-employmentBeforeJoinBna/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteEmploymentBeforeJoinBnaCommand { EmploymentBeforeJoinBnaId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<EmploymentBeforeJoinBnaDto>>> getdatabytraineeid(int Traineeid)
    {
        var EmploymentBeforeJoinBnas = await _mediator.Send(new GetEmploymentBeforeJoinBnaListByTraineeRequest { Traineeid = Traineeid });
        return Ok(EmploymentBeforeJoinBnas);
    }
}

