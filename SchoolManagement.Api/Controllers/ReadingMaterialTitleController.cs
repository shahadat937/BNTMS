using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ReadingMaterialTitle;
using SchoolManagement.Application.DTOs.ReadingMaterialTitles;
using SchoolManagement.Application.Features.ReadingMaterialTitles.Requests.Commands;
using SchoolManagement.Application.Features.ReadingMaterialTitles.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ReadingMaterialTitle)]
[ApiController]
[Authorize]
public class ReadingMaterialTitleController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReadingMaterialTitleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-ReadingMaterialTitles")]
    public async Task<ActionResult<List<ReadingMaterialTitleDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ReadingMaterialTitles = await _mediator.Send(new GetReadingMaterialTitleListRequest { QueryParams = queryParams });
        return Ok(ReadingMaterialTitles);
    }

    

    [HttpGet]
    [Route("get-ReadingMaterialTitleDetail/{id}")]
    public async Task<ActionResult<ReadingMaterialTitleDto>> Get(int id)
    {
        var ReadingMaterialTitles = await _mediator.Send(new GetReadingMaterialTitleDetailRequest { ReadingMaterialTitleId = id });
        return Ok(ReadingMaterialTitles);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-ReadingMaterialTitle")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateReadingMaterialTitleDto ReadingMaterialTitle)
    {
        var command = new CreateReadingMaterialTitleCommand { ReadingMaterialTitleDto = ReadingMaterialTitle };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-ReadingMaterialTitle/{id}")]
    public async Task<ActionResult> Put([FromBody] ReadingMaterialTitleDto ReadingMaterialTitle)
    {
        var command = new UpdateReadingMaterialTitleCommand { ReadingMaterialTitleDto = ReadingMaterialTitle };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ReadingMaterialTitle/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteReadingMaterialTitleCommand { ReadingMaterialTitleId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data

    [HttpGet]
    [Route("get-selectedReadingMaterialTitles")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedReadingMaterialTitle()
    {
        var selectedReadingMaterialTitle = await _mediator.Send(new GetSelectedReadingMaterialTitleRequest { });
        return Ok(selectedReadingMaterialTitle);
    }
}

