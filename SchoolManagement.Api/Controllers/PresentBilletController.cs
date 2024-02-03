using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.PresentBillet;
using SchoolManagement.Application.Features.PresentBillets.Requests.Commands;
using SchoolManagement.Application.Features.PresentBillets.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.PresentBillet)] 
[ApiController]
[Authorize]
public class PresentBilletController : ControllerBase
{
    private readonly IMediator _mediator;

    public PresentBilletController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-presentBillets")]
    public async Task<ActionResult<List<PresentBilletDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var PresentBillets = await _mediator.Send(new GetPresentBilletListRequest { QueryParams = queryParams });
        return Ok(PresentBillets);
    }

    [HttpGet]
    [Route("get-presentBilletDetail/{id}")]
    public async Task<ActionResult<PresentBilletDto>> Get(int id)
    {
        var PresentBillets = await _mediator.Send(new GetPresentBilletDetailRequest { PresentBilletId = id });
        return Ok(PresentBillets);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-presentBillet")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreatePresentBilletDto PresentBillet)
    {
        var command = new CreatePresentBilletCommand { PresentBilletDto = PresentBillet };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-presentBillet/{id}")]
    public async Task<ActionResult> Put([FromBody] PresentBilletDto PresentBillet)
    {
        var command = new UpdatePresentBilletCommand { PresentBilletDto = PresentBillet };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-presentBillet/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeletePresentBilletCommand { PresentBilletId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedPresentBillets")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedUtofficerType()
    {
        var presentbillet = await _mediator.Send(new GetSelectedPresentBilletRequest { });
        return Ok(presentbillet);
    }
}

