using SchoolManagement.Application.DTOs.TraineeAssissmentGroup;
using SchoolManagement.Application.Features.TraineeAssissmentGroups.Requests.Commands;
using SchoolManagement.Application.Features.TraineeAssissmentGroups.Requests.Queries;
using SchoolManagement.Application;
using SchoolManagement.Application.Features.TraineeAssessmentGroups.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TraineeAssissmentGroup)]
[ApiController]
[Authorize]
public class TraineeAssissmentGroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public TraineeAssissmentGroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-TraineeAssissmentGroups")]
    public async Task<ActionResult<List<TraineeAssissmentGroupDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TraineeAssissmentGroups = await _mediator.Send(new GetTraineeAssissmentGroupListRequest { QueryParams = queryParams });
        return Ok(TraineeAssissmentGroups);
    }

    [HttpGet]
    [Route("get-TraineeAssissmentGroupDetail/{id}")]
    public async Task<ActionResult<TraineeAssissmentGroupDto>> Get(int id)
    {
        var TraineeAssissmentGroup = await _mediator.Send(new GetTraineeAssissmentGroupDetailRequest { TraineeAssissmentGroupId = id });
        return Ok(TraineeAssissmentGroup);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-TraineeAssissmentGroup")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTraineeAssissmentGroupDto bTraineeAssissmentGroup)
    {
        var command = new CreateTraineeAssissmentGroupCommand { TraineeAssissmentGroupDto = bTraineeAssissmentGroup };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-traineeAssessmentGrouplist")]

    public async Task<ActionResult<BaseCommandResponse>> SaveTraineeAssessmentGrouplist([FromBody] TraineeAssessmentGroupListDto TraineeAssessmentGroupLists)
    {
        var command = new CreateTraineeAssissmentGroupListCommand { TraineeAssissmentGroupListDto = TraineeAssessmentGroupLists };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-TraineeAssissmentGroup/{id}")]
    public async Task<ActionResult> Put([FromBody] TraineeAssissmentGroupDto bTraineeAssissmentGroup)
    {
        var command = new UpdateTraineeAssissmentGroupCommand { TraineeAssissmentGroupDto = bTraineeAssissmentGroup };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-TraineeAssissmentGroup/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTraineeAssissmentGroupCommand { TraineeAssissmentGroupId = id };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [Route("get-traineeListForAssessmentByCourseDurationIdAndTraineeId")]
    public async Task<ActionResult<List<TraineeAssissmentGroupDto>>> GetTraineeListForAssessmentByCourseDurationIdAndTraineeId(int courseDurationId, int traineeId, int traineeAssissmentCreateId)
    {
        var traineeNominations = await _mediator.Send(new GetTraineeListForAssessmentByCourseDurationIdAndTraineeIdRequest
        {
            CourseDurationId = courseDurationId,
            TraineeId= traineeId,
            TraineeAssissmentCreateId= traineeAssissmentCreateId
        });
        return Ok(traineeNominations);
    }


    [HttpGet]
    [Route("get-traineeAssessmentGroupListByAssessmentCreateSpRequest")]
    public async Task<ActionResult> GetTraineeAssessmentGroupListByAssessmentCreateSpRequest(int courseDurationId, int TraineeAssessmentCreateId, string searchText)
    {
        var selectedTraineeGroup = await _mediator.Send(new GetTraineeAssessmentGroupListByAssessmentCreateSpRequest
        {
            CourseDurationId = courseDurationId,
            TraineeAssessmentCreateId = TraineeAssessmentCreateId,
            SearchText = searchText
        });
        return Ok(selectedTraineeGroup);
    }

}
