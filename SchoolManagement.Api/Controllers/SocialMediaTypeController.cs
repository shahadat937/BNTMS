using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SocialMediaTypes;
using SchoolManagement.Application.Features.SocialMediaTypes.Requests.Commands;
using SchoolManagement.Application.Features.SocialMediaTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SocialMediaType)]
[ApiController]
[Authorize]
public class SocialMediaTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public SocialMediaTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-socialMediaTypes")]
    public async Task<ActionResult<List<SocialMediaTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var SocialMediaTypees = await _mediator.Send(new GetSocialMediaTypeListRequest { QueryParams = queryParams });
        return Ok(SocialMediaTypees);
    }

    [HttpGet]
    [Route("get-socialMediaTypeDetail/{id}")]
    public async Task<ActionResult<SocialMediaTypeDto>> Get(int id)
    {
        var SocialMediaType = await _mediator.Send(new GetSocialMediaTypeDetailRequest { Id = id });
        return Ok(SocialMediaType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-socialMediaType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSocialMediaTypeDto SocialMediaType)
    {
        var command = new CreateSocialMediaTypeCommand { SocialMediaTypeDto = SocialMediaType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-socialMediaType/{id}")]
    public async Task<ActionResult> Put([FromBody] SocialMediaTypeDto SocialMediaType)
    {
        var command = new UpdateSocialMediaTypeCommand { SocialMediaTypeDto = SocialMediaType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-socialMediaType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSocialMediaTypeCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedSocialMediaType")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSocialMediaType()
    {
        var socialMedia = await _mediator.Send(new GetSelectedSocialMediaTypeRequest { });
        return Ok(socialMedia);
    }
}

