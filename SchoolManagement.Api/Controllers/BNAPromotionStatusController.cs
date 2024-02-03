using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaPromotionStatus;
using SchoolManagement.Application.Features.BnaPromotionStatuses.Requests.Commands;
using SchoolManagement.Application.Features.BnaPromotionStatuses.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaPromotionStatus)]
[ApiController]
[Authorize]
public class BnaPromotionStatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaPromotionStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaPromotionStatuses")]
    public async Task<ActionResult<List<BnaPromotionStatusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaPromotionStatuses = await _mediator.Send(new GetBnaPromotionStatusListRequest { QueryParams = queryParams });
        return Ok(BnaPromotionStatuses);
    }


    [HttpGet]
    [Route("get-bnaPromotionStatusDetail/{id}")]
    public async Task<ActionResult<BnaPromotionStatusDto>> Get(int id)
    {
        var BnaPromotionStatuses = await _mediator.Send(new GetBnaPromotionStatusDetailRequest { BnaPromotionStatusId = id });
        return Ok(BnaPromotionStatuses);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaPromotionStatus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaPromotionStatusDto BnaPromotionStatus)
    {
        var command = new CreateBnaPromotionStatusCommand { BnaPromotionStatusDto = BnaPromotionStatus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaPromotionStatus/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaPromotionStatusDto BnaPromotionStatus)
    {
        var command = new UpdateBnaPromotionStatusCommand { BnaPromotionStatusDto = BnaPromotionStatus };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaPromotionStatus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaPromotionStatusCommand { BnaPromotionStatusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedBnaPromotionStatuses")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBnaPromotionStatus()
    {
        var promotionstatus = await _mediator.Send(new GetSelectedBnaPromotionStatusRequest { });
        return Ok(promotionstatus);
    }

}

