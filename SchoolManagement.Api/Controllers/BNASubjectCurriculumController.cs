using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculums;
using SchoolManagement.Application.Features.BnaSubjectCurriculums.Requests.Commands;
using SchoolManagement.Application.Features.BnaSubjectCurriculums.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaSubjectCurriculums)]
[ApiController]
[Authorize]
public class BnaSubjectCurriculumController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaSubjectCurriculumController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaSubjectCurriculums")]
    public async Task<ActionResult<List<BnaSubjectCurriculumDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaSubjectCurriculums = await _mediator.Send(new GetBnaSubjectCurriculumListRequest { QueryParams = queryParams });
        return Ok(BnaSubjectCurriculums);
    }

    [HttpGet]
    [Route("get-bnaSubjectCurriculumDetail/{id}")]
    public async Task<ActionResult<BnaSubjectCurriculumDto>> Get(int id)
    {
        var BnaSubjectCurriculum = await _mediator.Send(new GetBnaSubjectCurriculumDetailRequest { BnaSubjectCurriculumId = id });
        return Ok(BnaSubjectCurriculum);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaSubjectCurriculum")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaSubjectCurriculumDto BnaSubjectCurriculum)
    {
        var command = new CreateBnaSubjectCurriculumCommand { BnaSubjectCurriculumDto = BnaSubjectCurriculum };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaSubjectCurriculum/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaSubjectCurriculumDto BnaSubjectCurriculum)
    {
        var command = new UpdateBnaSubjectCurriculumCommand { BnaSubjectCurriculumDto = BnaSubjectCurriculum };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaSubjectCurriculum/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaSubjectCurriculumCommand { BnaSubjectCurriculumId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get    

    [HttpGet]
    [Route("get-selectedBnaSubjectCurriculums")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBnaSubjectCurriculum()
    {
        var subjectCurriculums = await _mediator.Send(new GetSelectedBnaSubjectCurriculumRequest { });
        return Ok(subjectCurriculums);
    }
}

