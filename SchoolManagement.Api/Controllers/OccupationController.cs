using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Occupation;
using SchoolManagement.Application.Features.Occupations.Requests.Commands;
using SchoolManagement.Application.Features.Occupations.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers; 

[Route(SMSRoutePrefix.Occupation)]
[ApiController]
[Authorize]
public class OccupationController : ControllerBase
{
    private readonly IMediator _mediator;

    public OccupationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-occupations")]
    public async Task<ActionResult<List<OccupationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Occupations = await _mediator.Send(new GetOccupationListRequest { QueryParams = queryParams });
        return Ok(Occupations);
    }



    [HttpGet]
    [Route("get-occupationDetail/{id}")]
    public async Task<ActionResult<OccupationDto>> Get(int id)
    {
        var Occupation = await _mediator.Send(new GetOccupationDetailRequest { OccupationId = id });
        return Ok(Occupation);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-occupation")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateOccupationDto Occupation)
    {
        var command = new CreateOccupationCommand { OccupationDto = Occupation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-occupation/{id}")]
    public async Task<ActionResult> Put([FromBody] OccupationDto Occupation)
    {
        var command = new UpdateOccupationCommand { OccupationDto = Occupation };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-occupation/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteOccupationCommand { OccupationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedOccupation")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedOccupation()
    {
        var occupationType = await _mediator.Send(new GetSelectedOccupationRequest { });
        return Ok(occupationType);
    }
}

