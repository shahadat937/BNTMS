using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Gender;
using SchoolManagement.Application.Features.Genders.Requests.Commands;
using SchoolManagement.Application.Features.Genders.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Gender)]
[ApiController]
[Authorize]
public class GenderController : ControllerBase
{
    private readonly IMediator _mediator;

    public GenderController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-genders")]
    public async Task<ActionResult<List<GenderDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Genders = await _mediator.Send(new GetGenderListRequest { QueryParams = queryParams });
        return Ok(Genders);
    }

    [HttpGet]
    [Route("get-genderDetail/{id}")]
    public async Task<ActionResult<GenderDto>> Get(int id)
    {
        var Genders = await _mediator.Send(new GetGenderDetailRequest { GenderId = id });
        return Ok(Genders);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-gender")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateGenderDto Gender)
    {
        var command = new CreateGenderCommand { GenderDto = Gender };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-gender/{id}")]
    public async Task<ActionResult> Put([FromBody] GenderDto Gender)
    {
        var command = new UpdateGenderCommand { GenderDto = Gender };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-gender/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteGenderCommand { GenderId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedGender")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedGender()
    {
        var codeValueByType = await _mediator.Send(new GetSelectedGenderRequest { });
        return Ok(codeValueByType);
    }
}

