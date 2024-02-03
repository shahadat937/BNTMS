using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.RecordOfService;
using SchoolManagement.Application.Features.RecordOfServices.Requests.Commands;
using SchoolManagement.Application.Features.RecordOfServices.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.RecordOfService)]
[ApiController]
[Authorize]
public class RecordOfServiceController : ControllerBase
{
    private readonly IMediator _mediator;

    public RecordOfServiceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-RecordOfServices")]
    public async Task<ActionResult<List<RecordOfServiceDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var RecordOfServicees = await _mediator.Send(new GetRecordOfServiceListRequest { QueryParams = queryParams });
        return Ok(RecordOfServicees);
    }

    [HttpGet]
    [Route("get-RecordOfServiceDetail/{id}")]
    public async Task<ActionResult<RecordOfServiceDto>> Get(int id)
    {
        var RecordOfService = await _mediator.Send(new GetRecordOfServiceDetailRequest { Id = id });
        return Ok(RecordOfService);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-RecordOfService")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateRecordOfServiceDto RecordOfService)
    {
        var command = new CreateRecordOfServiceCommand { RecordOfServiceDto = RecordOfService };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-RecordOfService/{id}")]
    public async Task<ActionResult> Put([FromBody] RecordOfServiceDto RecordOfService)
    {
        var command = new UpdateRecordOfServiceCommand { RecordOfServiceDto = RecordOfService };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-RecordOfService/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteRecordOfServiceCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<RecordOfServiceDto>>> getdatabytraineeid(int Traineeid)
    {
        var RecordOfService = await _mediator.Send(new GetRecordOfServiceListByTraineeRequest { Traineeid = Traineeid });
        return Ok(RecordOfService);
    }
}

