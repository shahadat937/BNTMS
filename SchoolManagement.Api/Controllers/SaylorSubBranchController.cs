using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SaylorSubBranch;
using SchoolManagement.Application.Features.SaylorSubBranchs.Requests.Commands;
using SchoolManagement.Application.Features.SaylorSubBranchs.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SaylorSubBranch)]
[ApiController]
[Authorize]
public class SaylorSubBranchController : ControllerBase
{
    private readonly IMediator _mediator;

    public SaylorSubBranchController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-SaylorSubBranchs")]
    public async Task<ActionResult<List<SaylorSubBranchDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var SaylorSubBranchs = await _mediator.Send(new GetSaylorSubBranchListRequest { QueryParams = queryParams });
        return Ok(SaylorSubBranchs);
    }

    

    [HttpGet]
    [Route("get-SaylorSubBranchDetail/{id}")]
    public async Task<ActionResult<SaylorSubBranchDto>> Get(int id)
    {
        var SaylorSubBranch = await _mediator.Send(new GetSaylorSubBranchDetailRequest { SaylorSubBranchId = id });
        return Ok(SaylorSubBranch);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-SaylorSubBranch")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSaylorSubBranchDto SaylorSubBranch)
    {
        var command = new CreateSaylorSubBranchCommand { SaylorSubBranchDto = SaylorSubBranch };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-SaylorSubBranch/{id}")]
    public async Task<ActionResult> Put([FromBody] SaylorSubBranchDto SaylorSubBranch)
    {
        var command = new UpdateSaylorSubBranchCommand { SaylorSubBranchDto = SaylorSubBranch };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-SaylorSubBranch/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSaylorSubBranchCommand { SaylorSubBranchId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedSaylorSubBranchs")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedSaylorSubBranch()
    {
        var selectedSaylorSubBranch = await _mediator.Send(new GetSelectedSaylorSubBranchRequest { });
        return Ok(selectedSaylorSubBranch);
    }

    [HttpGet]
    [Route("get-selectedSubBranchBySaylorBranchId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSubBranchBySaylorBranchId(int saylorBranchId)
    {
        var countryByCountryGroup = await _mediator.Send(new GetSubBranchBySaylorBranchIdRequest { SaylorBranchId = saylorBranchId });
        return Ok(countryByCountryGroup);
    }
}

