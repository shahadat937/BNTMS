using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Commands;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ClassRoutine)]
[ApiController]
[Authorize]
public class ClassRoutineController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClassRoutineController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-classRoutines")]
    public async Task<ActionResult<List<ClassRoutineDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ClassRoutines = await _mediator.Send(new GetClassRoutineListRequest { QueryParams = queryParams });
        return Ok(ClassRoutines);
    }



    [HttpGet]
    [Route("get-classRoutinesByCourseDurationId")]
    public async Task<ActionResult<List<ClassRoutineDto>>> GetClassRoutinesByCourseDurationId([FromQuery] QueryParams queryParams, int courseDurationId)
    {
        var ClassRoutines = await _mediator.Send(new GetClassRoutineListByCourseDurationIdRequest
        {
            QueryParams = queryParams,
            CourseDurationId = courseDurationId
        });
        return Ok(ClassRoutines);
    }

    [HttpGet]
    [Route("get-bnaClassRoutineAll")]
    public async Task<ActionResult> GetClassRoutine([FromQuery] QueryParams queryParams, int baseSchoolNameId,int bnaSemesterId, int weekID)
    {
        var BnaClassRoutine = await _mediator.Send(new GetBnaClassRoutineListRequestNew
        { BaseSchoolNameId = baseSchoolNameId, 
            BnaSemesterId = bnaSemesterId, 
            WeekID = weekID });
        return Ok(BnaClassRoutine);
    }



    [HttpGet]
    [Route("get-classRoutineDetail/{id}")]
    public async Task<ActionResult<ClassRoutineDto>> Get(int id)
    {
        var ClassRoutine = await _mediator.Send(new GetClassRoutineDetailRequest { ClassRoutineId = id });
        return Ok(ClassRoutine);
    }


    [HttpGet]
    [Route("get-subjectNameIdFromclassRoutine")]
    public async Task<ActionResult<int>> GetSubjectNameIdFromclassRoutine(int id)
    {
        var ClassRoutine = await _mediator.Send(new GetSubjectNameIdFromclassRoutineRequest { ClassRoutineId = id });
        return Ok(ClassRoutine);
    }

    //[HttpPost]
    //[ProducesResponseType(200)]
    //[ProducesResponseType(400)]
    //[Route("save-classRoutine")]
    //public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateClassRoutineDto ClassRoutine)
    //{
    //    var command = new CreateClassRoutineCommand { ClassRoutineDto = ClassRoutine };
    //    var response = await _mediator.Send(command);
    //    return Ok(response);
    //}

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-classRoutine")]
    public async Task<ActionResult<BaseCommandResponse>> Post(ClassRoutineListDto ClassRoutine)
    {
        //    var json = Newtonsoft.Json.JsonConvert.SerializeObject(ClassRoutine);
        var command = new CreateClassRoutineListCommand { ClassRoutineDto = ClassRoutine };
        var response = await _mediator.Send(command);
        return Ok(response);
       // return Ok();
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaclassRoutine")]
    public async Task<ActionResult<BaseCommandResponse>> BnaClassRoutine(ClassRoutineListDto ClassRoutine)
    {
        //    var json = Newtonsoft.Json.JsonConvert.SerializeObject(ClassRoutine);
        var command = new CreateClassRoutineListCommand { ClassRoutineDto = ClassRoutine };
        var response = await _mediator.Send(command);
        return Ok(response);
        // return Ok();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-classRoutine/{id}")]
    public async Task<ActionResult> Put([FromBody] CreateClassRoutineDto ClassRoutine)
    {
        var command = new UpdateClassRoutineCommand { ClassRoutineDto = ClassRoutine };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-classRoutine/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteClassRoutineCommand { ClassRoutineId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data

    [HttpGet]
    [Route("get-selectedClassRoutines")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedClassRoutine()
    {
        var selectedClassRoutine = await _mediator.Send(new GetSelectedClassRoutineRequest { });
        return Ok(selectedClassRoutine);
    }

    [HttpGet]
    [Route("get-classRoutineCountByParemeterRequest")]
    public async Task<ActionResult> GetClassRoutineCountByParameterRequest(int baseSchoolNameId, int courseNameId, int bnaSubjectNameId, int courseDurationId, int courseSectionId)
    {
        var classRoutineCount = await _mediator.Send(new GetClassRoutineCountByParametersRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId,
            CourseDurationId = courseDurationId,
            CourseSectionId = courseSectionId
        });
        return Ok(classRoutineCount);
    }

    [HttpGet]
    [Route("get-classRoutineByParameters")]

    public async Task<ActionResult> GetClassRoutineByParameters(int baseSchoolNameId, int courseNameId, int bnaSubjectNameId)
    {
        var ClassRoutineByParameters = await _mediator.Send(new GetClassRoutineByParametersRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(ClassRoutineByParameters);
    }

    [HttpGet]
    [Route("get-selectedClassRoutineByParameters")]

    public async Task<ActionResult<List<SelectedModel>>> GetSelectedClassRoutineByParameters(int baseSchoolNameId, int courseNameId, int courseModuleId, int bnaSubjectNameId)
    {
        var selectedClassRoutines = await _mediator.Send(new GetSelectedClassRoutineByParametersRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseModuleId = courseModuleId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(selectedClassRoutines);
    }

    [HttpGet]
    [Route("get-classRoutineBySchoolCourseDuration")]

    public async Task<ActionResult> GetClassRoutineBySchoolCourseDuration(int baseSchoolNameId, int courseNameId, int courseDurationId)
    {
        var ClassRoutineByParameters = await _mediator.Send(new GetClassRoutineBySchoolCourseDurationRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId
        });
        return Ok(ClassRoutineByParameters);
    }

    [HttpGet]
    [Route("get-subjectNameFromRoutine")]

    public async Task<ActionResult> GetSubjectNameFromRoutine(int baseSchoolNameId, int courseNameId, DateTime date, int classPeriodId, int courseDurationId)
    {
        var subjectName = await _mediator.Send(new GetSubjectNameFromClassRoutineRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            Date = date,
            ClassPeriodId = classPeriodId,
            CourseDurationId = courseDurationId
        });
        return Ok(subjectName);
    }


    [HttpGet]
    [Route("get-subjectNameFromRoutineForLocalCourse")]

    public async Task<ActionResult> GetSubjectNameFromRoutine(int baseSchoolNameId, int courseNameId, DateTime date, int classPeriodId, int courseDurationId, int courseSectionId)
    {
        var subjectName = await _mediator.Send(new GetSubjectNameFromClassRoutineForLocalCourseRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            Date = date,
            ClassPeriodId = classPeriodId,
            CourseDurationId = courseDurationId,
            CourseSectionId = courseSectionId
        });
        return Ok(subjectName);
    }

    [HttpGet]
    [Route("get-SelectedRoutineId")]
    public async Task<ActionResult> GetSelectedRoutineId(int baseSchoolNameId, int courseNameId, int classPeriodId)
    {
        var routineId = await _mediator.Send(new GetSelectedRoutineIdRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            ClassPeriodId = classPeriodId
        });
        return Ok(routineId);
    }

    [HttpGet]
    [Route("get-SelectedRoutineIdFilter")]
    public async Task<ActionResult> GetSelectedRoutineIdFilter(int baseSchoolNameId, int courseNameId, int classPeriodId, int courseDurationId, DateTime date, int courseSectionId)
    {
        var routineId = await _mediator.Send(new GetSelectedRoutineIdFilterRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            ClassPeriodId = classPeriodId,
            CourseDurationId = courseDurationId,
            CourseSectionId = courseSectionId,
            Date = date
        });
        return Ok(routineId);
    }

    [HttpGet]
    [Route("get-SelectedRoutineIdWithSchoolCourseSubject")]
    public async Task<ActionResult> GetSelectedRoutineIdWithSchoolCourseSubject(int baseSchoolNameId, int courseNameId, int bnaSubjectNameId)
    {
        var routineId = await _mediator.Send(new GetSelectedRoutineIdWithSchoolCourseSubjectRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(routineId);
    }

    [HttpGet]
    [Route("get-classRoutineByCourseNameBaseSchoolNameSpRequest")]

    public async Task<ActionResult> GetClassRoutineByCourseNameBaseSchoolNameSpRequestRequest(int baseSchoolNameId, int courseNameId, int courseWeekId, int courseSectionId)
    {
        var routineList = await _mediator.Send(new GetClassRoutineByCourseNameBaseSchoolNameSpRequestRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseWeekId = courseWeekId,
            CourseSectionId = courseSectionId
        });
        return Ok(routineList);
    }

 

    [HttpGet]
    [Route("get-subjectsByRoutineListBNAClass")]
    public async Task<ActionResult> GetSubjectsByRoutineListBNAClass(int baseSchoolNameId, int courseNameId, int courseWeekId, int courseSectionId)
    {
        var SubjectNameValue = await _mediator.Send(new GetSubjectsByRoutineListBNAClassRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseWeekId = courseWeekId,
            CourseSectionId = courseSectionId
        });
        return Ok(SubjectNameValue);
    }

    [HttpGet]
    [Route("get-subjectsByRoutineListBNAexam")]
    public async Task<ActionResult> GetSubjectsByRoutineListBNAexam(int baseSchoolNameId, int courseNameId, int courseDurationId, int courseWeekId, int courseSectionId)
    {
        var SubjectNameValue = await _mediator.Send(new GetSubjectsByRoutineListBNAexamRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseWeekId = courseWeekId,
            CourseSectionId = courseSectionId
        });
        return Ok(SubjectNameValue);
    }


     
    [HttpGet]
    [Route("get-classRoutineForSchoolDashboard")]

    public async Task<ActionResult> GetClassRoutineForSchoolDashboard(int baseSchoolNameId, int courseNameId, int courseDurationId, int courseSectionId)
    {
        var routineList = await _mediator.Send(new GetClassRoutineForSchoolDashboardSpRequestRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            CourseSectionId = courseSectionId
        });
        return Ok(routineList);
    }

    [HttpGet]
    [Route("get-qexamRoutine")]

    public async Task<ActionResult> GetQexamRoutine(int courseDurationId)
    {
        var routineList = await _mediator.Send(new GetQexamRoutineSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(routineList);
    }

    [HttpGet]
    [Route("get-qexamRoutineByBranch")]

    public async Task<ActionResult> GetQexamRoutineByBranch(int courseDurationId, int branchId)
    {
        var routineListByBranch = await _mediator.Send(new GetQexamRoutineByBranchIdSpRequest
        {
            CourseDurationId = courseDurationId,
            BranchId = branchId
        });
        return Ok(routineListByBranch);
    }

    [HttpGet]
    [Route("get-classRoutineLisByParams")]

    public async Task<ActionResult> GetClassRoutineListByParams(int baseSchoolNameId, int courseDurationId, int courseNameId, int courseWeekId, int courseSectionId)
    {
        var ClassRoutineListByParams = await _mediator.Send(new GetClassRoutineListByParamsRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseDurationId = courseDurationId,
            CourseNameId = courseNameId,
            CourseWeekId = courseWeekId,
            CourseSectionId = courseSectionId
        });
        return Ok(ClassRoutineListByParams);
    }

    [HttpGet]
    [Route("get-classRoutineHeaderByParams")]

    public async Task<ActionResult> GetClassRoutineHeaderByParams(int baseSchoolNameId, int courseNameId, int courseDurationId, int courseSectionId)
    {
        var classRoutineHeaderByParams = await _mediator.Send(new GetClassRoutineHeaderByParamsRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseDurationId = courseDurationId,
            CourseNameId = courseNameId,
            CourseSectionId = courseSectionId
        });
        return Ok(classRoutineHeaderByParams);
    }

    [HttpGet]
    [Route("get-centralExamRoutineLisByParams")]

    public async Task<ActionResult> GetCentralExamRoutineListByParams(int courseDurationId)
    {
        var CentralExamRoutineListByParams = await _mediator.Send(new GetCentralExamRoutineListByParamsRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(CentralExamRoutineListByParams);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("update-weeklyClassRoutine")]

    public async Task<ActionResult<BaseCommandResponse>> UpdateWeeklyClassRoutine([FromBody] UpdateClassRoutineDtoList routineList)
    {
        var command = new UpdateWeeklyClassRoutineListCommand { UpdateClassRoutineDtoList = routineList };
        var response = await _mediator.Send(command);
        //return Ok(response);
        return Ok();
    }

    [HttpGet]
    [Route("get-upcommingClassesForInstructorDashboardSpRequest")]

    public async Task<ActionResult> GetUpcommingClassesForInstructorDashboardSpRequest(int traineeId)
    {
        var routineList = await _mediator.Send(new GetUpcommingClassesForInstructorDashboardSpRequest
        {
            CurrentDate = DateTime.Now,
            TraineeId = traineeId
        });
        return Ok(routineList);
    }

    [HttpGet]
    [Route("get-SelectedRoutineIdForStaffCollege")]
    public async Task<ActionResult> GetSelectedRoutineIdForStaffCollege(int courseDurationId, int courseNameId, int bnaSubjectNameId)
    {
        var routineId = await _mediator.Send(new GetSelectedRoutineIdForStaffCollegeRequest
        {
            CourseDurationId = courseDurationId,
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(routineId);
    }

    [HttpGet]
    [Route("get-routineListForRoutineNote")]
    public async Task<ActionResult<List<SelectedModel>>> GetRoutineListForRoutineNote(int baseSchoolNameId, int courseNameId, int courseDurationId, int courseWeekId)
    {
        var selectedClassRoutine = await _mediator.Send(new GetRoutineListForRoutineNoteRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            CourseWeekId = courseWeekId
        });
        return Ok(selectedClassRoutine);
    }

    [HttpGet]
    [Route("get-upcomingTodayClassByCourse")]
    public async Task<ActionResult<List<SelectedModel>>> GetUpcomingTodayClassByCourse(int baseSchoolNameId, int courseNameId, int courseDurationId, int bnaSubjectNameId, int traineeId)
    {
        var selectedClassRoutine = await _mediator.Send(new GetUpcomingTodayClassByCourseSpRequest
        {
            CurrentDate = DateTime.Now,
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            BnaSubjectNameId = bnaSubjectNameId,
            TraineeId = traineeId
        });
        return Ok(selectedClassRoutine);
    }

    [HttpGet]
    [Route("get-selectedMarkTypeFromClassRoutines")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedMarkTypeFromClassRoutine(int classRoutineId)
    {
        var selectedMarkType = await _mediator.Send(new GetSelectedMarkTypeFromClassRoutineRequest
        {
            ClassRoutineId = classRoutineId
        });
        return Ok(selectedMarkType);
    }

    [HttpGet]
    [Route("get-instructorAvailabilityByDateAndPeriod")]

    public async Task<ActionResult> GetInstructorAvailabilityByDateAndPeriod(int traineeId, int classPeriodId, DateTime date)
    {
        var checkInstructorClass = await _mediator.Send(new GetInstructorAvailabilityByDateAndPeriodRequest
        {
            TraineeId = traineeId,
            ClassPeriodId = classPeriodId,
            Date = date
        });
        return Ok(checkInstructorClass);
    }

}

