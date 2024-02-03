using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaAttendanceRemarks;
using SchoolManagement.Application.Features.BnaAttendanceRemark.Requests.Commands;
using SchoolManagement.Application.Features.BnaAttendanceRemark.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;


[Route(SMSRoutePrefix.BnaAttendanceRemarks)]
[ApiController]
[Authorize]
public class BnaAttendanceRemarkController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaAttendanceRemarkController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaAttendanceRemarks")]
    public async Task<ActionResult<List<BnaAttendanceRemarkDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaAttendanceRemarks = await _mediator.Send(new GetBnaAttendanceRemarkListRequest { QueryParams = queryParams });
        return Ok(BnaAttendanceRemarks);
    }

    // relational data

    [HttpGet]
    [Route("get-selectedBnaAttendanceRemarks")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBnaAttendanceRemark()
    {
        var BnaAttendanceRemarkName = await _mediator.Send(new GetSelectedBnaAttendanceRemarkRequest { });
        return Ok(BnaAttendanceRemarkName);
    }

    [HttpGet]
    [Route("get-bnaAttendanceRemarkDetail/{id}")]
    public async Task<ActionResult<BnaAttendanceRemarkDto>> Get(int id)
    {
        var BnaAttendanceRemark = await _mediator.Send(new GetBnaAttendanceRemarkDetailRequest { BnaAttendanceRemarksId = id });
        return Ok(BnaAttendanceRemark);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaAttendanceRemark")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaAttendanceRemarkDto BnaAttendanceRemark)
    {
        var command = new CreateBnaAttendanceRemarkCommand { BnaAttendanceRemarkDto = BnaAttendanceRemark };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaAttendanceRemark/{id}")]

    public async Task<ActionResult> Put([FromBody] BnaAttendanceRemarkDto BnaAttendanceRemark)
    {
        var command = new UpdateBnaAttendanceRemarkCommand { BnaAttendanceRemarkDto = BnaAttendanceRemark };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaAttendanceRemark/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaAttendanceRemarkCommand { BnaAttendanceRemarksId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

