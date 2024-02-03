using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaClassScheduleStatuses;
using SchoolManagement.Application.Features.BnaClassScheduleStatuss.Requests.Commands;
using SchoolManagement.Application.Features.BnaClassScheduleStatuss.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaClassScheduleStatuses)]
[ApiController]
[Authorize]
public class BnaClassScheduleStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaClassScheduleStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaClassScheduleStatuses")]
    public async Task<ActionResult<List<BnaClassScheduleStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaClassScheduleStatuss = await _mediator.Send(new GetBnaClassScheduleStatusListRequest { QueryParams = queryParams });
        return Ok(BnaClassScheduleStatuss);
    }

    

    [HttpGet]
    [Route("get-bnaClassScheduleStatusDetail/{id}")]
    public async Task<ActionResult<BnaClassScheduleStatusDto>> Get(int id)
    {
        var BnaClassScheduleStatus = await _mediator.Send(new GetBnaClassScheduleStatusDetailRequest { BnaClassScheduleStatusId = id });
        return Ok(BnaClassScheduleStatus);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaClassScheduleStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaClassScheduleStatusDto BnaClassScheduleStatus)
    {
        var command = new CreateBnaClassScheduleStatusCommand { BnaClassScheduleStatusDto = BnaClassScheduleStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaClassScheduleStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaClassScheduleStatusDto BnaClassScheduleStatus)
    {
        var command = new UpdateBnaClassScheduleStatusCommand { BnaClassScheduleStatusDto = BnaClassScheduleStatus };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaClassScheduleStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaClassScheduleStatusCommand { BnaClassScheduleStatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedbnaClassScheduleStatuses")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedBnaclassschedulestatus()
    {
        var selectedbnaClassScheduleStatus = await _mediator.Send(new GetSelectedBnaClassScheduleStatusRequest { });
        return Ok(selectedbnaClassScheduleStatus);
    }
}

