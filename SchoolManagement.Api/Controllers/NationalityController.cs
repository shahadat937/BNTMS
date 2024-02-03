using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Nationality;
using SchoolManagement.Application.Features.Nationalitys.Requests.Commands;
using SchoolManagement.Application.Features.Nationalitys.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Nationality)]
[ApiController]
[Authorize]
public class NationalityController : ControllerBase
{
    private readonly IMediator _mediator;

    public NationalityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-nationalities")]
    public async Task<ActionResult<List<NationalityDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Nationalitys = await _mediator.Send(new GetNationalityListRequest { QueryParams = queryParams });
        return Ok(Nationalitys);
    }

    [HttpGet]
    [Route("get-nationalityDetail/{id}")]
    public async Task<ActionResult<NationalityDto>> Get(int id)
    {
        var Nationality = await _mediator.Send(new GetNationalityDetailRequest { NationalityId = id });
        return Ok(Nationality);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-nationality")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateNationalityDto Nationality)
    {
        var command = new CreateNationalityCommand { NationalityDto = Nationality };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-nationality/{id}")]
    public async Task<ActionResult> Put([FromBody] NationalityDto Nationality)
    {
        var command = new UpdateNationalityCommand { NationalityDto = Nationality };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-nationality/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteNationalityCommand { NationalityId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedNationalities")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedNationality()
    {
        var occupationType = await _mediator.Send(new GetSelectedNationalityRequest { });
        return Ok(occupationType);
    }

}

