using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MaritalStatus;
using SchoolManagement.Application.Features.MaritalStatuss.Requests.Commands;
using SchoolManagement.Application.Features.MaritalStatuss.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MaritalStatus)]
[ApiController]
[Authorize]
public class MaritalStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public MaritalStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-maritalStatuses")]
    public async Task<ActionResult<List<MaritalStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var maritalStatuse = await _mediator.Send(new GetMaritalStatusListRequest { QueryParams = queryParams });
        return Ok(maritalStatuse);
    }

    [HttpGet]
    [Route("get-maritalStatusDetail/{id}")]
    public async Task<ActionResult<MaritalStatusDto>> Get(int id)
    {
        var maritalStatus = await _mediator.Send(new GetMaritalStatusDetailRequest { Id = id });
        return Ok(maritalStatus);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-maritalStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMaritalStatusDto maritalStatus)
    {
        var command = new CreateMaritalStatusCommand { MaritalStatusDto = maritalStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-maritalStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] MaritalStatusDto maritalStatus)
    {
        var command = new UpdateMaritalStatusCommand { MaritalStatusDto = maritalStatus };
        await _mediator.Send(command);
        return NoContent(); 
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-maritalStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMaritalStatusCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedMaritialStatuses")] 
    public async Task<ActionResult<List<SelectedModel>>> getselectedmaritialstatus()
    {
        var relationType = await _mediator.Send(new GetSelectedMaritalStatusRequest { });
        return Ok(relationType);
    }


}

