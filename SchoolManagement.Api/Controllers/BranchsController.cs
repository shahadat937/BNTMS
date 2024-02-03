using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Branch)]
[ApiController]
[Authorize]
public class BranchsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BranchsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-branchs")]
    public async Task<ActionResult<List<BranchDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var branches = await _mediator.Send(new GetBranchListRequest { QueryParams = queryParams });
        return Ok(branches);
    }

    [HttpGet]
    [Route("get-branchDetail/{id}")]
    public async Task<ActionResult<BranchDto>> Get(int id)
    {
        var branch = await _mediator.Send(new GetBranchDetailRequest { Id = id });
        return Ok(branch);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-branch")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBranchDto branch)
    {
        var command = new CreateBranchCommand { BranchDto = branch };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-branch/{id}")]
    public async Task<ActionResult> Put([FromBody] BranchDto branch)
    {
        var command = new UpdateBranchCommand { BranchDto = branch };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-branch/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBranchCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedBranchs")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBranch()
    {
        var selectedBranch = await _mediator.Send(new GetSelectedBranchRequest { });
        return Ok(selectedBranch);
    }
    [HttpGet]
    [Route("get-selectedBranchForJCOs")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBranchForJCOs()
    {
        var selectedBranch = await _mediator.Send(new GetSelectedBranchForJCOsRequest { });
        return Ok(selectedBranch);
    }
}