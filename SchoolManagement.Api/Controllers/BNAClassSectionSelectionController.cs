using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaClassSectionSelection;
using SchoolManagement.Application.Features.BnaClassSections.Requests.Commands;
using SchoolManagement.Application.Features.BnaClassSections.Requests.Queries;
using SchoolManagement.Application.Features.BnaClassSectionSelections.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaClassSectionSelection)]
[ApiController]
[Authorize]
public class BnaClassSectionSelectionController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaClassSectionSelectionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaClassSectionSelections")]
    public async Task<ActionResult<List<BnaClassSectionSelectionDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaClassSectionSelectione = await _mediator.Send(new GetBnaClassSectionListRequest { QueryParams = queryParams });
        return Ok(BnaClassSectionSelectione);
    }

    [HttpGet]
    [Route("get-bnaClassSectionSelectionDetail/{id}")]
    public async Task<ActionResult<BnaClassSectionSelectionDto>> Get(int id)
    {
        var BnaClassSectionSelection = await _mediator.Send(new GetBnaClassSectionDetailRequest { Id = id });
        return Ok(BnaClassSectionSelection);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaClassSectionSelection")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaClassSectionSelectionDto BnaClassSectionSelection)
    {
        var command = new CreateBnaClassSectionCommand { BnaClassSectionDto = BnaClassSectionSelection };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaClassSectionSelection/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaClassSectionSelectionDto BnaClassSectionSelection)
    {
        var command = new UpdateBnaClassSectionCommand { BnaClassSectionDto = BnaClassSectionSelection };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaClassSectionSelection/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaClassSectionCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get    

    [HttpGet]
    [Route("get-selectedBnaClassSectionSelections")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBnaclassSectionSelection()
    {
        var selectedBnaclassSection = await _mediator.Send(new GetSelectedBnaClassSectionSelectionRequest { });
        return Ok(selectedBnaclassSection);
    }




}

