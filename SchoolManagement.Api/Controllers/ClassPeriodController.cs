using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ClassPeriod;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Commands;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;


[Route(SMSRoutePrefix.ClassPeriod)]
[ApiController]
[Authorize]
public class ClassPeriodController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClassPeriodController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-classPeriods")]
    public async Task<ActionResult<List<ClassPeriodDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ClassPeriods = await _mediator.Send(new GetClassPeriodListRequest { QueryParams = queryParams });
        return Ok(ClassPeriods);
    }



    [HttpGet]
    [Route("get-classPeriodDetail/{id}")]
    public async Task<ActionResult<ClassPeriodDto>> Get(int id)
    {
        var ClassPeriod = await _mediator.Send(new GetClassPeriodDetailRequest { ClassPeriodId = id });
        return Ok(ClassPeriod);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-classPeriod")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateClassPeriodDto ClassPeriod)
    {
        var command = new CreateClassPeriodCommand { ClassPeriodDto = ClassPeriod };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-classPeriod/{id}")]
    public async Task<ActionResult> Put([FromBody] ClassPeriodDto ClassPeriod)
    {
        var command = new UpdateClassPeriodCommand { ClassPeriodDto = ClassPeriod };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-classPeriod/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteClassPeriodCommand { ClassPeriodId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data

    [HttpGet]
    [Route("get-selectedClassPeriod")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedClassPeriod()
    {
        var ClassPeriodName = await _mediator.Send(new GetSelectedClassPeriodRequest { });
        return Ok(ClassPeriodName);
    }


    [HttpGet]
    [Route("get-selectedClassPeriodByParameterRequest")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedClassPeriod(int baseSchoolNameId, int courseNameId,int courseDurationId,DateTime date)
    {
        var ClassPeriodName = await _mediator.Send(new GetSelectedClassPeriodByParametersFromClassRoutineRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId =courseDurationId,
            Date = date
        }); 
        return Ok(ClassPeriodName);
    }

    [HttpGet]
    [Route("get-selectedClassPeriodByParameterRequestForAttendances")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedClassPeriodByParameterRequestForAttendances(int baseSchoolNameId, int courseNameId,int courseDurationId, DateTime date)
    {
        var ClassPeriodName = await _mediator.Send(new GetSelectedClassPeriodByParametersFromClassRoutineForAttendancesRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            Date = date
        });
        return Ok(ClassPeriodName);
    }

    [HttpGet]
    [Route("get-selectedClassPeriodBySchoolAndCourse")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedClassPeriodbyschoolandcourse(int baseSchoolNameId, int courseNameId)
    {
        var ClassPeriodName = await _mediator.Send(new GetSelectedClassPeriodBySchoolAndCourseRequest {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
        });
        return Ok(ClassPeriodName);
    }

    [HttpGet]
    [Route("get-selectedPeriodBySchoolAndCourse")]
    public async Task<ActionResult<List<ClassPeriodDto>>> GetSelectedPeriodBySchoolAndCourseRequest(int baseSchoolNameId, int courseNameId)
    {
        var bnaSubjectNames = await _mediator.Send(new GetSelectedPeriodBySchoolAndCourseRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(bnaSubjectNames); 
    }
     
    [HttpGet]
    [Route("get-selectedClassPeriodForAttendanceInstructorSpRequest")]
    public async Task<ActionResult> GetSelectedClassPeriodForAttendanceInstructorSpRequest(int traineeId)
    {
        var selectedClassPeriod = await _mediator.Send(new GetSelectedClassPeriodForAttendanceInstructorSpRequest
        {
            CurrentDate = DateTime.Now,
            TraineeId = traineeId,
        });
        return Ok(selectedClassPeriod);
    }
}

