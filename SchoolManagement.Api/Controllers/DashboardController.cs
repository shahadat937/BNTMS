using SchoolManagement.Application;
using SchoolManagement.Application.Features.Attendances.Requests.Queries;
using SchoolManagement.Application.Features.BaseSchoolNames.Requests.Queries;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Queries;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Queries;
using SchoolManagement.Application.Features.CourseModules.Requests.Queries;
using SchoolManagement.Application.Features.Documents.Requests.Queries;
using SchoolManagement.Application.Features.Events.Requests.Queries;
using SchoolManagement.Application.Features.ForeignCourseGOInfos.Requests.Queries;
using SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Queries;
using SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Queries;
using SchoolManagement.Application.Features.Notices.Requests.Queries;
using SchoolManagement.Application.Features.Notifications.Requests.Queries;
using SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries;
using SchoolManagement.Application.Features.TdecQuationGroups.Requests.Queries;
using SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Queries;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Dashboard)]
[ApiController]
[Authorize]
public class DashboardController : ControllerBase
{
    private readonly IMediator _mediator;

    public DashboardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    

    [HttpGet]
    [Route("get-courseDurationfromprocedure")]
    public async Task<ActionResult> GetCourseDurationFromProcedure(int courseTypeId, DateTime CurrentDate)
    {
        var proceduredCourses = await _mediator.Send(new GetCourseDurationListFromSpRequest { 
            CourseTypeId = courseTypeId,
            CurrentDate = CurrentDate
        });
        return Ok(proceduredCourses);
    }



