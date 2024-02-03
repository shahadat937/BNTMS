using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaSemesterDurations;
using SchoolManagement.Application.Features.BnaSemesterDurations.Requests.Commands;
using SchoolManagement.Application.Features.BnaSemesterDurations.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaSemesterDurations)]
[ApiController]
[Authorize]
public class BnaSemesterDurationController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaSemesterDurationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaSemesterDurations")]
    public async Task<ActionResult<List<BnaSemesterDurationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaSemesterDurationes = await _mediator.Send(new GetBnaSemesterDurationListRequest { QueryParams = queryParams });
        return Ok(BnaSemesterDurationes);
    }

    [HttpGet]
    [Route("get-bnaSemesterDurationDetail/{id}")]
    public async Task<ActionResult<BnaSemesterDurationDto>> Get(int id)
    {
        var BnaSemesterDuration = await _mediator.Send(new GetBnaSemesterDurationDetailRequest { Id = id });
        return Ok(BnaSemesterDuration);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaSemesterDuration")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaSemesterDurationDto BnaSemesterDuration)
    {
        var command = new CreateBnaSemesterDurationCommand { BnaSemesterDurationDto = BnaSemesterDuration };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaSemesterDuration/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaSemesterDurationDto BnaSemesterDuration)
    {
        var command = new UpdateBnaSemesterDurationCommand { BnaSemesterDurationDto = BnaSemesterDuration };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaSemesterDuration/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaSemesterDurationCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBnaSemesterDurations")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBnaSemesterDuration()
    {
        var BnaSemesterDuration = await _mediator.Send(new GetSelectedBnaSemesterDurationRequest { });
        return Ok(BnaSemesterDuration);
    }


}

