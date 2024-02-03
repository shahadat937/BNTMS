using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.QuestionType;
using SchoolManagement.Application.Features.QuestionTypes.Requests.Commands;
using SchoolManagement.Application.Features.QuestionTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.QuestionType)]
[ApiController]
[Authorize]
public class QuestionTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuestionTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-questionTypes")]
    public async Task<ActionResult<List<QuestionTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var QuestionTypes = await _mediator.Send(new GetQuestionTypeListRequest { QueryParams = queryParams });
        return Ok(QuestionTypes);
    }

    [HttpGet]
    [Route("get-questionTypeDetail/{id}")]
    public async Task<ActionResult<QuestionTypeDto>> Get(int id)
    {
        var QuestionType = await _mediator.Send(new GetQuestionTypeDetailRequest { QuestionTypeId = id });
        return Ok(QuestionType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-questionType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateQuestionTypeDto QuestionType)
    {
        var command = new CreateQuestionTypeCommand { QuestionTypeDto = QuestionType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-questionType/{id}")]
    public async Task<ActionResult> Put([FromBody] QuestionTypeDto QuestionType)
    {
        var command = new UpdateQuestionTypeCommand { QuestionTypeDto = QuestionType };
        await _mediator.Send(command);
        return NoContent(); 
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-questionType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteQuestionTypeCommand { QuestionTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedQuestionTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedQuestionType()
    {
        var codeValueByType = await _mediator.Send(new GetSelectedQuestionTypeRequest { });
        return Ok(codeValueByType);
    }
}

