using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.GrandFather;
using SchoolManagement.Application.Features.GrandFathers.Requests.Commands;
using SchoolManagement.Application.Features.GrandFathers.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.GrandFather)]
[ApiController]
[Authorize]
public class GrandFatherController : ControllerBase
{
    private readonly IMediator _mediator;

    public GrandFatherController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-grandFathers")]
    public async Task<ActionResult<List<GrandFatherDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var GrandFathers = await _mediator.Send(new GetGrandFatherListRequest { QueryParams = queryParams });
        return Ok(GrandFathers);
    }

    [HttpGet]
    [Route("get-grandFatherDetail/{id}")]
    public async Task<ActionResult<GrandFatherDto>> Get(int id)
    {
        var GrandFathers = await _mediator.Send(new GetGrandFatherDetailRequest { GrandFatherId = id });
        return Ok(GrandFathers);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-grandFather")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateGrandFatherDto GrandFather)
    {
        var command = new CreateGrandFatherCommand { GrandFatherDto = GrandFather };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-grandFather/{id}")]
    public async Task<ActionResult> Put([FromBody] GrandFatherDto GrandFather)
    {
        var command = new UpdateGrandFatherCommand { GrandFatherDto = GrandFather };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-grandFather/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteGrandFatherCommand { GrandFatherId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<GrandFatherDto>>> getdatabytraineeid(int Traineeid)
    {
        var GrandFathers = await _mediator.Send(new GetGrandFatherListByTraineeRequest { Traineeid = Traineeid });
        return Ok(GrandFathers);
    }
}

