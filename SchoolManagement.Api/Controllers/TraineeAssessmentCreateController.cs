using SchoolManagement.Application.DTOs.TraineeAssessmentCreate;
using SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Commands;
using SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Queries;
using SchoolManagement.Shared.Models;
using SchoolManagement.Application.Features.Districts.Requests.Queries;
using SchoolManagement.Application;
using SchoolManagement.Application.Features.Bulletins.Requests.Commands;
using SchoolManagement.Application.Features.UtofficerTypes.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TraineeAssessmentCreate)]
[ApiController]
[Authorize]
public class TraineeAssessmentCreateController : ControllerBase
{
    private readonly IMediator _mediator;

    public TraineeAssessmentCreateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-TraineeAssessmentCreates")]
    public async Task<ActionResult<List<TraineeAssessmentCreateDto>>> Get([FromQuery] QueryParams queryParams, int baseSchoolNameId, int courseDurationId)
    {
        var TraineeAssessmentCreates = await _mediator.Send(new GetTraineeAssessmentCreateListRequest 
        { 
            QueryParams = queryParams, 
            BaseSchoolNameId = baseSchoolNameId,
            CourseDurationId = courseDurationId
        });
        return Ok(TraineeAssessmentCreates);
    }

    [HttpGet]
    [Route("get-TraineeAssessmentCreateDetail/{id}")]
    public async Task<ActionResult<TraineeAssessmentCreateDto>> Get(int id)
    {
        var TraineeAssessmentCreate = await _mediator.Send(new GetTraineeAssessmentCreateDetailRequest { TraineeAssessmentCreateId = id });
        return Ok(TraineeAssessmentCreate);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-TraineeAssessmentCreate")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTraineeAssessmentCreateDto bTraineeAssessmentCreate)
    {
        var command = new CreateTraineeAssessmentCreateCommand { TraineeAssessmentCreateDto = bTraineeAssessmentCreate };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-TraineeAssessmentCreate/{id}")]
    public async Task<ActionResult> Put([FromBody] TraineeAssessmentCreateDto bTraineeAssessmentCreate)
    {
        var command = new UpdateTraineeAssessmentCreateCommand { TraineeAssessmentCreateDto = bTraineeAssessmentCreate };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-TraineeAssessmentCreate/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTraineeAssessmentCreateCommand { TraineeAssessmentCreateId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("change-trainee-assesmentstatus")]
    public async Task<ActionResult> ActiveCoursePlan(int traineeAssessmentCreateId, int status)
    {
        var command = new ChangeTraineeAssessmentStatusCommand
        {
            TraineeAssessmentCreateId = traineeAssessmentCreateId,
            Status = status
        };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [Route("get-selectedTraineeAssessmentCreates")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedTraineeAssessmentCreate(int courseDurationId)
    {
        var TraineeAssessmentCreate = await _mediator.Send(new GetSelectedTraineeAssessmentCreateRequest { 
            CourseDurationId= courseDurationId
        });
        return Ok(TraineeAssessmentCreate);
    }
}
