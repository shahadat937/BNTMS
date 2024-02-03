using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CountryGroup;
using SchoolManagement.Application.Features.CountryGroups.Requests.Commands;
using SchoolManagement.Application.Features.CountryGroups.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CountryGroup)]
[ApiController]
[Authorize]
public class CountryGroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public CountryGroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-CountryGroups")]
    public async Task<ActionResult<List<CountryGroupDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CountryGroups = await _mediator.Send(new GetCountryGroupListRequest { QueryParams = queryParams });
        return Ok(CountryGroups);
    }


    [HttpGet]
    [Route("get-CountryGroupDetail/{id}")]
    public async Task<ActionResult<CountryGroupDto>> Get(int id)
    {
        var CountryGroup = await _mediator.Send(new GetCountryGroupDetailRequest { CountryGroupId = id });
        return Ok(CountryGroup);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-CountryGroup")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCountryGroupDto CountryGroup)
    {
        var command = new CreateCountryGroupCommand { CountryGroupDto = CountryGroup };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-CountryGroup/{id}")]
    public async Task<ActionResult> Put([FromBody] CountryGroupDto CountryGroup)
    {
        var command = new UpdateCountryGroupCommand { CountryGroupDto = CountryGroup };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-CountryGroup/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCountryGroupCommand { CountryGroupId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedCountryGroups")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCountryGroup()
    {
        var selectedCountryGroup = await _mediator.Send(new GetSelectedCountryGroupRequest { });
        return Ok(selectedCountryGroup);
    }
}

