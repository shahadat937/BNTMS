using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TdecGroupResult;
using SchoolManagement.Application.Features.TdecGroupResults.Requests.Commands;
using SchoolManagement.Application.Features.TdecGroupResults.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TdecGroupResult)]
[ApiController]
[Authorize]
public class TdecGroupResultController : ControllerBase
{
    private readonly IMediator _mediator;

    public TdecGroupResultController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-tdecGroupResults")]
    public async Task<ActionResult<List<TdecGroupResultDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TdecGroupResults = await _mediator.Send(new GetTdecGroupResultListRequest { QueryParams = queryParams });
        return Ok(TdecGroupResults);
    }



    [HttpGet]
    [Route("get-tdecGroupResultDetail/{id}")]
    public async Task<ActionResult<TdecGroupResultDto>> Get(int id)
    {
        var TdecGroupResult = await _mediator.Send(new GetTdecGroupResultDetailRequest { TdecGroupResultId = id });
        return Ok(TdecGroupResult);
    }

     
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-tdecGroupResult")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTdecGroupResultDto TdecGroupResult)
    {
        var command = new CreateTdecGroupResultCommand { TdecGroupResultDto = TdecGroupResult };
        var response = await _mediator.Send(command);
        return Ok();
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-tdecGroupResult/{id}")]
    public async Task<ActionResult> Put([FromBody] TdecGroupResultDto TdecGroupResult)
    {
        var command = new UpdateTdecGroupResultCommand { TdecGroupResultDto = TdecGroupResult };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-tdecGroupResult/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTdecGroupResultCommand { TdecGroupResultId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedTdecGroupResult")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedTdecGroupResult()
    {
        var TdecGroupResult = await _mediator.Send(new GetSelectedTdecGroupResultRequest { });
        return Ok(TdecGroupResult);
    }
}

