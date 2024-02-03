using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SwimmingDrivingLevel;
using SchoolManagement.Application.Features.SwimmingDrivingLevels.Requests.Commands;
using SchoolManagement.Application.Features.SwimmingDrivingLevels.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;
[Route(SMSRoutePrefix.SwimmingDrivingLevel)]
[ApiController]
[Authorize]
public class SwimmingDrivingLevelController : ControllerBase
{
    private readonly IMediator _mediator;

    public SwimmingDrivingLevelController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-swimmingDrivingLevels")]
    public async Task<ActionResult<List<SwimmingDrivingLevelDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var SwimmingDrivingLevels = await _mediator.Send(new GetSwimmingDrivingLevelListRequest { QueryParams = queryParams });
        return Ok(SwimmingDrivingLevels);
    }

    [HttpGet]
    [Route("get-swimmingDrivingLevelDetail/{id}")]
    public async Task<ActionResult<SwimmingDrivingLevelDto>> Get(int id)
    {
        var SwimmingDrivingLevel = await _mediator.Send(new GetSwimmingDrivingLevelDetailRequest { SwimmingDrivingLevelId = id });
        return Ok(SwimmingDrivingLevel);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-swimmingDrivingLevel")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSwimmingDrivingLevelDto SwimmingDrivingLevel)
    {
        var command = new CreateSwimmingDrivingLevelCommand { SwimmingDrivingLevelDto = SwimmingDrivingLevel };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-swimmingDrivingLevel/{id}")]
    public async Task<ActionResult> Put([FromBody] SwimmingDrivingLevelDto SwimmingDrivingLevel)
    {
        var command = new UpdateSwimmingDrivingLevelCommand { SwimmingDrivingLevelDto = SwimmingDrivingLevel };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)] 
    [ProducesDefaultResponseType]
    [Route("delete-swimmingDrivingLevel/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSwimmingDrivingLevelCommand { SwimmingDrivingLevelId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
