using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ExamMarkRemarks;
using SchoolManagement.Application.Features.ExamMarkRemark.Requests.Commands;
using SchoolManagement.Application.Features.ExamMarkRemark.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ExamMarkRemark)]
[ApiController]
[Authorize]
public class ExamMarkRemarkController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExamMarkRemarkController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-examMarkRemarks")]
    public async Task<ActionResult<List<ExamMarkRemarkDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ExamMarkRemarks = await _mediator.Send(new GetExamMarkRemarkListRequest { QueryParams = queryParams });
        return Ok(ExamMarkRemarks);
    }



    [HttpGet]
    [Route("get-examMarkRemarkDetail/{id}")]
    public async Task<ActionResult<ExamMarkRemarkDto>> Get(int id)
    {
        var ExamMarkRemark = await _mediator.Send(new GetExamMarkRemarkDetailRequest { ExamMarkRemarksId = id });
        return Ok(ExamMarkRemark);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-examMarkRemark")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateExamMarkRemarkDto ExamMarkRemark)
    {
        var command = new CreateExamMarkRemarkCommand { ExamMarkRemarkDto = ExamMarkRemark };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-examMarkRemark/{id}")]
    public async Task<ActionResult> Put([FromBody] ExamMarkRemarkDto ExamMarkRemark)
    {
        var command = new UpdateExamMarkRemarkCommand { ExamMarkRemarkDto = ExamMarkRemark };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-examMarkRemark/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteExamMarkRemarkCommand { ExamMarkRemarksId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedExamMarkRemark")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedExamMarkRemark()
    {
        var ExamMarkRemark = await _mediator.Send(new GetSelectedExamMarkRemarkRequest { });
        return Ok(ExamMarkRemark);
    }
}

