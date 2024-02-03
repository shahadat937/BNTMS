using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ReadingMaterial;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Application.Features.ReadingMaterials.Requests.Commands;
using SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ReadingMaterial)]
[ApiController]
[Authorize]
public class ReadingMaterialController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReadingMaterialController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-readingMaterials")]
    public async Task<ActionResult<List<ReadingMaterialDto>>> Get([FromQuery] QueryParams queryParams, int baseSchoolNameId)
    {
        var ReadingMaterials = await _mediator.Send(new GetReadingMaterialListRequest { 
            QueryParams = queryParams,
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(ReadingMaterials);
    }

    [HttpGet]
    [Route("get-readingMaterialDetail/{id}")]
    public async Task<ActionResult<ReadingMaterialDto>> Get(int id)
    {
        var ReadingMaterial = await _mediator.Send(new GetReadingMaterialDetailRequest { ReadingMaterialId = id });
        return Ok(ReadingMaterial);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [RequestFormLimits(MultipartBodyLengthLimit = 2147483648)]
    [Route("save-readingMaterial")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateReadingMaterialDto ReadingMaterial)
    {
        var command = new CreateReadingMaterialCommand { ReadingMaterialDto = ReadingMaterial };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-readingMaterial/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateReadingMaterialDto createReadingMaterial)
    {
        var command = new UpdateReadingMaterialCommand { CreateReadingMaterialDto = createReadingMaterial };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-readingMaterial/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteReadingMaterialCommand { ReadingMaterialId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedReadingMaterialByMaterialTitleIdBaseSchoolIdAndCourseNameId")]
    public async Task<ActionResult<List<ReadingMaterialDto>>> GetReadingMaterialsByMaterialTitleIdBaseSchoolIdAndCourseNameId(int baseSchoolNameId, int courseNameId,int materialTitleId)
    { 
        var readingMaterial = await _mediator.Send(new GetReadingMaterialsByMaterialTitleIdBaseSchoolIdAndCourseNameIdRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            ReadingMaterialTitleId = materialTitleId,
            CourseNameId = courseNameId
        });
        return Ok(readingMaterial); 
    }
}

