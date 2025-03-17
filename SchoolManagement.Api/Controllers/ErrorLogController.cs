using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ErrorLog;
using SchoolManagement.Application.Features.ErrorLogs.Requests.Commands;
using SchoolManagement.Application.Features.ErrorLogs.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ErrorLog)]
[ApiController]
[Authorize]
public class ErrorLogController : ControllerBase
{
    private readonly IMediator _mediator;

    public ErrorLogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-ErrorLogs")]
    public async Task<ActionResult<List<ErrorLogDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ErrorLogs = await _mediator.Send(new GetErrorLogListRequest { QueryParams = queryParams });
        return Ok(ErrorLogs);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ErrorLog/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteErrorLogCommand { ErrorLogId = id };
        await _mediator.Send(command);
        return NoContent();
    }

}

