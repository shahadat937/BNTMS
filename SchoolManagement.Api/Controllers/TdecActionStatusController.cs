using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TdecActionStatus;
using SchoolManagement.Application.Features.TdecActionStatuses.Requests.Commands;
using SchoolManagement.Application.Features.TdecActionStatuses.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TdecActionStatus)]
[ApiController]
[Authorize]
public class TdecActionStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public TdecActionStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-tdecActionStatuses")]
    public async Task<ActionResult<List<TdecActionStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TdecActionStatuss = await _mediator.Send(new GetTdecActionStatusListRequest { QueryParams = queryParams });
        return Ok(TdecActionStatuss);
    }



    [HttpGet]
    [Route("get-tdecActionStatusDetail/{id}")]
    public async Task<ActionResult<TdecActionStatusDto>> Get(int id)
    {
        var TdecActionStatus = await _mediator.Send(new GetTdecActionStatusDetailRequest { TdecActionStatusId = id });
        return Ok(TdecActionStatus);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-tdecActionStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTdecActionStatusDto TdecActionStatus)
    {
        var command = new CreateTdecActionStatusCommand { TdecActionStatusDto = TdecActionStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-tdecActionStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] TdecActionStatusDto TdecActionStatus)
    {
        var command = new UpdateTdecActionStatusCommand { TdecActionStatusDto = TdecActionStatus };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-tdecActionStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTdecActionStatusCommand { TdecActionStatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedTdecActionStatus")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedTdecActionStatus()
    {
        var TdecActionStatus = await _mediator.Send(new GetSelectedTdecActionStatusRequest { });
        return Ok(TdecActionStatus);
    }
}

