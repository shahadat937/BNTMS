using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TraineeSectionSelection;
using SchoolManagement.Application.Features.TraineeSectionSelections.Requests.Commands;
using SchoolManagement.Application.Features.TraineeSectionSelections.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TraineeSectionSelection)]
[ApiController]
[Authorize]
public class TraineeSectionSelectionController : ControllerBase
{
    private readonly IMediator _mediator;

    public TraineeSectionSelectionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-traineeSectionSelections")]
    public async Task<ActionResult<List<TraineeSectionSelectionDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TraineeSectionSelections = await _mediator.Send(new GetTraineeSectionSelectionListRequest { QueryParams = queryParams });
        return Ok(TraineeSectionSelections);
    }

    [HttpGet]
    [Route("get-traineeSectionSelectionDetail/{id}")]
    public async Task<ActionResult<TraineeSectionSelectionDto>> Get(int id)
    {
        var TraineeSectionSelection = await _mediator.Send(new GetTraineeSectionSelectionDetailRequest { TraineeSectionSelectionId = id });
        return Ok(TraineeSectionSelection);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-traineeSectionSelection")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTraineeSectionSelectionDto TraineeSectionSelection)
    {
        var command = new CreateTraineeSectionSelectionCommand { TraineeSectionSelectionDto = TraineeSectionSelection };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-traineeSectionSelection/{id}")]
    public async Task<ActionResult> Put([FromBody] TraineeSectionSelectionDto TraineeSectionSelection)
    {
        var command = new UpdateTraineeSectionSelectionCommand { TraineeSectionSelectionDto = TraineeSectionSelection };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-traineeSectionSelection/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTraineeSectionSelectionCommand { TraineeSectionSelectionId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

