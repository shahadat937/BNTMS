using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.AdminAuthority;
using SchoolManagement.Application.Features.AdminAuthoritys.Requests.Commands;
using SchoolManagement.Application.Features.AdminAuthoritys.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.AdminAuthority)]
[ApiController]
[Authorize]
public class AdminAuthorityController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminAuthorityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-adminAuthorities")]
    public async Task<ActionResult<List<AdminAuthorityDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var AdminAuthoritys = await _mediator.Send(new GetAdminAuthorityListRequest { QueryParams = queryParams });
        return Ok(AdminAuthoritys);
    }



    [HttpGet]
    [Route("get-AdminAuthorityDetail/{id}")]
    public async Task<ActionResult<AdminAuthorityDto>> Get(int id)
    {
        var AdminAuthority = await _mediator.Send(new GetAdminAuthorityDetailRequest { AdminAuthorityId = id });
        return Ok(AdminAuthority);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-adminAuthority")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAdminAuthorityDto AdminAuthority)
    {
        var command = new CreateAdminAuthorityCommand { AdminAuthorityDto = AdminAuthority };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-adminAuthority/{id}")]

    public async Task<ActionResult> Put([FromBody] AdminAuthorityDto AdminAuthority)
    {
        var command = new UpdateAdminAuthorityCommand { AdminAuthorityDto = AdminAuthority };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-adminAuthority/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAdminAuthorityCommand { AdminAuthorityId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedAdminAuthorities")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedadminauthority()
    {
        var selectedadminauthority = await _mediator.Send(new GetSelectedAdminAuthorityRequest { });
        return Ok(selectedadminauthority);
    }
}

