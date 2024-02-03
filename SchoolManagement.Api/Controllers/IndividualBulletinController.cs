using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.IndividualBulletin;
using SchoolManagement.Application.DTOs.IndividualBulletins;
using SchoolManagement.Application.Features.Bulletins.Requests.Queries;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Application.Features.IndividualBulletins.Requests.Commands;
using SchoolManagement.Application.Features.IndividualBulletins.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.IndividualBulletin)]
[ApiController]
[Authorize]
public class IndividualBulletinController : ControllerBase
{
    private readonly IMediator _mediator;

    public IndividualBulletinController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-IndividualBulletins")]
    public async Task<ActionResult<List<IndividualBulletinDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var IndividualBulletines = await _mediator.Send(new GetIndividualBulletinListRequest { QueryParams = queryParams });
        return Ok(IndividualBulletines);
    }

    [HttpGet]
    [Route("get-IndividualBulletinDetail/{id}")]
    public async Task<ActionResult<IndividualBulletinDto>> Get(int id)
    {
        var IndividualBulletin = await _mediator.Send(new GetIndividualBulletinDetailRequest { IndividualBulletinId = id });
        return Ok(IndividualBulletin);
    }

    //[HttpPost]
    //[ProducesResponseType(200)]
    //[ProducesResponseType(400)]
    //[Route("save-individual-notice")]
    //public async Task<ActionResult<BaseCommandResponse>> SaveIndividualBulletin([FromBody] CreateIndividualBulletinListDto Notice)
    //{
    //    var command = new CreateIndividualBulletinCommand { IndividualBulletinDto = Notice };
    //    var response = await _mediator.Send(command);
    //    return Ok(response);
    //}

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-IndividualBulletin")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateIndividualBulletinListDto IndividualBulletin)
    {
        var command = new CreateIndividualBulletinCommand { IndividualBulletinDto = IndividualBulletin };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-IndividualBulletin/{id}")]
    public async Task<ActionResult> Put([FromBody] IndividualBulletinDto IndividualBulletin)
    {
        var command = new UpdateIndividualBulletinCommand { IndividualBulletinDto = IndividualBulletin };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-IndividualBulletin/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteIndividualBulletinCommand { IndividualBulletinId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedClassIndividualBulletinBySchool")]
    public async Task<ActionResult<List<IndividualBulletinDto>>> GetSelectedIndividualBulletinByschool(int baseSchoolNameId)
    {
        var ClassPeriodName = await _mediator.Send(new GetSelectedIndividualBulletinBySchoolRequest
        {
            BaseSchoolNameId = baseSchoolNameId, 
        });
        return Ok(ClassPeriodName);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("stop-IndividualBulletins/{id}")]
    public async Task<ActionResult> StopIndividualBulletins(int id)
    {
        var command = new StopIndividualBulletinCommand { IndividualBulletinId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-IndividualBulletinByCourseDuration")]
    public async Task<ActionResult> GetIndividualBulletinByDuration(int baseSchoolNameId, int courseNameId, int courseDurationId)
    {
        var proceduredIndividualBulletin = await _mediator.Send(new GetIndividualBulletinByDurationRequest
        {            
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId= courseDurationId
        });
        return Ok(proceduredIndividualBulletin);
    }

    [HttpGet]
    [Route("get-IndividualBulletinListByTraineeId")]
    public async Task<ActionResult> GetIndividualBulletinListByTraineeId(int baseSchoolNameId, int traineeId)
    {
        var bulletinList = await _mediator.Send(new GetIndividualBulletinListBySpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            TraineeId = traineeId
        });
        return Ok(bulletinList);
    }

}

