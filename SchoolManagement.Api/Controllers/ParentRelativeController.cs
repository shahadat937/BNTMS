using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.DTOs.ParentRelative;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Application.Features.ParentRelatives.Requests.Commands;
using SchoolManagement.Application.Features.ParentRelatives.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ParentRelative)]
[ApiController] 
[Authorize]
public class ParentRelativeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParentRelativeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-parentRelatives")]
    public async Task<ActionResult<List<ParentRelativeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ParentRelatives = await _mediator.Send(new GetParentRelativeListRequest { QueryParams = queryParams });
        return Ok(ParentRelatives);
    }

    [HttpGet]
    [Route("get-parentRelativeDetail/{id}")]
    public async Task<ActionResult<ParentRelativeDto>> Get(int id)
    {
        var ParentRelatives = await _mediator.Send(new GetParentRelativeDetailRequest { ParentRelativeId = id });
        return Ok(ParentRelatives);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-parentRelative")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateParentRelativeDto ParentRelative)
    {
        var command = new CreateParentRelativeCommand { ParentRelativeDto = ParentRelative };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-parentRelative/{id}")]
    public async Task<ActionResult> Put([FromBody] ParentRelativeDto ParentRelative)
    {
        var command = new UpdateParentRelativeCommand { ParentRelativeDto = ParentRelative };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-parentRelative/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteParentRelativeCommand { ParentRelativeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<ParentRelativeDto>>> getdatabytraineeid(int Traineeid)
    {
        var ParentRelatives = await _mediator.Send(new GetParentRelativeListByTraineeRequest { Traineeid = Traineeid });
        return Ok(ParentRelatives);
    }


    [HttpGet]
    [Route("get-parentRelativeListType")]
    public async Task<ActionResult<List<ParentRelativeDto>>> GetParentRelativeListType(int traineeId,int groupType)
    {
        var courseDurations = await _mediator.Send(new GetParentRelativeListTypeRequest { 
            TraineeId = traineeId,
            GroupType = groupType 
        });
        return Ok(courseDurations);
    }
}