    [HttpGet]
    [Route("get-centralCourseDurationByTypeAndName")]
    public async Task<ActionResult> GetCentralCourseDurationByTypeAndName(int courseTypeId, int courseNameId)
    {
        var proceduredCourses = await _mediator.Send(new GetCourseDurationByTypeAndNameFromSpRequest
        {
            CourseTypeId = courseTypeId,
            CourseNameId = courseNameId
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-remittanceNotification")]
    public async Task<ActionResult> GetRemittanceNotification()
    {
        var proceduredCourses = await _mediator.Send(new GetRemittanceNotificationBySpRequest
        { 
            
        });
        return Ok(proceduredCourses);
    }


    [HttpGet]
    [Route("get-foreignCourseDurationfromprocedure")]
    public async Task<ActionResult> GetForeignCourseDurationfromprocedure(int courseTypeId, DateTime CurrentDate)
    {
        var proceduredCourses = await _mediator.Send(new GetForeignCourseDurationListFromSpRequest
        {
            CourseTypeId = courseTypeId,
            CurrentDate = CurrentDate
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-remittanceNotificationForStudent")]
    public async Task<ActionResult> GetRemittanceNotificationForStudent(int traineeId, int courseDurationId)
    {
        var proceduredCourses = await _mediator.Send(new GetRemittanceNotificationForStudentBySpRequest
        {
            TraineeId = traineeId,
            CourseDurationId = courseDurationId
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-runningCourseDurationfromprocedure")]
    public async Task<ActionResult> GetRunningCourseDurationfromprocedure(int courseTypeId, DateTime CurrentDate, int viewStatus)
    {
        var proceduredCourses = await _mediator.Send(new GetRunningCourseDurationListFromSpRequest
        {
            CourseTypeId = courseTypeId,
            CurrentDate = CurrentDate,
            ViewStatus = viewStatus
        });
        return Ok(proceduredCourses);
    }


    [HttpGet]
    [Route("get-runningCourseDurationListBySchool")]
    public async Task<ActionResult> GetRunningCourseDurationListBySchool(int baseSchoolNameId, DateTime CurrentDate)
    {
        var proceduredCourses = await _mediator.Send(new GetRunningCourseDurationListBySchoolSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CurrentDate = CurrentDate
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-runningCourseDurationBySchool")]
    public async Task<ActionResult> GetRunningCourseDurationBySchool(int courseTypeId, DateTime CurrentDate, int baseSchoolNameId, int viewStatus)
    {
        var proceduredCourses = await _mediator.Send(new GetRunningCourseDurationListBySchoolFromSpRequest
        {
            CourseTypeId = courseTypeId,
            CurrentDate = CurrentDate,
            BaseSchoolNameId = baseSchoolNameId,
            ViewStatus = viewStatus
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-upcomingCourseDurationBySchool")]
    public async Task<ActionResult> GetUpcomingCourseDurationBySchool(int courseTypeId, DateTime CurrentDate, int baseSchoolNameId)
    {
        var proceduredCourses = await _mediator.Send(new GetUpcomingCourseDurationListBySchoolFromSpRequest
        {
            CourseTypeId = courseTypeId,
            CurrentDate = CurrentDate,
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(proceduredCourses);
    }


    [HttpGet]
    [Route("get-upcomingCourseDurationByNbcdSchool")]
    public async Task<ActionResult> GetUpcomingCourseDurationByNbcdSchool(int courseTypeId, DateTime CurrentDate, int baseSchoolNameId)
    {
        var proceduredCourses = await _mediator.Send(new GetUpcomingCourseDurationListByNbcdSchoolFromSpRequest
        {
            CourseTypeId = courseTypeId,
            CurrentDate = CurrentDate,
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(proceduredCourses);
    }


    [HttpGet]
    [Route("get-upcomingCourseDurationByBase")]
    public async Task<ActionResult> GetUpcomingCourseDurationByBase(int baseNameId, DateTime CurrentDate)
    {
        var proceduredCourses = await _mediator.Send(new GetUpcomingCourseListByBaseFromSpRequest
        {
            BaseNameId = baseNameId,
            CurrentDate = CurrentDate
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-runningCourseTotalTraineeByCourseType")]
    public async Task<ActionResult> GetRunningCourseTotalTraineeByCourseType(DateTime currentDate, int courseTypeId, int traineeStatusId)
    {
        var courseTotalTraineeByCourseType = await _mediator.Send(new GetRunningCourseTotalTraineeByCourseTypeListFromSpRequest
        {
            CourseTypeId = courseTypeId,
            CurrentDate = currentDate,
            TraineeStatusId = traineeStatusId
        });
        return Ok(courseTotalTraineeByCourseType);
    }

    [HttpGet]
    [Route("get-runningForeignCourseDurationfromprocedure")]
    public async Task<ActionResult> GetRunningForeignCourseDurationfromprocedure(int courseTypeId, DateTime CurrentDate)
    {
        var proceduredCourses = await _mediator.Send(new GetRunningForeignCourseDurationListFromSpRequest
        {
            CourseTypeId = courseTypeId,
            CurrentDate = CurrentDate
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-upcomingCourseListByType")]
    public async Task<ActionResult> GetUpcomingCourseListByType(int courseTypeId, DateTime CurrentDate)
    {
        var CourseListByType = await _mediator.Send(new GetUpcomingCourseListByTypeFromSpRequest
        {
            CourseTypeId = courseTypeId,
            CurrentDate = CurrentDate
        });
        return Ok(CourseListByType);
    }

    [HttpGet]
    [Route("get-runningCourseTotalOfficerListfromprocedure")]
    public async Task<ActionResult> GetRunningCourseTotalOfficerListfromprocedure(int TraineeStatusId, DateTime CurrentDate)
    {
        var proceduredCourses = await _mediator.Send(new GetRunningCourseTotalOfficerListFromSpRequest
        {
            TraineeStatusId = TraineeStatusId,
            CurrentDate = CurrentDate
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-runningCourseTotalOfficerListBySchool")]
    public async Task<ActionResult> GetRunningCourseTotalOfficerListBySchool(int TraineeStatusId, DateTime CurrentDate, int baseSchoolNameId)
    {
        var proceduredCourses = await _mediator.Send(new GetRunningCourseTotalOfficerListBySchoolFromSpRequest
        {
            TraineeStatusId = TraineeStatusId,
            CurrentDate = CurrentDate,
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-courseTotalOfficerListByBase")]
    public async Task<ActionResult> GetCourseTotalOfficerListByBase(int TraineeStatusId, DateTime CurrentDate, int baseNameId)
    {
        var proceduredCourses = await _mediator.Send(new GetCourseTotalOfficerListByBaseFromSpRequest
        {
            TraineeStatusId = TraineeStatusId,
            CurrentDate = CurrentDate,
            BaseNameId = baseNameId
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-nominatedCourseListFromSpRequest")]
    public async Task<ActionResult> GetNominatedCourseListFromSpRequest(DateTime CurrentDate)
    {
        var proceduredNominee = await _mediator.Send(new GetNominatedCourseListFromSpRequest
        {
            CurrentDate = CurrentDate
        });
        return Ok(proceduredNominee);
    }

    [HttpGet]
    [Route("get-nominatedCourseListFromSpRequestBySchoolId")]
    public async Task<ActionResult> GetNominatedCourseListFromSpRequestBySchoolId(DateTime CurrentDate, int baseSchoolNameId)
    {
        var proceduredNominee = await _mediator.Send(new GetNominatedCourseListBySchoolFromSpRequest
        {
            CurrentDate = CurrentDate,
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(proceduredNominee);
    }

    [HttpGet]
    [Route("get-nominatedTotalTraineeByBaseFromSp")]
    public async Task<ActionResult> GetNominatedTotalTraineeByBaseFromSp(int baseNameId)
    {
        var proceduredNominee = await _mediator.Send(new GetNominatedTotalTraineeByBaseSpRequest
        {
            BaseNameId = baseNameId
        });
        return Ok(proceduredNominee);
    }

    [HttpGet]
    [Route("get-nominatedForeignTraineeFromSpRequestBySchoolId")]
    public async Task<ActionResult> GetNominatedForeignTraineeFromSpRequestBySchoolId(DateTime CurrentDate, int baseSchoolNameId, int officerTypeId)
    {
        var proceduredNominee = await _mediator.Send(new GetNominatedForeignTraineeBySchoolFromSpRequest
        {
            CurrentDate = CurrentDate,
            BaseSchoolNameId = baseSchoolNameId,
            OfficerTypeId = officerTypeId
        });
        return Ok(proceduredNominee);
    }

    [HttpGet]
    [Route("get-nominatedTraineeByTypeAndBase")]
    public async Task<ActionResult> GetNominatedTraineeByTypeAndBaseSpRequest(DateTime CurrentDate, int baseNameId, int officerTypeId)
    {
        var proceduredNominee = await _mediator.Send(new GetNominatedTraineeByTypeAndBaseSpRequest
        {
            //CurrentDate = CurrentDate,
            BaseNameId = baseNameId,
            OfficerTypeId = officerTypeId
        });
        return Ok(proceduredNominee);
    }


    [HttpGet]
    [Route("get-traineeAbsentList")]
    public async Task<ActionResult> GetTraineeAbsentListForSchool(DateTime CurrentDate, int baseSchoolNameId)
    {
        var proceduredNominee = await _mediator.Send(new GetTraineeAttendanceListForSchoolIdSpRequest
        {
            CurrentDate = CurrentDate,
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(proceduredNominee);
    }

    [HttpGet]
    [Route("get-spGetTotalTraineeList")]
    public async Task<ActionResult> GetspGetTotalTraineeList()
    {
        var proceduredTrainee = await _mediator.Send(new GetTotalTraineeListFromSpRequest
        {
            
        });
        return Ok(proceduredTrainee);
    }

    [HttpGet]
    [Route("get-spGetSchoolCount")]
    public async Task<ActionResult> GetspGetSchoolCount()
    {
        var proceduredSchool = await _mediator.Send(new GetCountSchoolFromSpRequest
        {

        });
        return Ok(proceduredSchool);
    }
    
    [HttpGet]
    [Route("get-spGetCourseCountBySchool")]
    public async Task<ActionResult> GetspGetCourseCountBySchool()
    {
        var proceduredSchool = await _mediator.Send(new GetCourseCountBySchoolFromSpRequest
        {

        });
        return Ok(proceduredSchool);
    }

    [HttpGet]
    [Route("get-studentInfoByTraineeId")]
    public async Task<ActionResult> GetStudentInfoByTraineeId(int TraineeId)
    {
        var studentInfoByTraineeId = await _mediator.Send(new GetStudentInfoByTraineeIdSpRequest
        {
            TraineeId = TraineeId
        });
        return Ok(studentInfoByTraineeId);
    }

    [HttpGet]
    [Route("get-selectedCourseModulesByCourseNameId")]
    public async Task<ActionResult> GetSelectedCourseModuleByCourseNameId(int courseNameId)
    {
        var CourseModuleValue = await _mediator.Send(new GetSelectedCourseModuleByCourseNameIdRequest
        {
            CourseNameId = courseNameId,
        });
        return Ok(CourseModuleValue);
    }

    [HttpGet]
    [Route("get-traineeAttendanceDetails")]
    public async Task<ActionResult> GetTraineeAttendanceDetails(int traineeId)
    {
        var traineeAttendanceDetails = await _mediator.Send(new GetTraineeAttendanceDetailsByTraineeIdSpRequest
        {
            TraineeId = traineeId,
        });
        return Ok(traineeAttendanceDetails);
    }

    [HttpGet]
    [Route("get-routineInfoByTraineeIdForStudentDashboard")]

    public async Task<ActionResult> GetRoutineInfoByTraineeIdForStudentDashboard(int courseDurationId, int courseNameId,int baseSchoolNameId, int courseSectionId, int weekStatus)
    {
        var ClassRoutineByParameters = await _mediator.Send(new GetRoutineInfoByTraineeIdSpRequest
        {
            CourseDurationId = courseDurationId,
            CourseNameId = courseNameId,
            BaseSchoolNameId = baseSchoolNameId,
            CourseSectionId = courseSectionId,
            WeekStatus = weekStatus
        });
        return Ok(ClassRoutineByParameters);
    }

    [HttpGet]
    [Route("get-routineInfoBySchoolId")]

    public async Task<ActionResult> GetRoutineInfoBySchoolId(int courseNameId, int baseSchoolNameId)
    {
        var ClassRoutineByParameters = await _mediator.Send(new GetRoutineInfoBySchoolIdSpRequest
        {
            CourseNameId = courseNameId,
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(ClassRoutineByParameters);
    }

    [HttpGet]
    [Route("get-currentRoutineInfoBySchoolId")]

    public async Task<ActionResult> GetCurrentRoutineInfoBySchoolId(DateTime currentDate, int baseSchoolNameId)
    {
        var ClassRoutineByParameters = await _mediator.Send(new GetCurrentRoutineInfoBySpRequest
        {
            CurrentDate = currentDate,
            BaseSchoolNameId = baseSchoolNameId

        });
        return Ok(ClassRoutineByParameters);
    }

    [HttpGet]
    [Route("get-examRoutineInfoBySchoolId")]

    public async Task<ActionResult> GetExamRoutineInfoBySchoolId(int courseDurationId)
    {
        var examRoutineByParameters = await _mediator.Send(new GetExamRoutineForStudentDashboardSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(examRoutineByParameters);
    }

    [HttpGet]
    [Route("get-currentAttendanceInfoBySchoolId")]

    public async Task<ActionResult> GetCurrentAttendanceInfoBySchoolId(DateTime currentDate, int baseSchoolNameId)
    {
        var ClassAttendanceByParameters = await _mediator.Send(new GetCurrentAttendanceInfoBySpRequest
        {
            CurrentDate = currentDate,
            BaseSchoolNameId = baseSchoolNameId

        });
        return Ok(ClassAttendanceByParameters);
    }

    [HttpGet]
    [Route("get-currentRoutineDetailsBySchoolId")]

    public async Task<ActionResult> GetCurrentRoutineDetailsBySpRequest(DateTime currentDate, int courseNameId, int baseSchoolNameId)
    {
        var ClassRoutineByParameters = await _mediator.Send(new GetCurrentRoutineDetailsBySpRequest
        {
            CurrentDate = currentDate,
            CourseNameId = courseNameId,
            BaseSchoolNameId = baseSchoolNameId

        });
        return Ok(ClassRoutineByParameters);
    }

    [HttpGet]
    [Route("get-combinedClassByCourseForBNA")]

    public async Task<ActionResult> GetCombinedClassByCourseForBNA(int baseSchoolNameId, int courseNameId, DateTime currentDate)
    {
        var ClassRoutineByParameters = await _mediator.Send(new GetCombinedClassByCourseForBNASpRequest
        {
            CurrentDate = currentDate,
            CourseNameId = courseNameId,
            BaseSchoolNameId = baseSchoolNameId

        });
        return Ok(ClassRoutineByParameters);
    }

    [HttpGet]
    [Route("get-currentAttendanceDetailsBySchoolId")]

    public async Task<ActionResult> GetCurrentAttendanceDetailsBySpRequest(DateTime currentDate, int courseNameId, int baseSchoolNameId, int courseDurationId)
    {
        var AttendanceByParameters = await _mediator.Send(new GetCurrentAttendanceDetailsBySpRequest
        {
            CurrentDate = currentDate,
            CourseNameId = courseNameId,
            BaseSchoolNameId = baseSchoolNameId,
            CourseDurationId = courseDurationId
        });
        return Ok(AttendanceByParameters);
    }

    [HttpGet]
    [Route("get-currentAttendanceDetailsByRoutine")]

    public async Task<ActionResult> GetCurrentAttendanceDetailsByRoutineSpRequest(int courseNameId, int baseSchoolNameId, int courseDurationId, int classRoutineId)
    {
        var AttendanceByParameters = await _mediator.Send(new GetCurrentAttendanceDetailsByRoutineSpRequest
        {
            CourseNameId = courseNameId,
            BaseSchoolNameId = baseSchoolNameId,
            CourseDurationId = courseDurationId,
            ClassRoutineId = classRoutineId

        });
        return Ok(AttendanceByParameters);
    }

    [HttpGet]
    [Route("get-routineInfoByCourse")]

    public async Task<ActionResult> GetRoutineInfoByCourse(int baseSchoolNameId)
    {
        var ClassRoutineByCourses = await _mediator.Send(new GetRoutineInfoByCourseSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(ClassRoutineByCourses);
    }

    [HttpGet]
    [Route("get-instructorByCourse")]

    public async Task<ActionResult> GetInstructorInfoByCourse(int baseSchoolNameId)
    {
        var InstructorInfoByCourse = await _mediator.Send(new GetInstructorByCourseSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(InstructorInfoByCourse);
    }

    [HttpGet]
    [Route("get-instructorBySchoolForCO")]

    public async Task<ActionResult> GetInstructorInfoBySchoolForCO(int baseNameId)
    {
        var InstructorInfoBySchoolForCO = await _mediator.Send(new GetInstructorBySchoolForCOSpRequest
        {
            BaseNameId = baseNameId
        });
        return Ok(InstructorInfoBySchoolForCO);
    }

    [HttpGet]
    [Route("get-instructorDetailByCourse")]

    public async Task<ActionResult> GetInstructorDetailByCourse(int baseSchoolNameId, int courseNameId, int courseDurationId)
    {
        var InstructorInfoByCourse = await _mediator.Send(new GetInstructorDetailByCourseSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId
        });
        return Ok(InstructorInfoByCourse);
    }

    [HttpGet]
    [Route("get-readingMaterialBySchool")]

    public async Task<ActionResult> GetReadingMaterialBySchool(int baseSchoolNameId)
    {
        var readingMaterialBySchool = await _mediator.Send(new GetReadingMaterialBySchoolSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(readingMaterialBySchool);
    }

    [HttpGet]
    [Route("get-readingMaterialByBase")]

    public async Task<ActionResult> GetReadingMaterialByBase(int baseNameId)
    {
        var readingMaterialByBase = await _mediator.Send(new GetReadingMaterialByBaseSpRequest
        {
            BaseNameId = baseNameId
        });
        return Ok(readingMaterialByBase);
    }

    [HttpGet]
    [Route("get-readingMaterialByCourse")]

    public async Task<ActionResult> GetReadingMaterialByCourse(int baseSchoolNameId, int courseNameId)
    {
        var readingMaterialBySchool = await _mediator.Send(new GetReadingMaterialByCourseSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(readingMaterialBySchool);
    }

    [HttpGet]
    [Route("get-pendingExamEvaluation")]

    public async Task<ActionResult> GetPendingExamEvaluation(int baseSchoolNameId)
    {
        var ExamEvaluationByParameters = await _mediator.Send(new GetPendingExamMarkInfoBySchoolIdSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(ExamEvaluationByParameters);
    }

    [HttpGet]
    [Route("get-instructorPendingExamEvaluation")]

    public async Task<ActionResult> GetInstructorPendingExamEvaluation(int traineeId, int courseDurationId)
    {
        var ExamEvaluationByParameters = await _mediator.Send(new GetPendingInstructorExamMarkInfoBySchoolIdSpRequest
        {
            TraineeId = traineeId,
            CourseDurationId = courseDurationId
        });
        return Ok(ExamEvaluationByParameters);
    }

    [HttpGet]
    [Route("get-readingMAterialInfoBySchoolAndCourse")]
    public async Task<ActionResult> GetReadingMAterialInfoBySchoolAndCourse(int BaseSchoolNameId, int CourseNameId)
    {
        var readingMAterialInfoBySchoolAndCourse = await _mediator.Send(new GetReadingMaterialInfoBySchoolAndCourseRequest
        {
            BaseSchoolNameId = BaseSchoolNameId,
            CourseNameId = CourseNameId
        });
        return Ok(readingMAterialInfoBySchoolAndCourse);
    }

    [HttpGet]
    [Route("get-attendanceByTraineeAndCourseDuration")]
    public async Task<ActionResult> GetAttendanceByTraineeAndCourseDuration(int traineeId, int courseDurationId)
    {
        var attendanceByTraineeAndCourseDuration = await _mediator.Send(new GetAttendanceByTraineeIdAndCourseDurationSpRequest
        {
            TraineeId = traineeId,
            CourseDurationId = courseDurationId
        });
        return Ok(attendanceByTraineeAndCourseDuration);
    }


    [HttpGet]
    [Route("get-instructorInfoByTraineeId")]
    public async Task<ActionResult> GetInstructorInfoByTraineeId(int TraineeId)
    {
        var instructorInfoByTraineeId = await _mediator.Send(new GetInstructorInfoByTraineeIdSpRequest
        {
            TraineeId = TraineeId
        });
        return Ok(instructorInfoByTraineeId);
    }


    [HttpGet]
    [Route("get-instructorRoutineByTraineeId")]
    public async Task<ActionResult> GetInstructorRoutineByTraineeId(int TraineeId)
    {
        var instructorRoutineByTraineeId = await _mediator.Send(new GetInstructorRoutineByTraineeIdSpRequest
        {
            TraineeId = TraineeId
        });
        return Ok(instructorRoutineByTraineeId);
    }

    [HttpGet]
    [Route("get-readingMaterialByTraineeId")]
    public async Task<ActionResult> GetReadingMaterialByTraineeId(int baseSchoolNameId)
    {
        var ReadingMaterialByTraineeId = await _mediator.Send(new GetReadingMaterialByTraineeIdSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(ReadingMaterialByTraineeId);
    }

    [HttpGet]
    [Route("get-currentRoutineForStudentDashboardSpRequest")]

    public async Task<ActionResult> GetCurrentRoutineForStudentDashboardSpRequestHandler(int courseDurationId, int courseSectionId)
    {
        var routineList = await _mediator.Send(new GetCurrentRoutineForStudentDashboardSpRequest
        {
            CurrentDate = DateTime.Now,
            CourseDurationId = courseDurationId,
            CourseSectionId = courseSectionId
        });
        return Ok(routineList);
    }

    [HttpGet]
    [Route("get-traineeAttendanceList")]

    public async Task<ActionResult> GetTraineeAttendanceListHandler(int traineeId,int courseDurationId, int courseSectionId, int attendanceStatus)
    {
        var routineList = await _mediator.Send(new GetTraineeAttendanceListSpRequest
        {
            TraineeId = traineeId,
            CourseDurationId = courseDurationId,
            CourseSectionId = courseSectionId,
            AttendanceStatus = attendanceStatus
        });
        return Ok(routineList);
    }
    

    [HttpGet]
    [Route("get-jcoRoutineForStudentDashboardSpRequest")]

    public async Task<ActionResult> GetJcoRoutineForStudentDashboardSpRequestHandler(int courseDurationId,int saylorBranchId, int saylorSubBranchId)
    {
        var routineList = await _mediator.Send(new GetJcoRoutineForStudentDashboardSpRequest
        {
            CurrentDate = DateTime.Now,
            CourseDurationId = courseDurationId,
            SaylorBranchId = saylorBranchId,
            SaylorSubBranchId = saylorSubBranchId
        });
        return Ok(routineList);
    }

    [HttpGet]
    [Route("get-noticeBySchoolId")]
    public async Task<ActionResult> GetNoticeBySchoolId(int BaseSchoolNameId, DateTime CurrentDate)
    {
        var proceduredCourses = await _mediator.Send(new GetNoticeBySchoolIdSpRequest
        {
            BaseSchoolNameId = BaseSchoolNameId,
            CurrentDate = CurrentDate
        });
        return Ok(proceduredCourses);
    }
    

    [HttpGet]
    [Route("get-noticeByTraineeDashboard")]
    public async Task<ActionResult> GetNoticeForTraineeDashboard(int baseSchoolNameId, DateTime currentDate, int courseDurationId, int traineeId)
    {
        var proceduredCourses = await _mediator.Send(new GetNoticeForTraineeDashboardSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CurrentDate = currentDate,
            CourseDurationId =courseDurationId,
            TraineeId = traineeId
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-eventsBySchoolId")]
    public async Task<ActionResult> GetEventsBySchoolId(int BaseSchoolNameId, DateTime CurrentDate)
    {
        var proceduredCourses = await _mediator.Send(new GetEventBySchoolIdSpRequest
        {
            BaseSchoolNameId = BaseSchoolNameId,
            CurrentDate = CurrentDate
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-runningCourseDurationByBase")]
    public async Task<ActionResult> GetRunningCourseDurationByBase(int baseNameId, DateTime currentDate,int viewStatus)
    {
        var proceduredCourses = await _mediator.Send(new GetRunningCourseDurationByBaseSpRequest
        {
            BaseNameId = baseNameId,
            CurrentDate = currentDate,
            ViewStatus = viewStatus
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-tdecQuestionGroupListBySp")]
    public async Task<ActionResult> GetTdecQuestionGroupListBySp(int BaseSchoolNameId, int courseNameId, int courseDurationId)
    {
        var proceduredCourses = await _mediator.Send(new GetTdecQuationGroupListFromSpRequest
        {
            BaseSchoolNameId = BaseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-instructorInfoForCentralExam")]
    public async Task<ActionResult> GetInstructorInfoForCentralExamBySp(int traineeId, int courseNameId, int courseTypeId)
    {
        var proceduredCourses = await _mediator.Send(new GetInstructorInfoForCentralExamByTraineeIdSpRequest
        {
            TraineeId = traineeId,
            CourseNameId = courseNameId,
            CourseTypeId = courseTypeId
        });
        return Ok(proceduredCourses);
    }


    [HttpGet]
    [Route("get-centralExamApproveList")]
    public async Task<ActionResult> GetCentralExamApproveLisBySp( int courseNameId, int courseTypeId)
    {
        var proceduredCourses = await _mediator.Send(new GetCentralExamApproveListSpRequest
        {
            CourseNameId = courseNameId,
            CourseTypeId = courseTypeId
        });
        return Ok(proceduredCourses);
    }


    [HttpGet]
    [Route("get-studentOtherDocInfo")]
    public async Task<ActionResult> GetStudentOtherDocInfoBySp(int traineeId, int courseDurationId)
    {
        var proceduredCourses = await _mediator.Send(new GetStudentOtherDocInfoFromSpRequest
        {
            TraineeId = traineeId,
            CourseDurationId = courseDurationId
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-studentOtherDocuments")]
    public async Task<ActionResult> GetStudentOtherDocumentsBySp(int traineeId, int courseDurationId)
    {
        var proceduredCourses = await _mediator.Send(new GetStudentOtherDocumentsFromSpRequest
        {
            TraineeId = traineeId,
            CourseDurationId = courseDurationId
        });
        return Ok(proceduredCourses);
    }



    [HttpGet]
    [Route("get-interServiceDocuments")]
    public async Task<ActionResult> GetInterServiceDocumentsBySp(int courseDurationId)
    {
        var proceduredCourses = await _mediator.Send(new GetInterserviceDocumentsFromSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-studentGoDocument")]
    public async Task<ActionResult> GetStudentGoDocumentBySp(int courseDurationId)
    {
        var proceduredCourses = await _mediator.Send(new GetStudentGoDocumentFromSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-studentOtherDocInfoList")]
    public async Task<ActionResult> GetStudentOtherDocInfoListBySp(int courseDurationId)
    {
        var proceduredCourses = await _mediator.Send(new GetStudentOtherDocInfoListFromSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(proceduredCourses);
    }


    [HttpGet]
    [Route("get-paymentScheduleListByDurationId")]
    public async Task<ActionResult> GetPaymentScheduleListBySp(int courseDurationId)
    {
        var proceduredCourses = await _mediator.Send(new GetPaymentScheduleListBySpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(proceduredCourses);
    }


    [HttpGet]
    [Route("get-examStatusBySubjectList")]
    public async Task<ActionResult> GetExamStatusBySubjectList(int courseDurationId)
    {
        var proceduredCourses = await _mediator.Send(new GetExamStatusBySubjectListSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(proceduredCourses);
    }


    [HttpGet]
    [Route("get-runningCourseDurationForCentralExamList")]
    public async Task<ActionResult> GetRunningCourseDurationForCentralExam(int courseNameId)
    {
        var proceduredCourses = await _mediator.Send(new GetRunningCourseDurationForCentralExamListSpRequest
        {
            CourseNameId = courseNameId
        });
        return Ok(proceduredCourses);
    }


    [HttpGet]
    [Route("get-readingMaterialByType")]
    public async Task<ActionResult> GetReadingMaterialByType(int documentTypeId)
    {
        var proceduredCourses = await _mediator.Send(new GetReadingMaterialByTypeListSpRequest
        {
            DocumentTypeId = documentTypeId
        });
        return Ok(proceduredCourses);
    }


    [HttpGet]
    [Route("get-notificationReminderForDashboard")]
    public async Task<ActionResult> GetNotificationReminderForDashboard(string userRole, int receiverId)
    {
        var proceduredCourses = await _mediator.Send(new GetNotificationReminderForDashboardBySpRequest
        {
            UserRole = userRole,
            ReceiverId = receiverId
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-traineeAssessmentForStudentSpRequest")]
    public async Task<ActionResult> GetTraineeAssessmentForStudentSpRequest(int courseDurationId, int traineeId)
    {
        var selectedClassPeriod = await _mediator.Send(new GetTraineeAssessmentForStudentSpRequest
        {
            CurrentDate = DateTime.Now,
            CourseDurationId = courseDurationId,
            TraineeId = traineeId
        });
        return Ok(selectedClassPeriod);
    }

    [HttpGet]
    [Route("get-routineSoftcopyByTraineeSpRequest")]
    public async Task<ActionResult> GetRoutineSoftcopyByTraineeSpRequest(int traineeId)
    {
        var routineSoftCopy = await _mediator.Send(new GetRoutineSoftCopyUploadSpRequest
        {
              TraineeId = traineeId
        });
        return Ok(routineSoftCopy);
    }

    [HttpGet]
    [Route("get-jstiTraineeBasicInfoDetails")]
    public async Task<ActionResult> GetJstiTraineeBasicInfoDetailsSpRequest(int traineeId)
    {
        var JstiTraineeBasicInfoDetails = await _mediator.Send(new GetJstiTraineeBasicInfoDetailsSpRequest
        {
              TraineeId = traineeId
        });
        return Ok(JstiTraineeBasicInfoDetails);
    }

    [HttpGet]
    [Route("get-upcomingCourseDurationforInterServicefromprocedure")]
    public async Task<ActionResult> GetUpcomingCourseDurationforInterServicefromprocedure (int courseTypeId, DateTime CurrentDate)
    {
        var proceduredCourses = await _mediator.Send(new GetUpcomingCourseDurationListForInterServiceFromSpRequest
        {
            CourseTypeId = courseTypeId,
            CurrentDate = CurrentDate
            //ViewStatus = viewStatus
        });
        return Ok(proceduredCourses);
    }

}

