using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaBatch;
using SchoolManagement.Application.Features.BnaBatches.Requests.Commands;
using SchoolManagement.Application.Features.BnaBatches.Requests.Queries;
using SchoolManagement.Application.Features.BnaSemesters.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaBatch)]
[ApiController]
[Authorize]
public class BnaBatchController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaBatchController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaBatchs")]
    public async Task<ActionResult<List<BnaBatchDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaBatches = await _mediator.Send(new GetBnaBatchListRequest { QueryParams = queryParams });
        return Ok(BnaBatches);
    }

    [HttpGet]
    [Route("get-bnaBatchDetail/{id}")]
    public async Task<ActionResult<BnaBatchDto>> Get(int id)
    {
        var BnaBatch = await _mediator.Send(new GetBnaBatchDetailRequest { BnaBatchId = id });
        return Ok(BnaBatch);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaBatch")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaBatchDto BnaBatch)
    {
        var command = new CreateBnaBatchCommand { BnaBatchDto = BnaBatch };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaBatch/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaBatchDto BnaBatch)
    {
        var command = new UpdateBnaBatchCommand { BnaBatchDto = BnaBatch };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaBatch/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaBatchCommand { BnaBatchId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedBnaBatchs")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBnaBatch()
    {
        var BnaBatch = await _mediator.Send(new GetSelectedBnaBatchRequest { });
        return Ok(BnaBatch);
    }
}

