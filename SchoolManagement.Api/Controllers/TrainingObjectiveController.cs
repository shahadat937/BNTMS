using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TrainingObjective;
using SchoolManagement.Application.Features.TrainingObjectives.Requests.Commands;
using SchoolManagement.Application.Features.TrainingObjectives.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TrainingObjective)]
[ApiController]
[Authorize]
public class TrainingObjectiveController : ControllerBase
{
    private readonly IMediator _mediator;

    public TrainingObjectiveController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-trainingObjectives")]
    public async Task<ActionResult<List<TrainingObjectiveDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TrainingObjectives = await _mediator.Send(new GetTrainingObjectiveListRequest { QueryParams = queryParams });
        return Ok(TrainingObjectives);
    }



    [HttpGet]
    [Route("get-trainingObjectiveDetail/{id}")]
    public async Task<ActionResult<TrainingObjectiveDto>> Get(int id)
    {
        var TrainingObjective = await _mediator.Send(new GetTrainingObjectiveDetailRequest { TrainingObjectiveId = id });
        return Ok(TrainingObjective);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-trainingObjective")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTrainingObjectiveDto TrainingObjective)
    {
        var command = new CreateTrainingObjectiveCommand { TrainingObjectiveDto = TrainingObjective };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-trainingObjective/{id}")]
    public async Task<ActionResult> Put([FromBody] TrainingObjectiveDto TrainingObjective)
    {
        var command = new UpdateTrainingObjectiveCommand { TrainingObjectiveDto = TrainingObjective };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-trainingObjective/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTrainingObjectiveCommand { TrainingObjectiveId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedTrainingObjective")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedTrainingObjective()
    {
        var TrainingObjective = await _mediator.Send(new GetSelectedTrainingObjectiveRequest { });
        return Ok(TrainingObjective);
    }
    [HttpGet]
    [Route("get-trainingObjectiveListBySchoolIdCourseNameIdAndSubjectNameId")]
    public async Task<ActionResult<List<TrainingObjectiveDto>>> GetTrainingObjectiveListBySchoolIdCourseNameIdAndSubjectNameId(int baseSchoolNameId, int courseNameId, int bnaSubjectNameId)
    {
        var familyInfos = await _mediator.Send(new GetTrainingObjectiveListBySchoolIdCourseNameIdAndSubjectNameIdRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(familyInfos);
    }
    [HttpGet]
    [Route("get-subjectNameFromTrainingObjectiveBySchoolIdAndCourseNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSubjectNameFromTrainingObjectiveBySchoolIdAndCourseNameId(int baseSchoolNameId, int courseNameId)
    {
        var subjects = await _mediator.Send(new GetSelectedSubjectNameFromTrainingObjectiveBySchoolIdAndCourseNameIdRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(subjects);
    }
}

