using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Allowance;
using SchoolManagement.Application.Features.Allowances.Requests.Commands;
using SchoolManagement.Application.Features.Allowances.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Allowance)]
[ApiController]
[Authorize]
public class AllowanceController : ControllerBase
{
    private readonly IMediator _mediator;

    public AllowanceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-Allowances")]
    public async Task<ActionResult<List<AllowanceDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Allowances = await _mediator.Send(new GetAllowanceListRequest { QueryParams = queryParams });
        return Ok(Allowances);
    }


    [HttpGet]
    [Route("get-AllowanceDetail/{id}")]
    public async Task<ActionResult<AllowanceDto>> Get(int id)
    {
        var Allowance = await _mediator.Send(new GetAllowanceDetailRequest { AllowanceId = id });
        return Ok(Allowance);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Allowance")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAllowanceDto Allowance)
    {
        var command = new CreateAllowanceCommand { AllowanceDto = Allowance };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Allowance/{id}")]
    public async Task<ActionResult> Put([FromBody] AllowanceDto Allowance)
    {
        var command = new UpdateAllowanceCommand { AllowanceDto = Allowance };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Allowance/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAllowanceCommand { AllowanceId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedAllowances")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAllowance()
    {
        var selectedAllowance = await _mediator.Send(new GetSelectedAllowanceRequest { });
        return Ok(selectedAllowance);
    }
    //[HttpGet]
    //[Route("get-AllowanceListByFromRankIdAndToRankId")]
    //public async Task<ActionResult<List<AllowanceDto>>> GetAllowanceListByFromRankIdAndToRankId(int fromRankId, int toRankId)
    //{
    //    var Allowances = await _mediator.Send(new GetAllowanceListByFromRankIdAndToRankIdRequest
    //    {
    //        FromRankId = fromRankId,
    //        ToRankId = toRankId
    //    });
    //    return Ok(Allowances);
    //}
}

