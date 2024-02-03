using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.StepRelation;
using SchoolManagement.Application.Features.StepRelations.Requests.Commands;
using SchoolManagement.Application.Features.StepRelations.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.StepRelation)]
[ApiController]
[Authorize]
public class StepRelationController : ControllerBase
{
    private readonly IMediator _mediator;

    public StepRelationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-stepRelations")]
    public async Task<ActionResult<List<StepRelationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var StepRelations = await _mediator.Send(new GetStepRelationListRequest { QueryParams = queryParams });
        return Ok(StepRelations);
    }

    [HttpGet]
    [Route("get-stepRelationDetail/{id}")]
    public async Task<ActionResult<StepRelationDto>> Get(int id)
    {
        var StepRelations = await _mediator.Send(new GetStepRelationDetailRequest { StepRelationId = id });
        return Ok(StepRelations);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-stepRelation")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateStepRelationDto StepRelation)
    {
        var command = new CreateStepRelationCommand { StepRelationDto = StepRelation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-stepRelation/{id}")]
    public async Task<ActionResult> Put([FromBody] StepRelationDto StepRelation)
    {
        var command = new UpdateStepRelationCommand { StepRelationDto = StepRelation };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-stepRelation/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteStepRelationCommand { StepRelationId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
