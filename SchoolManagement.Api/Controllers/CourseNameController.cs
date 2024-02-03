using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseName;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Application.Features.CourseNames.Requests.Commands;
using SchoolManagement.Application.Features.CourseNames.Requests.Queries;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CourseName)]
[ApiController]
[Authorize]
public class CourseNameController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseNameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-courseNames")]
    public async Task<ActionResult<List<CourseNameDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CourseNames = await _mediator.Send(new GetCourseNameListRequest { QueryParams = queryParams });
        return Ok(CourseNames);
    }

    [HttpGet]
    [Route("get-courseNameDetail/{id}")]
    public async Task<ActionResult<CourseNameDto>> Get(int id)
    {
        var CourseNames = await _mediator.Send(new GetCourseNameDetailRequest { CourseNameId = id });
        return Ok(CourseNames);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-courseName")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateCourseNameDto CourseName)
    {
        var command = new CreateCourseNameCommand { CourseNameDto = CourseName };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-courseName/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateCourseNameDto CourseName)
    {
        var command = new UpdateCourseNameCommand { CreateCourseNameDto = CourseName };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-courseName/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCourseNameCommand { CourseNameId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedCourseNames")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseName()
    {
        var selectedCourseName = await _mediator.Send(new GetSelectedCourseNameRequest { });
        return Ok(selectedCourseName);
    }

    [HttpGet]
    [Route("get-selectedCourseNamesForMist")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseNameForMist()
    {
        var selectedCourseName = await _mediator.Send(new GetSelectedCourseNameForMistRequest { });
        return Ok(selectedCourseName);
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedCourseByBaseNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseNameByBaseSchoolName(int baseSchoolNameId)
    {
        var selectedCourseName = await _mediator.Send(new GetCourseNameByBaseSchoolNameIdRequest
        {
          BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(selectedCourseName); 
    }


    [HttpGet]
    [Route("get-autocompleteCourseByName")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompleteCourseByName(string courseName)
    {
        var course = await _mediator.Send(new GetAutoCompleteCourseNameRequest
        {
            CourseName = courseName,
        });
        return Ok(course);
    }

    [HttpGet]
    [Route("get-autocompleteCourseByNameAndType")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompleteCourseByNameAndType(int courseTypeId,string courseName)
    {
        var course = await _mediator.Send(new GetAutoCompleteCourseNameByTypeRequest
        {
            CourseTypeId = courseTypeId,
            CourseName = courseName
        });
        return Ok(course);
    }

    //[HttpGet]
    //[Route("get-selectedCourseByType")]
    //public async Task<ActionResult<List<SelectedModel>>> GetselectedCourseByType(int courseTypeId)
    //{
    //    var course = await _mediator.Send(new GetCourseNameByCourseTypeRequest
    //    {
    //        CourseTypeId = courseTypeId,
    //    });
    //    return Ok(course);
    //}


    [HttpGet]
    [Route("get-selectedCourseByType")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseNameByType(int courseTypeId)
    {
        var selectedCourseName = await _mediator.Send(new GetSelectedCourseNameByTypeRequest
        {
            CourseTypeId = courseTypeId
        });
        return Ok(selectedCourseName);
    }
    [HttpGet]
    [Route("get-selectedCourseByCourseTypeId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseNameByCourseTypeId()
    {
        var selectedCourseName = await _mediator.Send(new GetSelectedCourseNameByCourseTypeIdRequest
        {
            //CourseTypeId = courseTypeId
        });
        return Ok(selectedCourseName);
    }


    [HttpGet]
    [Route("get-subjectTotalByCourseId")]
    public async Task<ActionResult> GetSubjectTotalByCourseId(int baseSchoolNameId,int courseNameId)
    {
        var CourseTotal = await _mediator.Send(new GetSubjectTotalByCourseIdFromSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(CourseTotal);
    }


    [HttpGet]
    [Route("get-courseNamesBySchool")]
    public async Task<ActionResult> GetCourseNamesBySchool(int baseSchoolNameId)
    {
        var CourseTotal = await _mediator.Send(new GetCourseNameBySchoolFromSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(CourseTotal);
    }


    [HttpGet]
    [Route("get-courseNamesByBase")]
    public async Task<ActionResult> GetCourseNamesByBase(int baseNameId)
    {
        var CourseTotal = await _mediator.Send(new GetCourseNameByBaseFromSpRequest
        {
            BaseNameId = baseNameId
        });
        return Ok(CourseTotal);
    }
}

