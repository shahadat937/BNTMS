using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaClassTestType;
using SchoolManagement.Application.Features.BnaClassTestTypes.Requests.Commands;
using SchoolManagement.Application.Features.BnaClassTestTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaClassTestType)]
[ApiController]
[Authorize]
public class BnaClassTestTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaClassTestTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaClassTestTypes")]
    public async Task<ActionResult<List<BnaClassTestTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaClassTestTypes = await _mediator.Send(new GetBnaClassTestTypeListRequest { QueryParams = queryParams });
        return Ok(BnaClassTestTypes);
    }

    [HttpGet]
    [Route("get-bnaClassTestTypeDetail/{id}")]
    public async Task<ActionResult<BnaClassTestTypeDto>> Get(int id)
    {
        var BnaClassTestType = await _mediator.Send(new GetBnaClassTestTypeDetailRequest { BnaClassTestTypeId = id });
        return Ok(BnaClassTestType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaClassTestType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaClassTestTypeDto BnaClassTestType)
    {
        var command = new CreateBnaClassTestTypeCommand { BnaClassTestTypeDto = BnaClassTestType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaClassTestType/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaClassTestTypeDto BnaClassTestType)
    {
        var command = new UpdateBnaClassTestTypeCommand { BnaClassTestTypeDto = BnaClassTestType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaClassTestType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaClassTestTypeCommand { BnaClassTestTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBnaClassTestTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBnaClassTestType()
    {
        var BnaClassTestType = await _mediator.Send(new GetSelectedBnaClassTestTypeRequest { });
        return Ok(BnaClassTestType);
    }
}

