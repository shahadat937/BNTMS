using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TraineeMembership;
using SchoolManagement.Application.Features.TraineeMemberships.Requests.Commands;
using SchoolManagement.Application.Features.TraineeMemberships.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TraineeMembership)]
[ApiController]
[Authorize]
public class TraineeMembershipController : ControllerBase
{
    private readonly IMediator _mediator;

    public TraineeMembershipController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-traineeMemberships")]
    public async Task<ActionResult<List<TraineeMembershipDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TraineeMemberships = await _mediator.Send(new GetTraineeMembershipListRequest { QueryParams = queryParams });
        return Ok(TraineeMemberships);
    }

    [HttpGet]
    [Route("get-traineeMembershipDetail/{id}")]
    public async Task<ActionResult<TraineeMembershipDto>> Get(int id)
    {
        var TraineeMembership = await _mediator.Send(new GetTraineeMembershipDetailRequest { TraineeMembershipId = id });
        return Ok(TraineeMembership);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-traineeMembership")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTraineeMembershipDto TraineeMembership)
    {
        var command = new CreateTraineeMembershipCommand { TraineeMembershipDto = TraineeMembership };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-traineeMembership/{id}")]
    public async Task<ActionResult> Put([FromBody] TraineeMembershipDto TraineeMembership)
    {
        var command = new UpdateTraineeMembershipCommand { TraineeMembershipDto = TraineeMembership };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-traineeMembership/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTraineeMembershipCommand { TraineeMembershipId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<TraineeMembershipDto>>> getdatabytraineeid(int Traineeid)
    {
        var TraineeMemberships = await _mediator.Send(new GetTraineeMembershipListByTraineeRequest { Traineeid = Traineeid });
        return Ok(TraineeMemberships);
    }
}
