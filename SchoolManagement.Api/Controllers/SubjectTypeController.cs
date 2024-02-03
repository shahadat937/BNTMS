using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SubjectTypes;
using SchoolManagement.Application.Features.SubjectTypes.Requests.Commands;
using SchoolManagement.Application.Features.SubjectTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SubjectType)]
[ApiController]
[Authorize]
public class SubjectTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubjectTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-subjectTypes")]
    public async Task<ActionResult<List<SubjectTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var SubjectTypes = await _mediator.Send(new GetSubjectTypeListRequest { QueryParams = queryParams });
        return Ok(SubjectTypes);
    }

    [HttpGet]
    [Route("get-subjectTypeDetail/{id}")]
    public async Task<ActionResult<SubjectTypeDto>> Get(int id)
    {
        var SubjectType = await _mediator.Send(new GetSubjectTypeDetailRequest { SubjectTypeId = id });
        return Ok(SubjectType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-subjectType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSubjectTypeDto SubjectType)
    {
        var command = new CreateSubjectTypeCommand { SubjectTypeDto = SubjectType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-subjectType/{id}")]
    public async Task<ActionResult> Put([FromBody] SubjectTypeDto SubjectType)
    {
        var command = new UpdateSubjectTypeCommand { SubjectTypeDto = SubjectType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-subjectType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSubjectTypeCommand { SubjectTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-getSelectedSubjectType")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSubjectType()
    {
        var subjectTypes = await _mediator.Send(new GetSelectedSubjectTypeRequest { });
        return Ok(subjectTypes);
    }
}
