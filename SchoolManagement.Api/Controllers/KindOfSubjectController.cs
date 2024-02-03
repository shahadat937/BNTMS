
using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.KindOfSubjects;
using SchoolManagement.Application.Features.KindOfSubjects.Requests.Commands;
using SchoolManagement.Application.Features.KindOfSubjects.Requests.Queries;
using SchoolManagement.Application.Features.SubjectTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.KindOfSubject)]
[ApiController]
[Authorize]
public class KindOfSubjectController : ControllerBase
{
    private readonly IMediator _mediator;

    public KindOfSubjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-kindOfSubjects")]
    public async Task<ActionResult<List<KindOfSubjectDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var KindOfSubjectes = await _mediator.Send(new GetKindOfSubjectListRequest { QueryParams = queryParams });
        return Ok(KindOfSubjectes);
    }

    [HttpGet]
    [Route("get-kindOfSubjectDetail/{id}")]
    public async Task<ActionResult<KindOfSubjectDto>> Get(int id)
    {
        var KindOfSubject = await _mediator.Send(new GetKindOfSubjectDetailRequest { Id = id });
        return Ok(KindOfSubject);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-kindOfSubject")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateKindOfSubjectDto KindOfSubject)
    {
        var command = new CreateKindOfSubjectCommand { KindOfSubjectDto = KindOfSubject };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-kindOfSubject/{id}")]
    public async Task<ActionResult> Put([FromBody] KindOfSubjectDto KindOfSubject)
    {
        var command = new UpdateKindOfSubjectCommand { KindOfSubjectDto = KindOfSubject };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-kindOfSubject/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteKindOfSubjectCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedKindOfSubject")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedKindOfSubject()
    {
        var kindOfSubjects = await _mediator.Send(new GetSelectedKindOfSubjectRequest { });
        return Ok(kindOfSubjects);
    }

}

