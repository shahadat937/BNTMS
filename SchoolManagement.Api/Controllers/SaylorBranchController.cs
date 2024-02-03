using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SaylorBranch;
using SchoolManagement.Application.Features.SaylorBranchs.Requests.Commands;
using SchoolManagement.Application.Features.SaylorBranchs.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SaylorBranch)]
[ApiController]
[Authorize]
public class SaylorBranchController : ControllerBase
{
    private readonly IMediator _mediator;

    public SaylorBranchController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-SaylorBranchs")]
    public async Task<ActionResult<List<SaylorBranchDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var SaylorBranchs = await _mediator.Send(new GetSaylorBranchListRequest { QueryParams = queryParams });
        return Ok(SaylorBranchs);
    }

    

    [HttpGet]
    [Route("get-SaylorBranchDetail/{id}")]
    public async Task<ActionResult<SaylorBranchDto>> Get(int id)
    {
        var SaylorBranch = await _mediator.Send(new GetSaylorBranchDetailRequest { SaylorBranchId = id });
        return Ok(SaylorBranch);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-SaylorBranch")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSaylorBranchDto SaylorBranch)
    {
        var command = new CreateSaylorBranchCommand { SaylorBranchDto = SaylorBranch };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-SaylorBranch/{id}")]
    public async Task<ActionResult> Put([FromBody] SaylorBranchDto SaylorBranch)
    {
        var command = new UpdateSaylorBranchCommand { SaylorBranchDto = SaylorBranch };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-SaylorBranch/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSaylorBranchCommand { SaylorBranchId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedSaylorBranchs")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedSaylorBranch()
    {
        var selectedSaylorBranch = await _mediator.Send(new GetSelectedSaylorBranchRequest { });
        return Ok(selectedSaylorBranch);
    }
}

