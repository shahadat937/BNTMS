using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ColorOfEye;
using SchoolManagement.Application.Features.ColorOfEyes.Requests.Commands;
using SchoolManagement.Application.Features.ColorOfEyes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ColorOfEye)]
[ApiController]
[Authorize]
public class ColorOfEyeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ColorOfEyeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-colorOfEyes")]
    public async Task<ActionResult<List<ColorOfEyeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ColorOfEyes = await _mediator.Send(new GetColorOfEyeListRequest { QueryParams = queryParams });
        return Ok(ColorOfEyes);
    }

    [HttpGet]
    [Route("get-colorOfEyeDetail/{id}")]
    public async Task<ActionResult<ColorOfEyeDto>> Get(int id)
    {
        var ColorOfEye = await _mediator.Send(new GetColorOfEyeDetailRequest { ColorOfEyesId = id });
        return Ok(ColorOfEye);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-colorOfEye")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateColorOfEyeDto ColorOfEye)
    {
        var command = new CreateColorOfEyeCommand { ColorOfEyeDto = ColorOfEye };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-colorOfEye/{id}")]
    public async Task<ActionResult> Put([FromBody] ColorOfEyeDto ColorOfEye)
    {
        var command = new UpdateColorOfEyeCommand { ColorOfEyeDto = ColorOfEye };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-colorOfEye/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteColorOfEyeCommand { ColorOfEyesId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedColorOfEyes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedColorOfEye()
    {
        var colorofeye = await _mediator.Send(new GetSelectedColorOfEyeRequest { });
        return Ok(colorofeye);
    }
}

