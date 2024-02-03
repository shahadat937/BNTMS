using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaServiceType;
using SchoolManagement.Application.Features.BnaServiceTypes.Requests.Commands;
using SchoolManagement.Application.Features.BnaServiceTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaServiceType)]
[ApiController]
[Authorize]
public class BnaServiceTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaServiceTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaServiceTypes")]
    public async Task<ActionResult<List<BnaServiceTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaServiceTypes = await _mediator.Send(new GetBnaServiceTypeListRequest { QueryParams = queryParams });
        return Ok(BnaServiceTypes);
    }

    [HttpGet]
    [Route("get-bnaServiceTypeDetail/{id}")]
    public async Task<ActionResult<BnaServiceTypeDto>> Get(int id)
    {
        var BnaServiceTypes = await _mediator.Send(new GetBnaServiceTypeDetailRequest { BnaServiceTypeId = id });
        return Ok(BnaServiceTypes);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaServiceType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaServiceTypeDto BnaServiceType)
    {
        var command = new CreateBnaServiceTypeCommand { BnaServiceTypeDto = BnaServiceType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaServiceType/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaServiceTypeDto BnaServiceType)
    {
        var command = new UpdateBnaServiceTypeCommand { BnaServiceTypeDto = BnaServiceType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaServiceType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaServiceTypeCommand { BnaServiceTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBnaServiceTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBnaServiceType()
    {
        var BnaServiceType = await _mediator.Send(new GetSelectedBnaServiceTypeRequest { });
        return Ok(BnaServiceType);
    }
}

