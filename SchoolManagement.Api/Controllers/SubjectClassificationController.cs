using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SubjectClassifications;
using SchoolManagement.Application.Features.SubjectClassifications.Requests.Commands;
using SchoolManagement.Application.Features.SubjectClassifications.Requests.Queries;
using SchoolManagement.Shared.Models;
 
namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SubjectClassification)]
[ApiController]
[Authorize]
public class SubjectClassificationController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubjectClassificationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-subjectClassifications")]
    public async Task<ActionResult<List<SubjectClassificationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var SubjectClassifications = await _mediator.Send(new GetSubjectClassificationListRequest { QueryParams = queryParams });
        return Ok(SubjectClassifications);
    }

    [HttpGet]
    [Route("get-subjectClassificationDetail/{id}")]
    public async Task<ActionResult<SubjectClassificationDto>> Get(int id)
    {
        var SubjectClassification = await _mediator.Send(new GetSubjectClassificationDetailRequest { SubjectClassificationId = id });
        return Ok(SubjectClassification);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-subjectClassification")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSubjectClassificationDto SubjectClassification)
    {
        var command = new CreateSubjectClassificationCommand { SubjectClassificationDto = SubjectClassification };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-subjectClassification/{id}")]
    public async Task<ActionResult> Put([FromBody] SubjectClassificationDto SubjectClassification)
    {
        var command = new UpdateSubjectClassificationCommand { SubjectClassificationDto = SubjectClassification };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-subjectClassification/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSubjectClassificationCommand { SubjectClassificationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedSubjectClassification")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSubjectClassifications()
    {
        var schools = await _mediator.Send(new GetSelectedSubjectClassificationRequest { });
        return Ok(schools);
    }
}
