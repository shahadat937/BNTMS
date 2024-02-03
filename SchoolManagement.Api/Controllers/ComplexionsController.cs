using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.Features.Complexions.Requests.Commands;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Complexion)]
[ApiController]
[Authorize]
public class ComplexionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ComplexionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-complexions")]
    public async Task<ActionResult<List<ComplexionDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var complexions = await _mediator.Send(new GetComplexionsListRequest { QueryParams = queryParams });
        return Ok(complexions);
    }

    [HttpGet]
    [Route("get-complexionDetail/{id}")]
    public async Task<ActionResult<ComplexionDto>> Get(int id)
    {
        var complexions = await _mediator.Send(new GetComplexionsDetailRequest { Id = id });
        return Ok(complexions);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-complexion")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateComplexionDto complexion)
    {
        var command = new CreateComplexionsCommand { ComplexionDto = complexion };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-complexion/{id}")]
    public async Task<ActionResult> Put([FromBody] ComplexionDto complexion)
    {
        var command = new UpdateComplexionsCommand { ComplexionDto = complexion };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-complexion/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteComplexionsCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedComplexions")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedComplexions()
    {
        var bnaServiceType = await _mediator.Send(new GetSelectedComplexionRequest { });
        return Ok(bnaServiceType);
    }

}

