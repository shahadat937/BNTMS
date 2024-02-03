using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SaylorRank;
using SchoolManagement.Application.Features.SaylorRanks.Requests.Commands;
using SchoolManagement.Application.Features.SaylorRanks.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SaylorRank)]
[ApiController]
[Authorize]
public class SaylorRankController : ControllerBase
{
    private readonly IMediator _mediator;

    public SaylorRankController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-SaylorRanks")]
    public async Task<ActionResult<List<SaylorRankDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var SaylorRanks = await _mediator.Send(new GetSaylorRankListRequest { QueryParams = queryParams });
        return Ok(SaylorRanks);
    }

    

    [HttpGet]
    [Route("get-SaylorRankDetail/{id}")]
    public async Task<ActionResult<SaylorRankDto>> Get(int id)
    {
        var SaylorRank = await _mediator.Send(new GetSaylorRankDetailRequest { SaylorRankId = id });
        return Ok(SaylorRank);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-SaylorRank")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSaylorRankDto SaylorRank)
    {
        var command = new CreateSaylorRankCommand { SaylorRankDto = SaylorRank };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-SaylorRank/{id}")]
    public async Task<ActionResult> Put([FromBody] SaylorRankDto SaylorRank)
    {
        var command = new UpdateSaylorRankCommand { SaylorRankDto = SaylorRank };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-SaylorRank/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSaylorRankCommand { SaylorRankId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedSaylorRanks")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedSaylorRank()
    {
        var selectedSaylorRank = await _mediator.Send(new GetSelectedSaylorRankRequest { });
        return Ok(selectedSaylorRank);
    }
}

