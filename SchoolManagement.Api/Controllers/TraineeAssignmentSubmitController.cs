using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TraineeAssignmentSubmits;
using SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Commands;
using SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TraineeAssignmentSubmit)]
[ApiController]
[Authorize]
public class TraineeAssignmentSubmitController : ControllerBase
{
    private readonly IMediator _mediator;

    public TraineeAssignmentSubmitController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-traineeAssignmentSubmits")]
    public async Task<ActionResult<List<TraineeAssignmentSubmitDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TraineeAssignmentSubmits = await _mediator.Send(new GetTraineeAssignmentSubmitListRequest { QueryParams = queryParams });
        return Ok(TraineeAssignmentSubmits);
    }



    [HttpGet]
    [Route("get-traineeAssignmentSubmitDetail/{id}")]
    public async Task<ActionResult<TraineeAssignmentSubmitDto>> Get(int id)
    {
        var TraineeAssignmentSubmit = await _mediator.Send(new GetTraineeAssignmentSubmitDetailRequest { TraineeAssignmentSubmitId = id });
        return Ok(TraineeAssignmentSubmit);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-traineeAssignmentSubmit")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateTraineeAssignmentSubmitDto TraineeAssignmentSubmit)
    {
        var command = new CreateTraineeAssignmentSubmitCommand { TraineeAssignmentSubmitDto = TraineeAssignmentSubmit };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-traineeAssignmentSubmit/{id}")]
    public async Task<ActionResult> Put([FromBody] TraineeAssignmentSubmitDto TraineeAssignmentSubmit)
    {
        var command = new UpdateTraineeAssignmentSubmitCommand { TraineeAssignmentSubmitDto = TraineeAssignmentSubmit };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-traineeAssignmentSubmit/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTraineeAssignmentSubmitCommand { TraineeAssignmentSubmitId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedTraineeAssignmentSubmit")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedTraineeAssignmentSubmit()
    {
        var TraineeAssignmentSubmitValue = await _mediator.Send(new GetSelectedTraineeAssignmentSubmitRequest { });
        return Ok(TraineeAssignmentSubmitValue);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("stop-traineeAssignmentSubmits/{id}")]
    public async Task<ActionResult> StopTraineeAssignmentSubmits(int id)
    {
        var command = new StopTraineeAssignmentSubmitCommand
        {
            TraineeAssignmentSubmitId = id
        };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-traineeAssignmentSubmitListByInstructorId")]
    public async Task<ActionResult<List<TraineeAssignmentSubmitDto>>> GetTraineeAssignmentListByParameterRequest(int traineeId,int instructorId,int bnaSubjectNameId,int baseSchoolNameId,int courseNameId,int courseDurationId, int CourseInstructorId, int instructorAssignmentId)
    {
        var TraineeAssignmentSubmitsList = await _mediator.Send(new GetTraineeAssignmentListByParameterRequest
        {
            TraineeId=traineeId,
            InstructorId = instructorId,
            BnaSubjectNameId = bnaSubjectNameId,
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId =courseNameId,
            CourseDurationId = courseDurationId,
            CourseInstructorId=CourseInstructorId,
            InstructorAssignmentId =instructorAssignmentId
        });
        return Ok(TraineeAssignmentSubmitsList);
    }
}


