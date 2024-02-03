using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ExamCenterSelection;
using SchoolManagement.Application.Features.ExamCenterSelections.Requests.Commands;
using SchoolManagement.Application.Features.ExamCenterSelections.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ExamCenterSelection)]
[ApiController]
[Authorize]
public class ExamCenterSelectionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExamCenterSelectionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-ExamCenterSelections")]
    public async Task<ActionResult<List<ExamCenterSelectionDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ExamCenterSelections = await _mediator.Send(new GetExamCenterSelectionListRequest { QueryParams = queryParams });
        return Ok(ExamCenterSelections);
    }


    [HttpGet]
    [Route("get-ExamCenterSelectionDetail/{id}")]
    public async Task<ActionResult<ExamCenterSelectionDto>> Get(int id)
    {
        var ExamCenterSelection = await _mediator.Send(new GetExamCenterSelectionDetailRequest { ExamCenterSelectionId = id });
        return Ok(ExamCenterSelection);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-ExamCenterSelection")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateExamCenterSelectionDto ExamCenterSelection)
    {
        var command = new CreateExamCenterSelectionCommand { ExamCenterSelectionDto = ExamCenterSelection };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-ExamCenterSelection/{id}")]
    public async Task<ActionResult> Put([FromBody] ExamCenterSelectionDto ExamCenterSelection)
    {
        var command = new UpdateExamCenterSelectionCommand { ExamCenterSelectionDto = ExamCenterSelection };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ExamCenterSelection/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteExamCenterSelectionCommand { ExamCenterSelectionId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    //// relational data get   

    //[HttpGet]
    //[Route("get-selectedExamCenterSelections")]
    //public async Task<ActionResult<List<SelectedModel>>> GetSelectedExamCenterSelection()
    //{
    //    var selectedExamCenterSelection = await _mediator.Send(new GetSelectedExamCenterSelectionRequest { });
    //    return Ok(selectedExamCenterSelection);
    //}
}

