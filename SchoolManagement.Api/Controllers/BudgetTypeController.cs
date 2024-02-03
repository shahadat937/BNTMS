using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BudgetType;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.BudgetTypes.Requests.Commands;
using SchoolManagement.Application.Features.BudgetTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BudgetType)]
[ApiController]
[Authorize]
public class BudgetTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public BudgetTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-budgetTypes")]
    public async Task<ActionResult<List<BudgetTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BudgetTypes = await _mediator.Send(new GetBudgetTypeListRequest { QueryParams = queryParams });
        return Ok(BudgetTypes);
    }

    

    [HttpGet]
    [Route("get-budgetTypeDetail/{id}")]
    public async Task<ActionResult<BudgetTypeDto>> Get(int id)
    {
        var BudgetType = await _mediator.Send(new GetBudgetTypeDetailRequest { BudgetTypeId = id });
        return Ok(BudgetType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-budgetType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBudgetTypeDto BudgetType)
    {
        var command = new CreateBudgetTypeCommand { BudgetTypeDto = BudgetType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-budgetType/{id}")]
    public async Task<ActionResult> Put([FromBody] BudgetTypeDto BudgetType)
    {
        var command = new UpdateBudgetTypeCommand { BudgetTypeDto = BudgetType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-budgetType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBudgetTypeCommand { BudgetTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBudgetTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBudgetType()
    {
        var BudgetType = await _mediator.Send(new GetSelectedBudgetTypeRequest { });
        return Ok(BudgetType);
    }
     
    [HttpGet]
    [Route("get-selectedBudgetTypeByParameterRequestFromClassRoutine")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBudgetType(int baseSchoolNameId, int courseNameId)
    {
        var ClassPeriodName = await _mediator.Send(new GetSelectedBudgetTypeByParametersFromClassRoutineRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(ClassPeriodName);
    }
}

