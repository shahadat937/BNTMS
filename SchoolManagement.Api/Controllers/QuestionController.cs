using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Question;
using SchoolManagement.Application.Features.Questions.Requests.Commands;
using SchoolManagement.Application.Features.Questions.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Question)]
[ApiController]
[Authorize]
public class QuestionController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuestionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-questions")]
    public async Task<ActionResult<List<QuestionDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Questions = await _mediator.Send(new GetQuestionListRequest { QueryParams = queryParams });
        return Ok(Questions);
    }

    [HttpGet]
    [Route("get-questionDetail/{id}")]
    public async Task<ActionResult<QuestionDto>> Get(int id)
    {
        var Question = await _mediator.Send(new GetQuestionDetailRequest { QuestionId = id });
        return Ok(Question);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-question")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateQuestionDto Question)
    {
        var command = new CreateQuestionCommand { QuestionDto = Question };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-question/{id}")]
    public async Task<ActionResult> Put([FromBody] QuestionDto Question)
    {
        var command = new UpdateQuestionCommand { QuestionDto = Question };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-question/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteQuestionCommand { QuestionId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<QuestionDto>>> getdatabytraineeid(int Traineeid)
    {
        var Questions = await _mediator.Send(new GetQuestionListByTraineeRequest { Traineeid = Traineeid });
        return Ok(Questions);
    }
}

