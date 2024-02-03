using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.FinancialSanction;
using SchoolManagement.Application.Features.FinancialSanctions.Requests.Commands;
using SchoolManagement.Application.Features.FinancialSanctions.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.FinancialSanction)]
[ApiController]
[Authorize]
public class FinancialSanctionController : ControllerBase
{
    private readonly IMediator _mediator;

    public FinancialSanctionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-FinancialSanctions")]
    public async Task<ActionResult<List<FinancialSanctionDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var FinancialSanctions = await _mediator.Send(new GetFinancialSanctionListRequest { QueryParams = queryParams });
        return Ok(FinancialSanctions);
    }

    

    [HttpGet]
    [Route("get-FinancialSanctionDetail/{id}")]
    public async Task<ActionResult<FinancialSanctionDto>> Get(int id)
    {
        var FinancialSanction = await _mediator.Send(new GetFinancialSanctionDetailRequest { FinancialSanctionId = id });
        return Ok(FinancialSanction);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-FinancialSanction")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateFinancialSanctionDto FinancialSanction)
    {
        var command = new CreateFinancialSanctionCommand { FinancialSanctionDto = FinancialSanction };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-FinancialSanction/{id}")]
    public async Task<ActionResult> Put([FromBody] FinancialSanctionDto FinancialSanction)
    {
        var command = new UpdateFinancialSanctionCommand { FinancialSanctionDto = FinancialSanction };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-FinancialSanction/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteFinancialSanctionCommand { FinancialSanctionId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedFinancialSanctions")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedFinancialSanction()
    {
        var selectedFinancialSanction = await _mediator.Send(new GetSelectedFinancialSanctionRequest { });
        return Ok(selectedFinancialSanction);
    }

}

