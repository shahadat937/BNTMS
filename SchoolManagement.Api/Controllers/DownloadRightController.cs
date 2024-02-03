using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.DownloadRight;
using SchoolManagement.Application.Features.DownloadRights.Requests.Commands;
using SchoolManagement.Application.Features.DownloadRights.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.DownloadRight)]
[ApiController]
[Authorize]
public class DownloadRightController : ControllerBase
{
    private readonly IMediator _mediator;

    public DownloadRightController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-downloadRights")]
    public async Task<ActionResult<List<DownloadRightDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var DownloadRights = await _mediator.Send(new GetDownloadRightListRequest { QueryParams = queryParams });
        return Ok(DownloadRights);
    }

    [HttpGet]
    [Route("get-downloadRightDetail/{id}")]
    public async Task<ActionResult<DownloadRightDto>> Get(int id)
    {
        var DownloadRight = await _mediator.Send(new GetDownloadRightDetailRequest { DownloadRightId = id });
        return Ok(DownloadRight);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-downloadRight")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDownloadRightDto DownloadRight)
    {
        var command = new CreateDownloadRightCommand { DownloadRightDto = DownloadRight };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-downloadRight/{id}")]
    public async Task<ActionResult> Put([FromBody] DownloadRightDto DownloadRight)
    {
        var command = new UpdateDownloadRightCommand { DownloadRightDto = DownloadRight };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-downloadRight/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDownloadRightCommand { DownloadRightId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 
    [HttpGet]
    [Route("get-selectedDownloadRights")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDownloadRight()
    {
        var DownloadRight = await _mediator.Send(new GetSelectedDownloadRightRequest { });
        return Ok(DownloadRight);
    }
}

