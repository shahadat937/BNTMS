using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.UniversityCourseResult;
using SchoolManagement.Application.Features.UniversityCourseResults.Requests.Commands;
using SchoolManagement.Application.Features.UniversityCourseResults.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.UniversityCourseResult)]
[ApiController]
[Authorize]
public class UniversityCourseResultController : ControllerBase
{
    private readonly IMediator _mediator;

    public UniversityCourseResultController(IMediator mediator)
    {
        _mediator = mediator;
    }
    /*
    [HttpGet]
    [Route("get-universityCourseResults")]
    public async Task<ActionResult<List<UniversityCourseResultDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var UniversityCourseResults = await _mediator.Send(new GetUniversityCourseResultListRequest { QueryParams = queryParams });
        return Ok(UniversityCourseResults);
    }

    [HttpGet]
    [Route("get-universityCourseResultDetail/{id}")]
    public async Task<ActionResult<UniversityCourseResultDto>> Get(int id)
    {
        var UniversityCourseResults = await _mediator.Send(new GetUniversityCourseResultDetailRequest { UniversityCourseResultId = id });
        return Ok(UniversityCourseResults);
    }


       [HttpGet]
    [Route("get-selectedUniversityCourseResults")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedUniversityCourseResult()
    {
        var bloodgroup = await _mediator.Send(new GetSelectedUniversityCourseResultRequest { });
        return Ok(bloodgroup);
    }
    */
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-universityCourseResult")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateUniversityCourseResultDto UniversityCourseResult)
    {
        var command = new CreateUniversityCourseResultCommand { UniversityCourseResultDto = UniversityCourseResult };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-universityCourseResult/{id}")]
    public async Task<ActionResult> Put([FromBody] UniversityCourseResultDto UniversityCourseResult)
    {
        var command = new UpdateUniversityCourseResultCommand { UniversityCourseResultDto = UniversityCourseResult };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-universityCourseResult/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteUniversityCourseResultCommand { UniversityCourseResultId = id };
        await _mediator.Send(command);
        return NoContent();
    }


 
}

