using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.HairColor;
using SchoolManagement.Application.Features.HairColors.Requests.Commands;
using SchoolManagement.Application.Features.HairColors.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.HairColor)]
[ApiController]
[Authorize]
public class HairColorController : ControllerBase
{
    private readonly IMediator _mediator;

    public HairColorController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-hairColors")]
    public async Task<ActionResult<List<HairColorDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var HairColors = await _mediator.Send(new GetHairColorListRequest { QueryParams = queryParams });
        return Ok(HairColors);
    }


    [HttpGet]
    [Route("get-hairColorDetail/{id}")]
    public async Task<ActionResult<HairColorDto>> Get(int id)
    {
        var HairColor = await _mediator.Send(new GetHairColorDetailRequest { HairColorId = id });
        return Ok(HairColor);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-hairColor")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateHairColorDto HairColor)
    {
        var command = new CreateHairColorCommand { HairColorDto = HairColor };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-hairColor/{id}")]
    public async Task<ActionResult> Put([FromBody] HairColorDto HairColor)
    {
        var command = new UpdateHairColorCommand { HairColorDto = HairColor };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-hairColor/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteHairColorCommand { HairColorId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedHairColor")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedHairColor()
    {
        var HairColor = await _mediator.Send(new GetSelectedHairColorRequest { });
        return Ok(HairColor);
    }
}

