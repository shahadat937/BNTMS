using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.NewEntryEvaluation;
using SchoolManagement.Application.Features.NewEntryEvaluations.Requests.Commands;
using SchoolManagement.Application.Features.NewEntryEvaluations.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.NewEntryEvaluation)]
[ApiController]
[Authorize]
public class NewEntryEvaluationController : ControllerBase
{
    private readonly IMediator _mediator;

    public NewEntryEvaluationController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-NewEntryEvaluations")]
    public async Task<ActionResult<List<NewEntryEvaluationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var NewEntryEvaluations = await _mediator.Send(new GetNewEntryEvaluationListRequest { QueryParams = queryParams });
        return Ok(NewEntryEvaluations);
    }



    [HttpGet]
    [Route("get-NewEntryEvaluationDetail/{id}")]
    public async Task<ActionResult<NewEntryEvaluationDto>> Get(int id)
    {
        var NewEntryEvaluation = await _mediator.Send(new GetNewEntryEvaluationDetailRequest { NewEntryEvaluationId = id });
        return Ok(NewEntryEvaluation);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-NewEntryEvaluation")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateNewEntryEvaluationDto NewEntryEvaluation)
    {
        var command = new CreateNewEntryEvaluationCommand { NewEntryEvaluationDto = NewEntryEvaluation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-NewEntryEvaluation/{id}")]
    public async Task<ActionResult> Put([FromBody] NewEntryEvaluationDto NewEntryEvaluation)
    {
        var command = new UpdateNewEntryEvaluationCommand { NewEntryEvaluationDto = NewEntryEvaluation };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-NewEntryEvaluation/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteNewEntryEvaluationCommand { NewEntryEvaluationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-NewEntryEvaluationListBySchoolAndCourseId")]
    public async Task<ActionResult<List<NewEntryEvaluationDto>>> GetNewEntryEvaluationListBySchoolAndCourseId(int baseSchoolNameId, int courseNameId)
    {
        var newEntryEvaluations = await _mediator.Send(new GetNewEntryEvaluationListBySchoolAndCourseIdRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(newEntryEvaluations);
    }
}

