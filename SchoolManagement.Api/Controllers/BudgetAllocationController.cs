using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BudgetAllocation;
using SchoolManagement.Application.Features.BudgetAllocations.Requests.Commands;
using SchoolManagement.Application.Features.BudgetAllocations.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BudgetAllocation)]
[ApiController]
[Authorize]
public class BudgetAllocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public BudgetAllocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-BudgetAllocations")]
    public async Task<ActionResult<List<BudgetAllocationDto>>> Get([FromQuery] QueryParams queryParams,int budgetCodeId,int fiscalYearId)
    {
        var BudgetAllocations = await _mediator.Send(new GetBudgetAllocationListRequest
        {
            QueryParams = queryParams,
            FiscalYearId = fiscalYearId,
            BudgetCodeId = budgetCodeId
        });
        return Ok(BudgetAllocations);
    }

    

    [HttpGet]
    [Route("get-BudgetAllocationDetail/{id}")]
    public async Task<ActionResult<BudgetAllocationDto>> Get(int id)
    {
        var BudgetAllocations = await _mediator.Send(new GetBudgetAllocationDetailRequest { BudgetAllocationId = id });
        return Ok(BudgetAllocations);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-BudgetAllocation")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBudgetAllocationDto BudgetAllocation)
    {
        var command = new CreateBudgetAllocationCommand { BudgetAllocationDto = BudgetAllocation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-BudgetAllocation/{id}")]
    public async Task<ActionResult> Put([FromBody] BudgetAllocationDto BudgetAllocation)
    {
        var command = new UpdateBudgetAllocationCommand { BudgetAllocationDto = BudgetAllocation };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-BudgetAllocation/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBudgetAllocationCommand { BudgetAllocationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data

    [HttpGet]
    [Route("get-selectedBudgetAllocations")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBudgetAllocation()
    {
        var selectedBudgetAllocation = await _mediator.Send(new GetSelectedBudgetAllocationRequest { });
        return Ok(selectedBudgetAllocation);
    }
}

