using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.EducationalInstitutions;
using SchoolManagement.Application.Features.EducationalInstitutions.Requests.Commands;
using SchoolManagement.Application.Features.EducationalInstitutions.Requests.Queries;

namespace SchoolManagement.Api.Controllers;


[Route(SMSRoutePrefix.EducationalInstitution)]
[ApiController]
[Authorize]
public class EducationalInstitutionController : ControllerBase
{
    private readonly IMediator _mediator;

    public EducationalInstitutionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-educationalInstitutions")]
    public async Task<ActionResult<List<EducationalInstitutionDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var EducationalInstitutiones = await _mediator.Send(new GetEducationalInstitutionListRequest { QueryParams = queryParams });
        return Ok(EducationalInstitutiones);
    }


    [HttpGet]
    [Route("get-educationalInstitutionDetail/{id}")]
    public async Task<ActionResult<EducationalInstitutionDto>> Get(int id)
    {
        var EducationalInstitution = await _mediator.Send(new GetEducationalInstitutionDetailRequest { EducationalInstitutionId = id });
        return Ok(EducationalInstitution);
    }



    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Authorize]
    [Route("save-educationalInstitution")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateEducationalInstitutionDto EducationalInstitution)
    {
        var command = new CreateEducationalInstitutionCommand { EducationalInstitutionDto = EducationalInstitution };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-educationalInstitution/{id}")]
    public async Task<ActionResult> Put([FromBody] EducationalInstitutionDto EducationalInstitution)
    {
        var command = new UpdateEducationalInstitutionCommand { EducationalInstitutionDto = EducationalInstitution };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-educationalInstitution/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteEducationalInstitutionCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<EducationalInstitutionDto>>> getdatabytraineeid(int Traineeid)
    {
        var GrandFathers = await _mediator.Send(new GetEducationalInstitutionListByTraineeRequest { Traineeid = Traineeid });
        return Ok(GrandFathers);
    }

}

