using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BudgetType;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.BudgetTypes.Requests.Commands;
using SchoolManagement.Application.Features.BudgetTypes.Requests.Queries;
using SchoolManagement.Shared.Models;
using SchoolManagement.Application.DTOs.BudgetAllocation;
using SchoolManagement.Application.Features.BudgetAllocations.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.Features.BudgetAllocations.Requests.Commands;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BudgetAllocation)]
[ApiController]
[Authorize]

public class BudgetTransactionController:ControllerBase
{
    private readonly IMediator _mediator;

    public BudgetTransactionController(IMediator mediator)
        {
        _mediator = mediator;
        }

    [HttpGet]
    [Route("get-budgetAllocation")]
    public async Task<ActionResult<List<BudgetAllocationDto>>> Get([FromQuery] QueryParams queryParams, int budgetCodeId, int fiscalYearId)
    {
        var BudgetTransaction = await _mediator.Send(new GetBudgetAllocationListRequest
        {
            QueryParams = queryParams,
            FiscalYearId = fiscalYearId,
            BudgetCodeId = budgetCodeId
        });
        return Ok(BudgetTransaction);
    }

    [HttpGet]
    [Route("get_budgetAllocation/id")]

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

}
