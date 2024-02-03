using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TraineeLanguages;
using SchoolManagement.Application.Features.TraineeLanguages.Requests.Commands;
using SchoolManagement.Application.Features.TraineeLanguages.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TraineeLanguage)]
[ApiController]
[Authorize]
public class TraineeLanguageController : ControllerBase
{
    private readonly IMediator _mediator;

    public TraineeLanguageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-traineeLanguages")]
    public async Task<ActionResult<List<TraineeLanguageDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TraineeLanguagees = await _mediator.Send(new GetTraineeLanguageListRequest { QueryParams = queryParams });
        return Ok(TraineeLanguagees);
    }

    [HttpGet]
    [Route("get-traineeLanguageDetail/{id}")]
    public async Task<ActionResult<TraineeLanguageDto>> Get(int id)
    {
        var TraineeLanguage = await _mediator.Send(new GetTraineeLanguageDetailRequest { Id = id });
        return Ok(TraineeLanguage);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-traineeLanguage")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTraineeLanguageDto TraineeLanguage)
    {
        var command = new CreateTraineeLanguageCommand { TraineeLanguageDto = TraineeLanguage };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-traineeLanguage/{id}")]
    public async Task<ActionResult> Put([FromBody] TraineeLanguageDto TraineeLanguage)
    {
        var command = new UpdateTraineeLanguageCommand { TraineeLanguageDto = TraineeLanguage };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-traineeLanguage/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTraineeLanguageCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<TraineeLanguageDto>>> getdatabytraineeid(int Traineeid)
    {
        var languages = await _mediator.Send(new GetTraineeLanguageListByTraineeRequest { Traineeid = Traineeid });
        return Ok(languages);
    }

}
