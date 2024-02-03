using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ResultStatus;
using SchoolManagement.Application.Features.ResultStatuses.Requests.Commands;
using SchoolManagement.Application.Features.ResultStatuses.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ResultStatus)]
[ApiController]
[Authorize]
public class ResultStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public ResultStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-resultStatuses")]
    public async Task<ActionResult<List<ResultStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ResultStatuses = await _mediator.Send(new GetResultStatusListRequest { QueryParams = queryParams });
        return Ok(ResultStatuses);
    }


    [HttpGet]
    [Route("get-resultStatusDetail/{id}")]
    public async Task<ActionResult<ResultStatusDto>> Get(int id)
    {
        var ResultStatus = await _mediator.Send(new GetResultStatusDetailRequest { ResultStatusId = id });
        return Ok(ResultStatus);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-resultStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateResultStatusDto ResultStatus)
    {
        var command = new CreateResultStatusCommand { ResultStatusDto = ResultStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-resultStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] ResultStatusDto ResultStatus)
    {
        var command = new UpdateResultStatusCommand { ResultStatusDto = ResultStatus };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-resultStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteResultStatusCommand { ResultStatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedResultStatuses")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedResultStatus()
    {
        var resultStatus = await _mediator.Send(new GetSelectedResultStatusRequest { });
        return Ok(resultStatus);
    }
}

