using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Languages;
using SchoolManagement.Application.Features.Languages.Requests.Commands;
using SchoolManagement.Application.Features.Languages.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Language)]
[ApiController]
[Authorize]
public class LanguageController : ControllerBase
{
    private readonly IMediator _mediator;

    public LanguageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-languages")]
    public async Task<ActionResult<List<LanguageDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Languagees = await _mediator.Send(new GetLanguageListRequest { QueryParams = queryParams });
        return Ok(Languagees);
    }

    [HttpGet]
    [Route("get-languageDetail/{id}")]
    public async Task<ActionResult<LanguageDto>> Get(int id)
    {
        var Language = await _mediator.Send(new GetLanguageDetailRequest { Id = id });
        return Ok(Language);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-language")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateLanguageDto Language)
    {
        var command = new CreateLanguageCommand { LanguageDto = Language };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-language/{id}")]
    public async Task<ActionResult> Put([FromBody] LanguageDto Language)
    {
        var command = new UpdateLanguageCommand { LanguageDto = Language };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-language/{id}")]

    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteLanguageCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }



    [HttpGet]
    [Route("get-selectedLanguage")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedLanguage()
    {
        var language = await _mediator.Send(new GetSelectedLanguageRequest { });
        return Ok(language);
    }

}

