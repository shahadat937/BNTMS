using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Electeds;
using SchoolManagement.Application.Features.Electeds.Requests.Commands;
using SchoolManagement.Application.Features.Electeds.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Elected)]
[ApiController]
[Authorize]
public class ElectedController : ControllerBase
{
    private readonly IMediator _mediator;

    public ElectedController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-electedes")]
    public async Task<ActionResult<List<ElectedDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Electedes = await _mediator.Send(new GetElectedListRequest { QueryParams = queryParams });
        return Ok(Electedes);
    }


    [HttpGet]
    [Route("get-electedDetail/{id}")]
    public async Task<ActionResult<ElectedDto>> Get(int id)
    {
        var Elected = await _mediator.Send(new GetElectedDetailRequest { Id = id });
        return Ok(Elected);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-elected")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateElectedDto Elected)
    {
        var command = new CreateElectedCommand { ElectedDto = Elected };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-elected/{id}")]
    public async Task<ActionResult> Put([FromBody] ElectedDto Elected)
    {
        var command = new UpdateElectedCommand { ElectedDto = Elected };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-elected/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteElectedCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpGet]
    [Route("get-selectedElected")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedelected()
    {
        var ElectionByElected = await _mediator.Send(new GetSelectedElectedRequest { });
        return Ok(ElectionByElected);
    }

}

