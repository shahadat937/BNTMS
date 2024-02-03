using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseInstructors;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Commands;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CourseInstructors)]
[ApiController]
[Authorize]
public class CourseInstructorController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseInstructorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-CourseInstructors")]
    public async Task<ActionResult<List<CourseInstructorDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CourseInstructors = await _mediator.Send(new GetCourseInstructorListRequest { QueryParams = queryParams });
        return Ok(CourseInstructors);
    }

    [HttpGet]
    [Route("get-CourseInstructorDetail/{id}")]
    public async Task<ActionResult<CourseInstructorDto>> Get(int id)
    {
        var CourseInstructor = await _mediator.Send(new GetCourseInstructorDetailRequest { CourseInstructorId = id });
        return Ok(CourseInstructor);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-CourseInstructor")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] ModifiedCreateCourseInstructorDto CourseInstructor)
    {
        var command = new CreateCourseInstructorCommand { CourseInstructorDto = CourseInstructor };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-CourseInstructor/{id}")]
    public async Task<ActionResult> Put([FromBody] CourseInstructorDto CourseInstructor)
    {
        var command = new UpdateCourseInstructorCommand { CourseInstructorDto = CourseInstructor };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-CourseInstructor/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCourseInstructorCommand { CourseInstructorId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-CourseInstructorByParameters")]

    public async Task<ActionResult> GetCourseInstructorByParameters(int baseSchoolNameId, int bnaSubjectNameId, int courseModuleId, int courseNameId, int courseDurationId, int courseSectionId)
    {
        var CourseInstructorByParameters = await _mediator.Send(new GetCourseInstructorByParametersRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            BnaSubjectNameId = bnaSubjectNameId,
            CourseModuleId = courseModuleId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            CourseSectionId = courseSectionId
        });
        return Ok(CourseInstructorByParameters);
    }


    [HttpGet]
    [Route("get-CourseInstructorByCourseDurationIdandSubjectNameId")]
    public async Task<ActionResult> GetCourseInstructorByCourseDurationAndSubjectNameId(int bnaSubjectNameId, int courseNameId, int courseDurationId)
    {
        var CourseInstructorByParameters = await _mediator.Send(new GetCourseInstructorByCourseDurationAndSubjectNameIdRequest
        {
            BnaSubjectNameId = bnaSubjectNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId
        });
        return Ok(CourseInstructorByParameters);
    }


    [HttpGet]
    [Route("get-instructorNameByParams")]

    public async Task<ActionResult> GetIinstructorNameByParams(int baseSchoolNameId, int courseNameId, int courseDurationId, int bnaSubjectNameId)
    {
        var CourseInstructorByParameters = await _mediator.Send(new GetInstructorNameByParamsSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,            
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(CourseInstructorByParameters);
    }


    [HttpGet]
    [Route("get-selectedInstructorNameByParams")]

    public async Task<ActionResult> GetSelectedIinstructorNameByParams(int baseSchoolNameId, int courseNameId, int courseDurationId, int courseSectionId, int bnaSubjectNameId)
    {
        var CourseInstructorByParameters = await _mediator.Send(new GetSelectedInstructorNameByParamsSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            CourseSectionId = courseSectionId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(CourseInstructorByParameters);
    }

    [HttpGet]
    [Route("get-instructorByCourseAndSchool")]

    public async Task<ActionResult> GetInstructorByCourseAndSchool(int baseSchoolNameId, int courseDurationId, int courseNameId)
    {
        var InstructorByCourseAndSchool = await _mediator.Send(new GetInstructorByCourseAndSchoolRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseDurationId = courseDurationId,
            CourseNameId = courseNameId
        });
        return Ok(InstructorByCourseAndSchool);
    }
     
    [HttpGet]
    [Route("get-instructorByBaseSchoolAndCourseNameSpRequest")]
    public async Task<ActionResult> GetInstructorByBaseSchoolAndCourseNameSpRequest(int baseSchoolNameId,int courseNameId, int courseDurationId)
    {
        var instructors = await _mediator.Send(new GetInstructorByBaseSchoolAndCourseNameSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId
        });
        return Ok(instructors);
    }

    [HttpGet]
    [Route("get-instructorListByCourse")]

    public async Task<ActionResult> GetInstructorListByCourse(int baseSchoolNameId, int courseNameId, int courseDurationId)
    {
        var InstructorInfoByCourse = await _mediator.Send(new GetInstructorListByCourseSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId
        });
        return Ok(InstructorInfoByCourse);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("stop-CourseInstructor/{id}")] 
    public async Task<ActionResult> StopCourseInstructor(int id)
    {
        var command = new StopCourseInstructorCommand { CourseInstructorId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType] 
    [Route("running-CourseInstructor/{id}")]
    public async Task<ActionResult> RunningCourseInstructor(int id)
    {
        var command = new RunningCourseInstructorCommand { CourseInstructorId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedCourseInstructorIdByParameterRequest")]
    public async Task<ActionResult> GetSelectedCourseInstructorIdByParameterRequest(int baseSchoolNameId, int courseDurationId,int bnaSubjectNameId,int traineeId)
    {
        var CourseInstructorId = await _mediator.Send(new GetSelectedCourseInstructorIdByParametersRequest
        {
            BaseSchoolNameId=baseSchoolNameId,
            CourseDurationId =courseDurationId,
            BnaSubjectNameId =bnaSubjectNameId,
            TraineeId =traineeId
        });
        return Ok(CourseInstructorId);
    }


    [HttpGet]
    [Route("get-todayClassScheduleByCourseInstructorId")]
    public async Task<ActionResult> GetTodayClassScheduleByCourseInstructorId(int traineeId)
    {
        var CourseInstructorId = await _mediator.Send(new GetTodayClassScheduleByCourseInstructorIdSpRequest
        {
            TraineeId =traineeId
        });
        return Ok(CourseInstructorId);
    }

    [HttpGet]
    [Route("get-CourseInstructorListForBnaByParameters")]
    public async Task<ActionResult> GetCourseInstructorListForBnaByParameters(int baseSchoolNameId, int bnaSubjectNameId, int bnaSemesterId, int courseNameId, int courseDurationId, int courseSectionId)
    {
        var CourseInstructorByParameters = await _mediator.Send(new GetCourseInstructorListForBnaByParametersRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            BnaSubjectNameId = bnaSubjectNameId,
            BnaSemesterId = bnaSemesterId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            CourseSectionId = courseSectionId
        });
        return Ok(CourseInstructorByParameters);
    }
}

