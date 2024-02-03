using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.EducationalQualification;
using SchoolManagement.Application.Features.EducationalQualifications.Requests.Commands;
using SchoolManagement.Application.Features.EducationalQualifications.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.EducationalQualification)]
[ApiController]
[Authorize]
public class EducationalQualificationController : ControllerBase
{
    private readonly IMediator _mediator;

    public EducationalQualificationController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-educationalQualifications")]
    public async Task<ActionResult<List<EducationalQualificationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var EducationalQualifications = await _mediator.Send(new GetEducationalQualificationListRequest { QueryParams = queryParams });
        return Ok(EducationalQualifications);
    }


    [HttpGet]
    [Route("get-educationalQualificationDetail/{id}")]
    public async Task<ActionResult<EducationalQualificationDto>> Get(int id)
    {
        var EducationalQualifications = await _mediator.Send(new GetEducationalQualificationDetailRequest { EducationalQualificationId = id });
        return Ok(EducationalQualifications);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-educationalQualification")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateEducationalQualificationDto EducationalQualification)
    {
        var command = new CreateEducationalQualificationCommand { EducationalQualificationDto = EducationalQualification };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-educationalQualification/{id}")]
    public async Task<ActionResult> Put([FromBody] EducationalQualificationDto EducationalQualification)
    {
        var command = new UpdateEducationalQualificationCommand { EducationalQualificationDto = EducationalQualification };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-educationalQualification/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteEducationalQualificationCommand { EducationalQualificationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<EducationalQualificationDto>>> getdatabytraineeid(int Traineeid)
    {
        var EducationalQualifications = await _mediator.Send(new GetEducationalQualificationListByTraineeRequest { Traineeid = Traineeid });
        return Ok(EducationalQualifications);
    }
}

