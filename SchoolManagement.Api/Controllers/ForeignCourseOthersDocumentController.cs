using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ForeignCourseOthersDocument;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Commands;
using SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ForeignCourseOthersDocument)]
[ApiController]
[Authorize]
public class ForeignCourseOthersDocumentController : ControllerBase
{
    private readonly IMediator _mediator;

    public ForeignCourseOthersDocumentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-foreignCourseOthersDocuments")]
    public async Task<ActionResult<List<ForeignCourseOthersDocumentDto>>> Get([FromQuery] QueryParams queryParams,int courseDurationId,int traineeId)
    {
        var ForeignCourseOthersDocuments = await _mediator.Send(new GetForeignCourseOthersDocumentListRequest
        {
            QueryParams = queryParams,
            TraineeId =traineeId,
            CourseDurationId =courseDurationId
            
        });
        return Ok(ForeignCourseOthersDocuments);
    }

    

    [HttpGet]
    [Route("get-foreignCourseOthersDocumentDetail/{id}")]
    public async Task<ActionResult<ForeignCourseOthersDocumentDto>> Get(int id)
    {
        var ForeignCourseOthersDocument = await _mediator.Send(new GetForeignCourseOthersDocumentDetailRequest { ForeignCourseOthersDocumentId = id });
        return Ok(ForeignCourseOthersDocument);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-foreignCourseOthersDocument")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateForeignCourseOthersDocumentDto ForeignCourseOthersDocument)
    {
        var command = new CreateForeignCourseOthersDocumentCommand { ForeignCourseOthersDocumentDto = ForeignCourseOthersDocument };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-foreignCourseOthersDocument/{id}")]
    public async Task<ActionResult> Put([FromBody] ForeignCourseOthersDocumentDto ForeignCourseOthersDocument)
    {
        var command = new UpdateForeignCourseOthersDocumentCommand { ForeignCourseOthersDocumentDto = ForeignCourseOthersDocument };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-foreignCourseOthersDocument/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteForeignCourseOthersDocumentCommand { ForeignCourseOthersDocumentId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedForeignCourseOthersDocuments")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedForeignCourseOthersDocument()
    {
        var ForeignCourseOthersDocument = await _mediator.Send(new GetSelectedForeignCourseOthersDocumentRequest { });
        return Ok(ForeignCourseOthersDocument);
    }
}

