using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Assessment;
using SchoolManagement.Application.Features.Assessments.Requests.Commands;
using SchoolManagement.Application.Features.Assessments.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Assessment)]
[ApiController]
[Authorize]
public class AssessmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssessmentController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-Assessments")]
    public async Task<ActionResult<List<AssessmentDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Assessments = await _mediator.Send(new GetAssessmentListRequest { QueryParams = queryParams });
        return Ok(Assessments);
    }



    [HttpGet]
    [Route("get-AssessmentDetail/{id}")]
    public async Task<ActionResult<AssessmentDto>> Get(int id)
    {
        var Assessment = await _mediator.Send(new GetAssessmentDetailRequest { AssessmentId = id });
        return Ok(Assessment);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Assessment")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAssessmentDto Assessment)
    {
        var command = new CreateAssessmentCommand { AssessmentDto = Assessment };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Assessment/{id}")]
    public async Task<ActionResult> Put([FromBody] AssessmentDto Assessment)
    {
        var command = new UpdateAssessmentCommand { AssessmentDto = Assessment };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Assessment/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAssessmentCommand { AssessmentId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedAssessment")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAssessment()
    {
        var Assessment = await _mediator.Send(new GetSelectedAssessmentRequest { });
        return Ok(Assessment);
    }
}

