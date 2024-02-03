using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.NewAtempt;
using SchoolManagement.Application.Features.NewAtempts.Requests.Commands;
using SchoolManagement.Application.Features.NewAtempts.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.NewAtempt)]
[ApiController]
[Authorize]
public class NewAtemptController : ControllerBase
{
    private readonly IMediator _mediator;

    public NewAtemptController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-NewAtempts")]
    public async Task<ActionResult<List<NewAtemptDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var NewAtempts = await _mediator.Send(new GetNewAtemptListRequest { QueryParams = queryParams });
        return Ok(NewAtempts);
    }


    [HttpGet]
    [Route("get-NewAtemptDetail/{id}")]
    public async Task<ActionResult<NewAtemptDto>> Get(int id)
    {
        var NewAtempt = await _mediator.Send(new GetNewAtemptDetailRequest { NewAtemptId = id });
        return Ok(NewAtempt);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-NewAtempt")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateNewAtemptDto NewAtempt)
    {
        var command = new CreateNewAtemptCommand { NewAtemptDto = NewAtempt };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-NewAtempt/{id}")]
    public async Task<ActionResult> Put([FromBody] NewAtemptDto NewAtempt)
    {
        var command = new UpdateNewAtemptCommand { NewAtemptDto = NewAtempt };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-NewAtempt/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteNewAtemptCommand { NewAtemptId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedNewAtempts")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedNewAtempt()
    {
        var selectedNewAtempt = await _mediator.Send(new GetSelectedNewAtemptRequest { });
        return Ok(selectedNewAtempt);
    }
}

