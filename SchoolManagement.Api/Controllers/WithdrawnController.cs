using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.WithdrawnType;
using SchoolManagement.Application.Features.WithdrawnTypes.Requests.Commands;
using SchoolManagement.Application.Features.WithdrawnTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.WithdrawnType)]
[ApiController]
[Authorize]
public class WithdrawnTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public WithdrawnTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-WithdrawnTypes")]
    public async Task<ActionResult<List<WithdrawnTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var WithdrawnTypes = await _mediator.Send(new GetWithdrawnTypeListRequest { QueryParams = queryParams });
        return Ok(WithdrawnTypes);
    }


    [HttpGet]
    [Route("get-WithdrawnTypeDetail/{id}")]
    public async Task<ActionResult<WithdrawnTypeDto>> Get(int id)
    {
        var WithdrawnType = await _mediator.Send(new GetWithdrawnTypeDetailRequest { WithdrawnTypeId = id });
        return Ok(WithdrawnType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-WithdrawnType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateWithdrawnTypeDto WithdrawnType)
    {
        var command = new CreateWithdrawnTypeCommand { WithdrawnTypeDto = WithdrawnType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-WithdrawnType/{id}")]
    public async Task<ActionResult> Put([FromBody] WithdrawnTypeDto WithdrawnType)
    {
        var command = new UpdateWithdrawnTypeCommand { WithdrawnTypeDto = WithdrawnType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-WithdrawnType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteWithdrawnTypeCommand { WithdrawnTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedWithdrawnTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedWithdrawnType()
    {
        var selectedWithdrawnType = await _mediator.Send(new GetSelectedWithdrawnTypeRequest { });
        return Ok(selectedWithdrawnType);
    }
}

