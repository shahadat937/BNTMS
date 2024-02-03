using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CoCurricularActivityType;
using SchoolManagement.Application.Features.CoCurricularActivityTypes.Requests.Commands;
using SchoolManagement.Application.Features.CoCurricularActivityTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CoCurricularActivityType)]
[ApiController]
[Authorize]
public class CoCurricularActivityTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoCurricularActivityTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-coCurricularActivityTypes")]
    public async Task<ActionResult<List<CoCurricularActivityTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CoCurricularActivityTypes = await _mediator.Send(new GetCoCurricularActivityTypeListRequest { QueryParams = queryParams });
        return Ok(CoCurricularActivityTypes);
    }

    [HttpGet]
    [Route("get-coCurricularActivityTypeDetail/{id}")]
    public async Task<ActionResult<CoCurricularActivityTypeDto>> Get(int id)
    {
        var CoCurricularActivityTypes = await _mediator.Send(new GetCoCurricularActivityTypeDetailRequest { CoCurricularActivityTypeId = id });
        return Ok(CoCurricularActivityTypes);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-coCurricularActivityType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCoCurricularActivityTypeDto CoCurricularActivityType)
    {
        var command = new CreateCoCurricularActivityTypeCommand { CoCurricularActivityTypeDto = CoCurricularActivityType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-coCurricularActivityType/{id}")]
    public async Task<ActionResult> Put([FromBody] CoCurricularActivityTypeDto CoCurricularActivityType)
    {
        var command = new UpdateCoCurricularActivityTypeCommand { CoCurricularActivityTypeDto = CoCurricularActivityType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-coCurricularActivityType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCoCurricularActivityTypeCommand { CoCurricularActivityTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedCoCurricularActivityType")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCoCurricularActivityType()
    {
        var CoCurricularActivityType = await _mediator.Send(new GetSelectedCoCurricularActivityTypeRequest { });
        return Ok(CoCurricularActivityType);
    }
}

