using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaExamSchedule;
using SchoolManagement.Application.Features.BnaExamSchedules.Requests.Commands;
using SchoolManagement.Application.Features.BnaExamSchedules.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;


[Route(SMSRoutePrefix.BnaExamSchedule)]
[ApiController]
[Authorize]
public class BnaExamScheduleController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaExamScheduleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaExamSchedules")]
    public async Task<ActionResult<List<BnaExamScheduleDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaExamSchedules = await _mediator.Send(new GetBnaExamScheduleListRequest { QueryParams = queryParams });
        return Ok(BnaExamSchedules);
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBnaExamSchedules")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedBnaexamschedule()
    {
        var BnaExamSchedule = await _mediator.Send(new GetSelectedBnaExamScheduleRequest { });
        return Ok(BnaExamSchedule);
    }


    [HttpGet]
    [Route("get-bnaExamScheduleDetail/{id}")]
    public async Task<ActionResult<BnaExamScheduleDto>> Get(int id)
    {
        var BnaExamSchedule = await _mediator.Send(new GetBnaExamScheduleDetailRequest { BnaExamScheduleId = id });
        return Ok(BnaExamSchedule);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaExamSchedule")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaExamScheduleDto BnaExamSchedule)
    {
        var command = new CreateBnaExamScheduleCommand { BnaExamScheduleDto = BnaExamSchedule };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaExamSchedule/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaExamScheduleDto BnaExamSchedule)
    {
        var command = new UpdateBnaExamScheduleCommand { BnaExamScheduleDto = BnaExamSchedule };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaExamSchedule/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaExamScheduleCommand { BnaExamScheduleId = id };
        await _mediator.Send(command);
        return NoContent();
    }

}

