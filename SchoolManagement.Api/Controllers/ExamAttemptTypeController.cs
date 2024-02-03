using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ExamAttemptType;
using SchoolManagement.Application.Features.ExamAttemptTypes.Requests.Commands;
using SchoolManagement.Application.Features.ExamAttemptTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ExamAttemptType)]
[ApiController]
[Authorize]
public class ExamAttemptTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExamAttemptTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-ExamAttemptTypes")]
    public async Task<ActionResult<List<ExamAttemptTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ExamAttemptTypes = await _mediator.Send(new GetExamAttemptTypeListRequest { QueryParams = queryParams });
        return Ok(ExamAttemptTypes);
    }


    [HttpGet]
    [Route("get-ExamAttemptTypeDetail/{id}")]
    public async Task<ActionResult<ExamAttemptTypeDto>> Get(int id)
    {
        var ExamAttemptType = await _mediator.Send(new GetExamAttemptTypeDetailRequest { ExamAttemptTypeId = id });
        return Ok(ExamAttemptType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-ExamAttemptType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateExamAttemptTypeDto ExamAttemptType)
    {
        var command = new CreateExamAttemptTypeCommand { ExamAttemptTypeDto = ExamAttemptType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-ExamAttemptType/{id}")]
    public async Task<ActionResult> Put([FromBody] ExamAttemptTypeDto ExamAttemptType)
    {
        var command = new UpdateExamAttemptTypeCommand { ExamAttemptTypeDto = ExamAttemptType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ExamAttemptType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteExamAttemptTypeCommand { ExamAttemptTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedExamAttemptTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedExamAttemptType()
    {
        var selectedExamAttemptType = await _mediator.Send(new GetSelectedExamAttemptTypeRequest { });
        return Ok(selectedExamAttemptType);
    }
}

