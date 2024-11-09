using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.OnlineLibrary;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Application.Features.OnlineLibrary.Requests.Commands;
using SchoolManagement.Application.Features.OnlineLibrary.Requests.Queries;
using System.Runtime.CompilerServices;
//using SchoolManagement.Application.Features.OnlineLibrary.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.OnlineLibrary)]
[ApiController]
[Authorize]
public class OnlineLibraryController : ControllerBase
{
    private readonly IMediator _mediator;

    public OnlineLibraryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [RequestFormLimits(MultipartBodyLengthLimit = 2147483648)]
    [Route("save-OnlineLibrary")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateOnlineLibraryDto OnlineLibrary)
    {
        var command = new CreateOnlineLibraryRequest { OnlineLibraryDto = OnlineLibrary };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpGet]
    [ProducesResponseType(200)]
    [Route("get-OnlineLibrarysMeterials")]
    public async Task<ActionResult<List<OnlineLibraryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var OnlineLibrarys = await _mediator.Send(new GetAllOnlineLibraryMaterielRequest
        {
            QueryParams = queryParams,
         
        });
        return Ok(OnlineLibrarys);
    }

    [HttpGet]
    [ProducesResponseType(200)]
    [Route("get-online-librarys-meterials-by-user/{userId}")]
    public async Task<ActionResult<List<OnlineLibraryDto>>> GetOnlineLibraryMaterialByUser([FromQuery] QueryParams queryParams, string userId)
    {
        var OnlineLibrarys = await _mediator.Send(new GetOnlineLibraryMaterialByUserRequest
        {
            UserId = userId,
            QueryParams = queryParams,

        });
        return Ok(OnlineLibrarys);
    }

    [HttpDelete]
    [Route("delete-online-library-materials/{id}")]

    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteOnlineLibraryMaterialRequest { OnlineLibraryId = id };
       await _mediator.Send(command);
        return NoContent();
    }


    //[HttpPut]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesDefaultResponseType]
    //[Route("update-OnlineLibrary/{id}")]
    //public async Task<ActionResult> Put([FromForm] CreateOnlineLibraryDto createOnlineLibrary)
    //{
    //    var command = new UpdateOnlineLibraryCommand { CreateOnlineLibraryDto = createOnlineLibrary };
    //    await _mediator.Send(command);
    //    return NoContent();
    //}

    //[HttpDelete]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesDefaultResponseType]
    //[Route("delete-OnlineLibrary/{id}")]
    //public async Task<ActionResult> Delete(int id)
    //{
    //    var command = new DeleteOnlineLibraryCommand { OnlineLibraryId = id };
    //    await _mediator.Send(command);
    //    return NoContent();
    //}

    //[HttpGet]
    //[Route("get-selectedOnlineLibraryByMaterialTitleIdBaseSchoolIdAndCourseNameId")]
    //public async Task<ActionResult<List<OnlineLibraryDto>>> GetOnlineLibrarysByMaterialTitleIdBaseSchoolIdAndCourseNameId(int baseSchoolNameId, int courseNameId,int materialTitleId)
    //{ 
    //    var OnlineLibrary = await _mediator.Send(new GetOnlineLibrarysByMaterialTitleIdBaseSchoolIdAndCourseNameIdRequest
    //    {
    //        BaseSchoolNameId = baseSchoolNameId,
    //        OnlineLibraryTitleId = materialTitleId,
    //        CourseNameId = courseNameId
    //    });
    //    return Ok(OnlineLibrary); 
    //}
}

