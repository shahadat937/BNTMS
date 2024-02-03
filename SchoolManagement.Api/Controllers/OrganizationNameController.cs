using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.OrganizationName;
using SchoolManagement.Application.Features.OrganizationNames.Requests.Commands;
using SchoolManagement.Application.Features.OrganizationNames.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers; 

[Route(SMSRoutePrefix.OrganizationName)]
[ApiController]
[Authorize]
public class OrganizationNameController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrganizationNameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-OrganizationNames")]
    public async Task<ActionResult<List<OrganizationNameDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var OrganizationNames = await _mediator.Send(new GetOrganizationNameListRequest { QueryParams = queryParams });
        return Ok(OrganizationNames);
    }



    [HttpGet]
    [Route("get-OrganizationNameDetail/{id}")]
    public async Task<ActionResult<OrganizationNameDto>> Get(int id)
    {
        var OrganizationName = await _mediator.Send(new GetOrganizationNameDetailRequest { OrganizationNameId = id });
        return Ok(OrganizationName);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-OrganizationName")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateOrganizationNameDto OrganizationName)
    {
        var command = new CreateOrganizationNameCommand { OrganizationNameDto = OrganizationName };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-OrganizationName/{id}")]
    public async Task<ActionResult> Put([FromBody] OrganizationNameDto OrganizationName)
    {
        var command = new UpdateOrganizationNameCommand { OrganizationNameDto = OrganizationName };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-OrganizationName/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteOrganizationNameCommand { OrganizationNameId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedOrganizationName")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedOrganizationName()
    {
        var OrganizationNameType = await _mediator.Send(new GetSelectedOrganizationNameRequest { });
        return Ok(OrganizationNameType);
    }
    
    [HttpGet]
    [Route("get-autocompleteOrganizationName")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompleteOrganizationName(string name)
    {
        var course = await _mediator.Send(new GetAutoCompleteOrganizationNameRequest
        {
            Name = name,
        });
        return Ok(course);
    }
}

