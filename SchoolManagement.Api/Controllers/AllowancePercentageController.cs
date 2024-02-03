using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.AllowancePercentage;
using SchoolManagement.Application.Features.AllowancePercentages.Requests.Commands;
using SchoolManagement.Application.Features.AllowancePercentages.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.AllowancePercentage)]
[ApiController]
[Authorize]
public class AllowancePercentageController : ControllerBase
{
    private readonly IMediator _mediator;

    public AllowancePercentageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-AllowancePercentages")]
    public async Task<ActionResult<List<AllowancePercentageDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var AllowancePercentages = await _mediator.Send(new GetAllowancePercentageListRequest { QueryParams = queryParams });
        return Ok(AllowancePercentages);
    }


    [HttpGet]
    [Route("get-AllowancePercentageDetail/{id}")]
    public async Task<ActionResult<AllowancePercentageDto>> Get(int id)
    {
        var AllowancePercentage = await _mediator.Send(new GetAllowancePercentageDetailRequest { AllowancePercentageId = id });
        return Ok(AllowancePercentage);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-AllowancePercentage")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAllowancePercentageDto AllowancePercentage)
    {
        var command = new CreateAllowancePercentageCommand { AllowancePercentageDto = AllowancePercentage };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-AllowancePercentage/{id}")]
    public async Task<ActionResult> Put([FromBody] AllowancePercentageDto AllowancePercentage)
    {
        var command = new UpdateAllowancePercentageCommand { AllowancePercentageDto = AllowancePercentage };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-AllowancePercentage/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAllowancePercentageCommand { AllowancePercentageId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedAllowancePercentages")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAllowancePercentage()
    {
        var selectedAllowancePercentage = await _mediator.Send(new GetSelectedAllowancePercentageRequest { });
        return Ok(selectedAllowancePercentage);
    }
}

