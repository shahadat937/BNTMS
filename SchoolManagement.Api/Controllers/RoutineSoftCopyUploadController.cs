using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.RoutineSoftCopyUpload;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Application.Features.RoutineSoftCopyUploads.Requests.Commands;
using SchoolManagement.Application.Features.RoutineSoftCopyUploads.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.RoutineSoftCopyUpload)]
[ApiController]
[Authorize]
public class RoutineSoftCopyUploadController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoutineSoftCopyUploadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-RoutineSoftCopyUploads")]
    public async Task<ActionResult<List<RoutineSoftCopyUploadDto>>> Get([FromQuery] QueryParams queryParams, int baseSchoolNameId, int courseDurationId)
    {
        var RoutineSoftCopyUploads = await _mediator.Send(new GetRoutineSoftCopyUploadListRequest { 
            QueryParams = queryParams,
            BaseSchoolNameId = baseSchoolNameId,
            CourseDurationId = courseDurationId
        });
        return Ok(RoutineSoftCopyUploads);
    }

    [HttpGet]
    [Route("get-RoutineSoftCopyUploadDetail/{id}")]
    public async Task<ActionResult<RoutineSoftCopyUploadDto>> Get(int id)
    {
        var RoutineSoftCopyUpload = await _mediator.Send(new GetRoutineSoftCopyUploadDetailRequest { RoutineSoftCopyUploadId = id });
        return Ok(RoutineSoftCopyUpload);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [RequestFormLimits(MultipartBodyLengthLimit = 2147483648)]
    [Route("save-RoutineSoftCopyUpload")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateRoutineSoftCopyUploadDto RoutineSoftCopyUpload)
    {
        var command = new CreateRoutineSoftCopyUploadCommand { RoutineSoftCopyUploadDto = RoutineSoftCopyUpload };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-RoutineSoftCopyUpload/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateRoutineSoftCopyUploadDto createRoutineSoftCopyUpload)
    {
        var command = new UpdateRoutineSoftCopyUploadCommand { CreateRoutineSoftCopyUploadDto = createRoutineSoftCopyUpload };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-RoutineSoftCopyUpload/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteRoutineSoftCopyUploadCommand { RoutineSoftCopyUploadId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    //[HttpGet]
    //[Route("get-selectedRoutineSoftCopyUploadByMaterialTitleIdBaseSchoolIdAndCourseNameId")]
    //public async Task<ActionResult<List<RoutineSoftCopyUploadDto>>> GetRoutineSoftCopyUploadsByMaterialTitleIdBaseSchoolIdAndCourseNameId(int baseSchoolNameId, int courseNameId,int materialTitleId)
    //{ 
    //    var RoutineSoftCopyUpload = await _mediator.Send(new GetRoutineSoftCopyUploadsByMaterialTitleIdBaseSchoolIdAndCourseNameIdRequest
    //    {
    //        BaseSchoolNameId = baseSchoolNameId,
    //        RoutineSoftCopyUploadTitleId = materialTitleId,
    //        CourseNameId = courseNameId
    //    });
    //    return Ok(RoutineSoftCopyUpload); 
    //}
}

