using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MembershipTypes;
using SchoolManagement.Application.Features.MembershipTypes.Requests.Commands;
using SchoolManagement.Application.Features.MembershipTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;
 
[Route(SMSRoutePrefix.MembershipType)]
[ApiController]
[Authorize]
public class MembershipTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public MembershipTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-membershipTypes")]
    public async Task<ActionResult<List<MembershipTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MembershipTypes = await _mediator.Send(new GetMembershipTypeListRequest { QueryParams = queryParams });
        return Ok(MembershipTypes);
    }


    [HttpGet]
    [Route("get-membershipTypeDetail/{id}")]
    public async Task<ActionResult<MembershipTypeDto>> Get(int id)
    {
        var MembershipType = await _mediator.Send(new GetMembershipTypeDetailRequest { Id = id });
        return Ok(MembershipType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-membershipType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMembershipTypeDto MembershipType)
    {
        var command = new CreateMembershipTypeCommand { MembershipTypeDto = MembershipType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-membershipType/{id}")]
    public async Task<ActionResult> Put([FromBody] MembershipTypeDto MembershipType)
    {
        var command = new UpdateMembershipTypeCommand { MembershipTypeDto = MembershipType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-membershipType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMembershipTypeCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedMembershipType")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedMembershipType()
    {
        var codeValueByType = await _mediator.Send(new GetSelectedMembershipTypeRequest { });
        return Ok(codeValueByType);
    }
}

