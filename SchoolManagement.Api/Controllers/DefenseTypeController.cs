using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.DefenseType;
using SchoolManagement.Application.Features.DefenseTypes.Requests.Commands;
using SchoolManagement.Application.Features.DefenseTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.DefenseType)]
[ApiController]
[Authorize]
public class DefenseTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public DefenseTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-defenseTypes")]
    public async Task<ActionResult<List<DefenseTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var DefenseTypes = await _mediator.Send(new GetDefenseTypeListRequest { QueryParams = queryParams });
        return Ok(DefenseTypes);
    }

    [HttpGet]
    [Route("get-defenseTypeDetail/{id}")]
    public async Task<ActionResult<DefenseTypeDto>> Get(int id)
    {
        var DefenseType = await _mediator.Send(new GetDefenseTypeDetailRequest { DefenseTypeId = id });
        return Ok(DefenseType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-defenseType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDefenseTypeDto DefenseType)
    {
        var command = new CreateDefenseTypeCommand { DefenseTypeDto = DefenseType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-defenseType/{id}")]
    public async Task<ActionResult> Put([FromBody] DefenseTypeDto DefenseType)
    {
        var command = new UpdateDefenseTypeCommand { DefenseTypeDto = DefenseType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-defenseType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDefenseTypeCommand { DefenseTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }
    // relational data get 
    [HttpGet]
    [Route("get-selectedDefenseTypes")]
    public async Task<ActionResult<List<SelectedModel>>> getselecteddefensetype()
    {
        var selectedDefenseType = await _mediator.Send(new GetSelectedDefenseTypeRequest { });
        return Ok(selectedDefenseType);
    }
}

