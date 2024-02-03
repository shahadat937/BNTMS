using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ExamType;
using SchoolManagement.Application.Features.ExamTypes.Requests.Commands;
using SchoolManagement.Application.Features.ExamTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ExamType)]
[ApiController]
[Authorize]
public class ExamTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExamTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-examTypes")]
    public async Task<ActionResult<List<ExamTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ExamTypes = await _mediator.Send(new GetExamTypeListRequest { QueryParams = queryParams });
        return Ok(ExamTypes);
    }



    [HttpGet]
    [Route("get-examTypeDetail/{id}")]
    public async Task<ActionResult<ExamTypeDto>> Get(int id)
    {
        var ExamType = await _mediator.Send(new GetExamTypeDetailRequest { ExamTypeId = id });
        return Ok(ExamType);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-examType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateExamTypeDto ExamType)
    {
        var command = new CreateExamTypeCommand { ExamTypeDto = ExamType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-examType/{id}")]
    public async Task<ActionResult> Put([FromBody] ExamTypeDto ExamType)
    {
        var command = new UpdateExamTypeCommand { ExamTypeDto = ExamType };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-examType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteExamTypeCommand { ExamTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedExamType")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedExamType()
    {
        var examType = await _mediator.Send(new GetSelectedExamTypeRequest { });
        return Ok(examType);
    }
}

