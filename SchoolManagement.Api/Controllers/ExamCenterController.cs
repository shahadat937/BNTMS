using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ExamCenter;
using SchoolManagement.Application.Features.ExamCenters.Requests.Commands;
using SchoolManagement.Application.Features.ExamCenters.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ExamCenter)]
[ApiController]
[Authorize]
public class ExamCenterController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExamCenterController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-ExamCenters")]
    public async Task<ActionResult<List<ExamCenterDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ExamCenters = await _mediator.Send(new GetExamCenterListRequest { QueryParams = queryParams });
        return Ok(ExamCenters);
    }


    [HttpGet]
    [Route("get-ExamCenterDetail/{id}")]
    public async Task<ActionResult<ExamCenterDto>> Get(int id)
    {
        var ExamCenter = await _mediator.Send(new GetExamCenterDetailRequest { ExamCenterId = id });
        return Ok(ExamCenter);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-ExamCenter")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateExamCenterDto ExamCenter)
    {
        var command = new CreateExamCenterCommand { ExamCenterDto = ExamCenter };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-ExamCenter/{id}")]
    public async Task<ActionResult> Put([FromBody] ExamCenterDto ExamCenter)
    {
        var command = new UpdateExamCenterCommand { ExamCenterDto = ExamCenter };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ExamCenter/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteExamCenterCommand { ExamCenterId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedExamCenters")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedExamCenter()
    {
        var selectedExamCenter = await _mediator.Send(new GetSelectedExamCenterRequest { });
        return Ok(selectedExamCenter);
    }
}

