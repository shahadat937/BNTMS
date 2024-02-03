using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Weight;
using SchoolManagement.Application.Features.Weights.Requests.Commands;
using SchoolManagement.Application.Features.Weights.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Weights)]
[ApiController]
[Authorize]
public class WeightsController : ControllerBase
{
    private readonly IMediator _mediator;

    public WeightsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-weights")]
    public async Task<ActionResult<List<WeightDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var weights = await _mediator.Send(new GetWeightsListRequest { QueryParams = queryParams });
        return Ok(weights);
    }

    [HttpGet]
    [Route("get-weightDetail/{id}")]
    public async Task<ActionResult<WeightDto>> Get(int id)
    {
        var weights = await _mediator.Send(new GetWeightsDetailRequest { Id = id });
        return Ok(weights);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-weight")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateWeightDto weight)
    {
        var command = new CreateWeightsCommand { WeightDto = weight };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-weight/{id}")]
    public async Task<ActionResult> Put([FromBody] WeightDto weight)
    {
        var command = new UpdateWeightCommand { WeightDto = weight };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-weight/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteWeightCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [Route("get-selectedWeights")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedWeight()
    {
        var Weight = await _mediator.Send(new GetSelectedWeightRequest { });
        return Ok(Weight);
    }
}

