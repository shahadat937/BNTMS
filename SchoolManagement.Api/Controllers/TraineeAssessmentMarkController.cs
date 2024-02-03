using SchoolManagement.Application.DTOs.TraineeAssessmentMark;
using SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Commands;
using SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Queries;
using SchoolManagement.Application;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TraineeAssessmentMark)]
[ApiController]
[Authorize]
public class TraineeAssessmentMarkController : ControllerBase
{
    private readonly IMediator _mediator;

    public TraineeAssessmentMarkController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-TraineeAssessmentMarks")]
    public async Task<ActionResult<List<TraineeAssessmentMarkDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TraineeAssessmentMarks = await _mediator.Send(new GetTraineeAssessmentMarkListRequest { QueryParams = queryParams });
        return Ok(TraineeAssessmentMarks);
    }

    [HttpGet]
    [Route("get-TraineeAssessmentMarkDetail/{id}")]
    public async Task<ActionResult<TraineeAssessmentMarkDto>> Get(int id)
    {
        var TraineeAssessmentMark = await _mediator.Send(new GetTraineeAssessmentMarkDetailRequest { TraineeAssessmentMarkId = id });
        return Ok(TraineeAssessmentMark);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-TraineeAssessmentMark")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTraineeAssessmentMarkDto bTraineeAssessmentMark)
    {
        var command = new CreateTraineeAssessmentMarkCommand { TraineeAssessmentMarkDto = bTraineeAssessmentMark };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-traineeAssessmentMarklist")]

    public async Task<ActionResult<BaseCommandResponse>> SaveTraineeAssessmentMarklist([FromBody] TraineeAssessmentMarkListDto traineeAssessmentMarks)
    {
        var command = new CreateTraineeAssessmentMarkListCommand { TraineeAssessmentMarkListDto = traineeAssessmentMarks };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-TraineeAssessmentMark/{id}")]
    public async Task<ActionResult> Put([FromBody] TraineeAssessmentMarkDto bTraineeAssessmentMark)
    {
        var command = new UpdateTraineeAssessmentMarkCommand { TraineeAssessmentMarkDto = bTraineeAssessmentMark };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-TraineeAssessmentMark/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTraineeAssessmentMarkCommand { TraineeAssessmentMarkId = id };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [Route("get-traineeAssessmentMarkListByAssessmentTrainee")]
    public async Task<ActionResult> GetTraineeAssessmentMarkListByAssessmentTraineeSpRequest(int courseDurationId, int TraineeAssessmentCreateId, int assessmentTraineeId)
    {
        var selectedTraineeMark = await _mediator.Send(new GetTraineeAssessmentMarkListByAssessmentTraineeSpRequest
        {
            CourseDurationId = courseDurationId,
            TraineeAssessmentCreateId = TraineeAssessmentCreateId,
            AssessmentTraineeId = assessmentTraineeId
        });
        return Ok(selectedTraineeMark);
    }
}
