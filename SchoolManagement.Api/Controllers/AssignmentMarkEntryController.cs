using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.AssignmentMarkEntry;
using SchoolManagement.Application.Features.AssignmentMarkEntrys.Requests.Commands;
using SchoolManagement.Application.Features.AssignmentMarkEntrys.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.AssignmentMarkEntry)]
[ApiController]
[Authorize]
public class AssignmentMarkEntryController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssignmentMarkEntryController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-AssignmentMarkEntries")]
    public async Task<ActionResult<List<AssignmentMarkEntryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var AssignmentMarkEntrys = await _mediator.Send(new GetAssignmentMarkEntryListRequest { QueryParams = queryParams });
        return Ok(AssignmentMarkEntrys);
    }



    [HttpGet]
    [Route("get-AssignmentMarkEntryDetail/{id}")]
    public async Task<ActionResult<AssignmentMarkEntryDto>> Get(int id)
    {
        var AssignmentMarkEntry = await _mediator.Send(new GetAssignmentMarkEntryDetailRequest { AssignmentMarkEntryId = id });
        return Ok(AssignmentMarkEntry);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-AssignmentMarkEntry")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAssignmentMarkEntryDto AssignmentMarkEntry)
    {
        var command = new CreateAssignmentMarkEntryCommand { AssignmentMarkEntryDto = AssignmentMarkEntry };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-AssignmentMarkEntry/{id}")]
    public async Task<ActionResult> Put([FromBody] AssignmentMarkEntryDto AssignmentMarkEntry)
    {
        var command = new UpdateAssignmentMarkEntryCommand { AssignmentMarkEntryDto = AssignmentMarkEntry };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-AssignmentMarkEntry/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAssignmentMarkEntryCommand { AssignmentMarkEntryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    
}

