using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.SocialMedias;
using SchoolManagement.Application.Features.SocialMedias.Requests.Commands;
using SchoolManagement.Application.Features.SocialMedias.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SocialMedia)]
[ApiController]
[Authorize]
public class SocialMediaController : ControllerBase
{
    private readonly IMediator _mediator;

    public SocialMediaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-socialMedias")]
    public async Task<ActionResult<List<SocialMediaDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var SocialMediaes = await _mediator.Send(new GetSocialMediaListRequest { QueryParams = queryParams });
        return Ok(SocialMediaes);
    }

    [HttpGet]
    [Route("get-socialMediaDetail/{id}")]
    public async Task<ActionResult<SocialMediaDto>> Get(int id)
    {
        var SocialMedia = await _mediator.Send(new GetSocialMediaDetailRequest { Id = id });
        return Ok(SocialMedia);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-socialMedia")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSocialMediaDto SocialMedia)
    {
        var command = new CreateSocialMediaCommand { SocialMediaDto = SocialMedia };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-socialMedia/{id}")]
    public async Task<ActionResult> Put([FromBody] SocialMediaDto SocialMedia)
    {
        var command = new UpdateSocialMediaCommand { SocialMediaDto = SocialMedia };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-socialMedia/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSocialMediaCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<SocialMediaDto>>> getdatabytraineeid(int Traineeid)
    {
        var socialMedia = await _mediator.Send(new GetSocialMediaListByTraineeRequest { Traineeid = Traineeid });
        return Ok(socialMedia);
    }
}

