using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseSection;
using SchoolManagement.Application.Features.Castes.Requests.Queries;
using SchoolManagement.Application.Features.CourseSections.Requests.Commands;
using SchoolManagement.Application.Features.CourseSections.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CourseSection)]
[ApiController]
[Authorize]
public class CourseSectionController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseSectionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-courseSections")]
    public async Task<ActionResult<List<CourseSectionDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CourseSections = await _mediator.Send(new GetCourseSectionListRequest { QueryParams = queryParams });
        return Ok(CourseSections);
    }

    

    [HttpGet]
    [Route("get-courseSectionDetail/{id}")]
    public async Task<ActionResult<CourseSectionDto>> Get(int id)
    {
        var CourseSection = await _mediator.Send(new GetCourseSectionDetailRequest { CourseSectionId = id });
       var qq = CourseSection;
        return Ok(CourseSection);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-courseSection")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseSectionDto CourseSection)
    {
        var command = new CreateCourseSectionCommand { CourseSectionDto = CourseSection };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-courseSection/{id}")]
    public async Task<ActionResult> Put([FromBody] CourseSectionDto CourseSection)
    {
        var command = new UpdateCourseSectionCommand { CourseSectionDto = CourseSection };
 
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-courseSection/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCourseSectionCommand { CourseSectionId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedCourseSections")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseSection()
    {
        var CourseSectionValue = await _mediator.Send(new GetSelectedCourseSectionRequest { });
        return Ok(CourseSectionValue);
    }

    [HttpGet]
    [Route("get-selectedCourseSectionsByBaseSchoolNameIdAndCourseNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseSectionByBaseSchoolNameIdAndCourseNameId(int baseSchoolNameId,int courseNameId)
    {
        var CourseSectionValue = await _mediator.Send(new GetSelectedCourseSectionByBaseNameIdAndCourseNameIdRequest
        { 
         BaseSchoolNameId = baseSchoolNameId,
         CourseNameId = courseNameId,
        }); 
        return Ok(CourseSectionValue);
    }



    [HttpGet]
    [Route("get-selectedCourseSectionsByCourseNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseSectionByBaseSchoolNameIdAndCourseNameId(  int courseNameId)
    {
        var CourseSectionValue = await _mediator.Send(new GetSelectedCourseSectionByCourseNameIdRequest
        { 
            CourseNameId = courseNameId,
        });
        return Ok(CourseSectionValue);
    }


    [HttpGet]
    [Route("get-selectedCourseSectionByBaseSchoolNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseSectionByBaseSchoolNameId(int baseSchoolNameId)
    {
        var CourseSectionByBaseSchoolName = await _mediator.Send(new GetSelectedCourseSectionByBaseSchoolNameIdRequest { BaseSchoolNameId = baseSchoolNameId });
        return Ok(CourseSectionByBaseSchoolName);
    }

    [HttpGet]
    [Route("get-courseSectionListByBaseSchoolNameIdAndCourseNameId")] 
    public async Task<ActionResult<List<CourseSectionDto>>> GetCourseSectionListByBaseSchoolNameIdandCourseNameId(int baseSchoolNameId,int courseNameId)
    {
        var CourseSections = await _mediator.Send(new GetCourseSectionListByBaseNameIdAndCourseNameIdRequest
        { 
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId =courseNameId
        });
        return Ok(CourseSections); 
    }
    [HttpGet]
    [Route("get-selectedCourseSectionForBna")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseSectionForBna()
    {
        var CourseSectionByBaseSchoolName = await _mediator.Send(new GetSelectedCourseSectionForBnaRequest { });
        return Ok(CourseSectionByBaseSchoolName);
    }



}

