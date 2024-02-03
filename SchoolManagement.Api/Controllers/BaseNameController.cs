using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BaseNames;
using SchoolManagement.Application.Features.BaseNames.Requests.Commands;
using SchoolManagement.Application.Features.BaseNames.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BaseName)]
[ApiController]
[Authorize]
public class BaseNameController : ControllerBase
{
    private readonly IMediator _mediator;

    public BaseNameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-baseNames")]
    public async Task<ActionResult<List<BaseNameDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BaseNames = await _mediator.Send(new GetBaseNameListRequest { QueryParams = queryParams });
        return Ok(BaseNames);
    }

    

    [HttpGet]
    [Route("get-baseNameDetail/{id}")]
    public async Task<ActionResult<BaseNameDto>> Get(int id)
    {
        var BaseName = await _mediator.Send(new GetBaseNameDetailRequest { Id = id });
        return Ok(BaseName);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-baseName")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBaseNameDto BaseName)
    {
        var command = new CreateBaseNameCommand { BaseNameDto = BaseName };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-baseName/{id}")]
    public async Task<ActionResult> Put([FromBody] BaseNameDto BaseName)
    {
        var command = new UpdateBaseNameCommand { BaseNameDto = BaseName };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-baseName/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBaseNameCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBases")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBaseName()
    {
        var baseNameValue = await _mediator.Send(new GetSelectedBaseNameRequest { });
        return Ok(baseNameValue);
    }

}

