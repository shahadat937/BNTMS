using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.WeekName;
using SchoolManagement.Application.Features.WeekNames.Requests.Commands;
using SchoolManagement.Application.Features.WeekNames.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.WeekName)]
[ApiController]
[Authorize]
public class WeekNameController : ControllerBase
{
    private readonly IMediator _mediator;

    public WeekNameController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-WeekNames")]
    public async Task<ActionResult<List<WeekNameDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var WeekNames = await _mediator.Send(new GetWeekNameListRequest { QueryParams = queryParams });
        return Ok(WeekNames);
    }



    [HttpGet]
    [Route("get-WeekNameDetail/{id}")]
    public async Task<ActionResult<WeekNameDto>> Get(int id)
    {
        var WeekName = await _mediator.Send(new GetWeekNameDetailRequest { WeekNameId = id });
        return Ok(WeekName);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-WeekName")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateWeekNameDto WeekName)
    {
        var command = new CreateWeekNameCommand { WeekNameDto = WeekName };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-WeekName/{id}")]
    public async Task<ActionResult> Put([FromBody] WeekNameDto WeekName)
    {
        var command = new UpdateWeekNameCommand { WeekNameDto = WeekName };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-WeekName/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteWeekNameCommand { WeekNameId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedWeekName")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedWeekName()
    {
        var WeekName = await _mediator.Send(new GetSelectedWeekNameRequest { });
        return Ok(WeekName);
    }
}

