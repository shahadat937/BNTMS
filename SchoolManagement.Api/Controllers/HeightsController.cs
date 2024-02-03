using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Features.Heights.Requests.Commands;
using SchoolManagement.Application.Features.Heights.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Height)]
[ApiController]
[Authorize]
public class HeightsController : ControllerBase
{
    private readonly IMediator _mediator;

    public HeightsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-heights")]
    public async Task<ActionResult<List<HeightDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var heights = await _mediator.Send(new GetHeightsListRequest { QueryParams = queryParams });
        return Ok(heights);
    }

    [HttpGet]
    [Route("get-heightDetail/{id}")]
    public async Task<ActionResult<HeightDto>> Get(int id)
    {
        var heights = await _mediator.Send(new GetHeightsDetailRequest { Id = id });
        return Ok(heights);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-height")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateHeightDto height)
    {
        var command = new CreateHeightsCommand { HeightDto = height };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-height/{id}")]
    public async Task<ActionResult> Put([FromBody] HeightDto height)
    {
        var command = new UpdateHeightsCommand { HeightDto = height };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-height/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteHeightsCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }



    [HttpGet]
    [Route("get-selectedHeight")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedHeight()
    {
        var height = await _mediator.Send(new GetSelectedHeightRequest { });
        return Ok(height);
    }

}

