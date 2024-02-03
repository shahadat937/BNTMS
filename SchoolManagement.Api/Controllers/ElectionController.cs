using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Election;
using SchoolManagement.Application.Features.Elections.Requests.Commands;
using SchoolManagement.Application.Features.Elections.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Election)]
[ApiController]
[Authorize]
public class ElectionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ElectionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-elections")]
    public async Task<ActionResult<List<ElectionDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Elections = await _mediator.Send(new GetElectionListRequest { QueryParams = queryParams });
        return Ok(Elections);
    }


    [HttpGet]
    [Route("get-electionDetail/{id}")]
    public async Task<ActionResult<ElectionDto>> Get(int id)
    {
        var Elections = await _mediator.Send(new GetElectionDetailRequest { ElectionId = id });
        return Ok(Elections);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-election")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateElectionDto Election)
    {
        var command = new CreateElectionCommand { ElectionDto = Election };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-election/{id}")]
    public async Task<ActionResult> Put([FromBody] ElectionDto Election)
    {
        var command = new UpdateElectionCommand { ElectionDto = Election };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-election/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteElectionCommand { ElectionId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<ElectionDto>>> getdatabytraineeid(int Traineeid)
    {
        var GrandFathers = await _mediator.Send(new GetElectionListByTraineeRequest { Traineeid = Traineeid });
        return Ok(GrandFathers);
    }


    [HttpGet]
    [Route("get-selectedElectionByElected")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedelectionbyelected(string elected)
    {
        var ElectionByElected = await _mediator.Send(new GetSelectedElectionByElected { Elected = elected });
        return Ok(ElectionByElected);
    }
}

