using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ForeignCourseOtherDoc;
using SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Commands;
using SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ForeignCourseOtherDoc)]
[ApiController]
[Authorize]
public class ForeignCourseOtherDocController : ControllerBase
{
    private readonly IMediator _mediator;

    public ForeignCourseOtherDocController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-ForeignCourseOtherDocs")]
    public async Task<ActionResult<List<ForeignCourseOtherDocDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ForeignCourseOtherDocs = await _mediator.Send(new GetForeignCourseOtherDocListRequest { QueryParams = queryParams });
        return Ok(ForeignCourseOtherDocs);
    }

    [HttpGet]
    [Route("get-ForeignCourseOtherDocDetail/{id}")]
    public async Task<ActionResult<ForeignCourseOtherDocDto>> Get(int id)
    {
        var ForeignCourseOtherDoc = await _mediator.Send(new GetForeignCourseOtherDocDetailRequest { ForeignCourseOtherDocId = id });
        return Ok(ForeignCourseOtherDoc);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-ForeignCourseOtherDoc")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateForeignCourseOtherDocDto ForeignCourseOtherDoc)
    {
        var command = new CreateForeignCourseOtherDocCommand { ForeignCourseOtherDocDto = ForeignCourseOtherDoc };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-foreignCourseOtherDocList")]

    public async Task<ActionResult<BaseCommandResponse>> SaveForeignCourseOtherDocList([FromBody] ForeignCourseOtherDocListDto bnaExamMark)
    {
        var command = new CreateForeignCourseOtherDocListCommand { ForeignCourseOtherDocListDto = bnaExamMark };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType] 
    [Route("update-ForeignCourseOtherDoc/{id}")] 
    public async Task<ActionResult> Put([FromBody] ForeignCourseOtherDocListDto ForeignCourseOtherDoc)
    {
        var command = new UpdateForeignCourseOtherDocCommand { ForeignCourseOtherDocListDto = ForeignCourseOtherDoc };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ForeignCourseOtherDoc/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteForeignCourseOtherDocCommand { ForeignCourseOtherDocId = id };
        await _mediator.Send(command);
        return NoContent();
    }
    // relational data get 
    [HttpGet]
    [Route("get-selectedForeignCourseOtherDocs")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedForeignCourseOtherDoc()
    {
        var selectedForeignCourseOtherDoc = await _mediator.Send(new GetSelectedForeignCourseOtherDocRequest { });
        return Ok(selectedForeignCourseOtherDoc);
    }



    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("change-releventDocStatus")]
    public async Task<ActionResult> ChangeReceivedStatus(int foreignCourseOtherDocId, string fieldName, bool status)
    {
        var command = new ChangeDocStatusCommand
        {
            ForeignCourseOtherDocId = foreignCourseOtherDocId,
            FieldName = fieldName,
            Status = status
        };
        await _mediator.Send(command);
        return NoContent();
    }
}

