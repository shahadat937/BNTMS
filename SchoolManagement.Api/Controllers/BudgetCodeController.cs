using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BudgetCode;
using SchoolManagement.Application.Features.BudgetCodess.Requests.Commands;
using SchoolManagement.Application.Features.BudgetCodess.Requests.Queries;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BudgetCode)]
[ApiController]
[Authorize]
public class BudgetCodeController : ControllerBase
{
    private readonly IMediator _mediator;

    public BudgetCodeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-budgetCodes")]
    public async Task<ActionResult<List<BudgetCodeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BudgetCodes = await _mediator.Send(new GetBudgetCodeListRequest { QueryParams = queryParams });
        return Ok(BudgetCodes);
    }

    [HttpGet]
    [Route("get-budgetCodesRequest")]
    public async Task<ActionResult<List<BudgetCodeDto>>> SelectedBudgetCodeByCourseNameIdSubjectNameId()
    {
        var budgetCodes = await _mediator.Send(new GetBudgetCodeRequest
        {
        });
        return Ok(budgetCodes); 
    }


    [HttpGet]
    [Route("get-budgetCodeDetail/{id}")]
    public async Task<ActionResult<BudgetCodeDto>> Get(int id)
    {
        var BudgetCode = await _mediator.Send(new GetBudgetCodeDetailRequest { BudgetCodeId = id });
        return Ok(BudgetCode);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-budgetCode")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBudgetCodeDto BudgetCode)
    {
        var command = new CreateBudgetCodeCommand { BudgetCodeDto = BudgetCode };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-budgetCode/{id}")]
    public async Task<ActionResult> Put([FromBody] BudgetCodeDto BudgetCode)
    {
        var command = new UpdateBudgetCodeCommand { BudgetCodeDto = BudgetCode };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-budgetCode/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBudgetCodeCommand { BudgetCodeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBudgetCodes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBudgetCode()
    {
        var BudgetCode = await _mediator.Send(new GetSelectedBudgetCodeRequest { });
        return Ok(BudgetCode);
    }
     
    [HttpGet]
    [Route("get-selectedBudgetCodeByParameterRequestFromClassRoutine")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBudgetCode(int baseSchoolNameId, int courseNameId)
    {
        var ClassPeriodName = await _mediator.Send(new GetSelectedBudgetCodeByParametersFromClassRoutineRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(ClassPeriodName);
    }

    [HttpGet]
    [Route("get-selectedBudgetCodeByBudgetCodeIdRequest")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBudgetCodeByBudgetCodeIdRequest(int budgetCodeId)
    {
        var budgetCodeName = await _mediator.Send(new GetSelectedBudgetCodeByBudgetCodeIdRequest
        {
            BudgetCodeId = budgetCodeId
        }); 
        return Ok(budgetCodeName); 
    } 

    [HttpGet]
    [Route("get-totalBudgetByBudgetCodeIdRequest")]
    public async Task<ActionResult<List<SelectedModel>>> GetTotalBudgetByBudgetCodeIdRequest(int budgetCodeId)
    {
        var budgetCodeName = await _mediator.Send(new GetTotalBudgetByBudgetCodeIdRequest
        {
            BudgetCodeId = budgetCodeId
        });
        return Ok(budgetCodeName);
    }
     
    [HttpGet] 
    [Route("get-targetAmountByBudgetCodeIdRequest")]
    public async Task<ActionResult<List<SelectedModel>>> GetTargetAmountByBudgetCodeIdRequest(int budgetCodeId)
    {
        var budgetCodeName = await _mediator.Send(new GetTargetAmountByBudgetCodeIdRequest
        {
            BudgetCodeId = budgetCodeId
        });
        return Ok(budgetCodeName); 
    }


    [HttpGet]
    [Route("get-availableAmountByBudgetCodeIdRequest")]
    public async Task<ActionResult<List<SelectedModel>>> availableAmountByBudgetCodeId(int budgetCodeId)
    {
        var budgetCodeName = await _mediator.Send(new GetAvailableBalanceByBudgetCodeIdRequest
        {
            BudgetCodeId = budgetCodeId
        });
        return Ok(budgetCodeName); 
    }
}

