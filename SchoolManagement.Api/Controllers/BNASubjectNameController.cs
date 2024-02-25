using MediatR;
using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Commands;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Application.Features.BNASubjectNames.Requests.Queries;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.CourseDurations.Requests.Commands;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaSubjectName)]
[ApiController]
[Authorize]
public class BnaSubjectNameController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaSubjectNameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaSubjectNames")]
    public async Task<ActionResult<List<BnaSubjectNameDto>>> Get([FromQuery] QueryParams queryParams,int status)
    {
        var BnaSubjectNamees = await _mediator.Send(new GetBnaSubjectNameListRequest
        {
            QueryParams = queryParams,
            Status = status,
        });
        return Ok(BnaSubjectNamees);
    }
    

    [HttpGet]
    [Route("get-bnaSubjectNameDetail/{id}")]
    public async Task<ActionResult<BnaSubjectNameDto>> Get(int id)
    {
        var BnaSubjectName = await _mediator.Send(new GetBnaSubjectNameDetailRequest { Id = id });
        return Ok(BnaSubjectName);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaSubjectName")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaSubjectNameDto BnaSubjectName)
    {
        var command = new CreateBnaSubjectNameCommand { BnaSubjectNameDto = BnaSubjectName };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("deactive-bna-subjectname/{id}")]
    public async Task<ActionResult> DeActiveBnaSubjectName(int id)
    {
        var command = new DeActivateBnaSubjectNameCommand { BnaSubjectNameId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("active-bna-subjectname/{id}")]
    public async Task<ActionResult> ActiveBnaSubjectName(int id)
    {
        var command = new ActivateBnaSubjectNameCommand { BnaSubjectNameId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaSubjectName/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaSubjectNameDto BnaSubjectName)
    {
        var command = new UpdateBnaSubjectNameCommand { BnaSubjectNameDto = BnaSubjectName };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaSubjectName/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaSubjectNameCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBnaSubjectNames")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBnaSubjectName()
    {
        var subjecName = await _mediator.Send(new GetSelectedBnaSubjectNameRequest { });
        return Ok(subjecName);
    }

    [HttpGet]
    [Route("get-selectedSubjectNamesBySchoolAndCourse")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSubjectNamesBySchoolAndCourse(int baseSchoolNameId, int courseNameId)
    {
        var SubjectNameValue = await _mediator.Send(new GetSelectedSubjectNamesBySchoolAndCourseRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(SubjectNameValue);
    }

    [HttpGet]
    [Route("get-dropdownSubjectName")]
    public async Task<ActionResult<List<SelectedModel>>> GetDropdownSubjectNameList(int baseSchoolNameId)
    {
        var SubjectNameValue = await _mediator.Send(new GetDropdownSubjectNameRequest
        {
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(SubjectNameValue);
    }


    [HttpGet]
    [Route("get-selectedSubjectNamesBySchoolAndCourseforAssignment")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSubjectNamesBySchoolAndCourseForAssignment(int baseSchoolNameId, int courseNameId)
    {
        var subjectName = await _mediator.Send(new GetSelectedSubjectNamesBySchoolAndCourseForAssignmentRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(subjectName);
    }


    [HttpGet]
    [Route("get-subjectlistBySchoolAndCourse")]
    public async Task<ActionResult> GetSubjectListBySchoolAndCourse(int baseSchoolNameId, int courseNameId, int courseDurationId, int courseWeekId, int courseSectionId)
    {
        var SubjectNameValue = await _mediator.Send(new GetSubjectListBySchoolAndCourseRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            CourseWeekId = courseWeekId,
            CourseSectionId = courseSectionId
        });
        return Ok(SubjectNameValue);
    }

    [HttpGet]
    [Route("get-subjectsByRoutineList")]
    public async Task<ActionResult> GetSubjectsByRoutineList(int baseSchoolNameId, int courseNameId, int courseDurationId, int courseWeekId, int courseSectionId)
    {
        var SubjectNameValue = await _mediator.Send(new GetSubjectsByRoutineListRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            CourseWeekId = courseWeekId,
            CourseSectionId = courseSectionId
        }); 
        return Ok(SubjectNameValue);
    }
      

    [HttpGet]
    [Route("get-selectedSubjectNamesByParameters")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSubjectNameByParameters(int baseSchoolNameId, int courseNameId, int courseModuleId)
    {
        var SubjectNameValue = await _mediator.Send(new GetSelectedSubjectNameByParametersRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseModuleId = courseModuleId,
        });
        return Ok(SubjectNameValue);
    }

    [HttpGet]
    [Route("get-instructorSubjectsByParameters")]
    public async Task<ActionResult<List<SelectedModel>>> GetInstructorSubjectsByParameters(int baseSchoolNameId, int courseNameId, int courseDurationId, int bnaSubjectNameId)
    {
        var SubjectNameValue = await _mediator.Send(new GetInstructorSubjectByParameterFromSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,    
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(SubjectNameValue);
    }



    [HttpGet]
    [Route("get-subjectInstructorListByCourseDuration")]
    public async Task<ActionResult> GetSubjectInstructorListByCourseDuration(int courseDurationId)
    {
        var SubjectNameValue = await _mediator.Send(new GetSubjectInstructorListByCourseDurationFromSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(SubjectNameValue);
    }

    [HttpGet]
    [Route("get-celectedCourseByParameters")]
    public async Task<ActionResult<List<BnaSubjectNameDto>>> GetSelectedCourseByParametersRequest(int baseSchoolNameId, int courseNameId, int courseModuleId, int status)
    {
        var bnaSubjectNames = await _mediator.Send(new GetSelectedCourseByParametersRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseModuleId = courseModuleId,
            Status = status
        });
        return Ok(bnaSubjectNames);
    }

    [HttpGet]
    [Route("get-selectedSubjectNameByParametersFromRoutineTable")]
    public async Task<ActionResult<List<BnaSubjectNameDto>>> GetSelectedSubjectNameByParametersFromClassRoutineRequest(int baseSchoolNameId, int courseNameId,int courseDurationId,int courseSectionId)
    {
        var bnaSubjectNames = await _mediator.Send(new GetSelectedSubjectNameByParametersFromClassRoutineRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId =courseDurationId,
            CourseSectionId = courseSectionId
        });
        return Ok(bnaSubjectNames);
    }
    [HttpGet]
    [Route("get-selectedSubjectNameByParametersFromRoutineTableForReExam")]
    public async Task<ActionResult<List<BnaSubjectNameDto>>> GetSelectedSubjectNameByParametersFromClassRoutineForReExamRequest(int baseSchoolNameId, int courseNameId,int courseDurationId,int courseSectionId, int examStatus)
    {
        var bnaSubjectNames = await _mediator.Send(new GetSelectedSubjectNameByParametersFromClassRoutineForReExamRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId =courseDurationId,
            CourseSectionId = courseSectionId,
            ExamStatus = examStatus
        });
        return Ok(bnaSubjectNames);
    }

    [HttpGet]
    [Route("get-selectedSubjectNameByParametersFromAttendanceTableForExam")]
    public async Task<ActionResult<List<BnaSubjectNameDto>>> GetSelectedSubjectNameByParametersFromAttendanceTableForExamRequest(int baseSchoolNameId, int courseNameId,int courseDurationId,int courseSectionId, int examStatus)
    {
        var bnaSubjectNames = await _mediator.Send(new GetSelectedSubjectNameByParametersFromAttendanceTableForExamRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId =courseDurationId,
            CourseSectionId = courseSectionId,
            ExamStatus = Convert.ToBoolean(examStatus)
        });
        return Ok(bnaSubjectNames);
    }

    [HttpGet]
    [Route("get-approvedSubjectNameByParametersFromRoutineTable")]
    public async Task<ActionResult<List<BnaSubjectNameDto>>> GetApproveSubjectNameByParametersFromClassRoutineRequest(int baseSchoolNameId, int courseNameId,int courseDurationId)
    {
        var bnaSubjectNames = await _mediator.Send(new GetApproveSubjectNameByParametersFromClassRoutineRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId
        });
        return Ok(bnaSubjectNames);
    }

    [HttpGet]
    [Route("get-bnaSubjectPeriodfromprocedure")]

    public async Task<ActionResult> GetBnaSubjectPeriodFromProcedure(int baseSchoolNameId, int courseNameId, int bnaSubjectNameId)
    {
        var proceduredCourses = await _mediator.Send(new GetBnaSubjectNameByParameterFromSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-totalmarkAndPassMarkFromprocedure")]

    public async Task<ActionResult> GetTotalmarkAndPassMarkFromprocedure(int baseSchoolNameId, int courseNameId,int bnaSubjectNameId)
    {
        var proceduredCourses = await _mediator.Send(new GetTotalMarkAndPassMarkFromSubjectSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-selectedSubjectBySchoolAndCourse")]
    public async Task<ActionResult<List<BnaSubjectNameDto>>> GetSelectedSubjectBySchoolAndCourseRequest(int baseSchoolNameId, int courseNameId)
    {
        var bnaSubjectNames = await _mediator.Send(new GetSelectedSubjectBySchoolAndCourseRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(bnaSubjectNames);
    }
    [HttpGet]
    [Route("get-selectedSubjectNameByFromCourseNameIdAndBranchId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAllowanceNameByFromRankIdAndToRankId(int courseNameId, int branchId)
    {
        var allowancNameValue = await _mediator.Send(new GetSubjectNameListByFromCourseNameIdAndBranchIdRequest
        {
            CourseNameId = courseNameId,
            BranchId = branchId,
        });
        return Ok(allowancNameValue);
    }

    [HttpGet]
    [Route("get-bnaSubjectListForStudentDashboard")]

    public async Task<ActionResult> GetBnaSubjectListForStudentDashboard(int baseSchoolNameId, int courseNameId, int courseModuleId)
    {
        var proceduredCourses = await _mediator.Send(new GetBnaSubjectNameByParameterForStudentDashboardFromSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseModuleId = courseModuleId
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-moduleForRoutine")]

    public async Task<ActionResult> GetModuleForRoutine(int baseSchoolNameId, int courseNameId, int bnaSubjectNameId)
    {
        var module = await _mediator.Send(new GetModuleForRoutineRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(module);
    }
    [HttpGet]
    [Route("get-selectedSubjectNameBySchoolNameIdAndCourseNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSubjectNameBySchoolNameIdAndCourseNameId(int baseSchoolNameId,int courseNameId)
    {
        var countryByCountryGroup = await _mediator.Send(new GetSubjectNameBySchoolNameIdAndCourseNameIdRequest
        { 
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId= courseNameId
        });
        return Ok(countryByCountryGroup);
    }

    [HttpGet]
    [Route("get-subjectNameListForInstructorDashboardDropdown")]
    public async Task<ActionResult> GetSubjectNameListForInstructorDashboardDropdown(int traineeId, int baseSchoolNameId,int courseDurationId)
    {
        var proceduredSubject = await _mediator.Send(new GetSelectedSubjectNameListForInstructorFromSpRequest
        {
            TraineeId = traineeId,
            BaseSchoolNameId = baseSchoolNameId,
            CourseDurationId = courseDurationId
        });
        return Ok(proceduredSubject);
    }

    [HttpGet]
    [Route("get-subjectListBySaylorBranch")]
    public async Task<ActionResult> GetSubjectListBySaylorBranch(int courseNameId, int SaylorBranchId,int saylorSubBranchId)
    {
        var proceduredSubject = await _mediator.Send(new GetJcoSubjectListBySaylorBranchSpRequest
        {
            CourseNameId = courseNameId,
            SaylorBranchId = SaylorBranchId,
            SaylorSubBranchId = saylorSubBranchId
        });
        return Ok(proceduredSubject);
    }

    [HttpGet]
    [Route("get-jcoResultBysubject")]
    public async Task<ActionResult> GetJcoExamResultBySubject(int courseDurationId, int bnaSubjectNameId,int resultStatus)
    {
        var proceduredSubject = await _mediator.Send(new GetJcoExamResultBySubjectSpRequest
        {
            CourseDurationId = courseDurationId,
            BnaSubjectNameId = bnaSubjectNameId,
            ResultStatus = resultStatus
        });
        return Ok(proceduredSubject);
    }

    [HttpGet]
    [Route("get-bnaSubjectNameListByBranchId")]
    public async Task<ActionResult<List<BnaSubjectNameDto>>> GetBNASubjectNameListByBranchId(int branchId,int courseNameId)
    {
        var subjectName = await _mediator.Send(new GetBNASubjectNameListByBranchIdRequest
        {
            BranchId = branchId,
            CourseNameId = courseNameId
        });
        return Ok(subjectName);

    }
    [HttpGet]
    [Route("get-bnaSubjectNameListByCourseNameId")]
    public async Task<ActionResult<List<BnaSubjectNameDto>>> GetBNASubjectNameListByCourseNameId()
    {
        var subjectName = await _mediator.Send(new GetBNASubjectNameListByCourseNameIdRequest
        {
            //CourseNameId = courseNameId
        });
        return Ok(subjectName);

    }

    [HttpGet]
    [Route("get-selectedSubjectNameByCourseNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSubjectNameByCourseNameId(int courseNameId)
    {
        var selectedSubjectName = await _mediator.Send(new GetSubjectNameByCourseNameIdRequest
        {
            CourseNameId = courseNameId
        });
        return Ok(selectedSubjectName);
    }

    [HttpGet]
    [Route("get-bnaSubjectNameListByCourseNameInQExamId")]
    public async Task<ActionResult<List<BnaSubjectNameDto>>> GetBNASubjectNameListByCourseNameInQExamId()
    {
        var subjectName = await _mediator.Send(new GetBNASubjectNameListByCourseNameInQExamIdRequest
        {
            //CourseNameId = courseNameId
        });
        return Ok(subjectName);
    }

    [HttpGet]
    [Route("get-totalmarkAndPassMarkByCourseNameIdAndBnaSubjectNameId")]
    public async Task<ActionResult> GetTotalmarkAndPassMarkByCourseNameIdAndBnaSubjectNameId(int courseNameId, int bnaSubjectNameId)
    {
        var proceduredCourses = await _mediator.Send(new GetTotalMarkAndPassMarkFromSubjectByCourseNameIdSubjectNameIdSpRequest
        {
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-bnaSubjectNameListByBranchIdForJCOs")]
    public async Task<ActionResult<List<BnaSubjectNameDto>>> GetBNASubjectNameListByBranchIdForJCOs(int saylorBranchId, int courseNameId)
    {
        var subjectName = await _mediator.Send(new GetBNASubjectNameListByBranchIdForJCOsRequest
        {
            SaylorBranchId = saylorBranchId,
            CourseNameId = courseNameId
        });
        return Ok(subjectName);

    }
    [HttpGet]
    [Route("get-bnaSubjectNameListForJCOsByCourseNameId")]
    
    public async Task<ActionResult> GetBNASubjectNameListForJCOsByCourseNameId(int courseDurationId)
    {
        var SubjectNameValue = await _mediator.Send(new GetBNASubjectNameListForJCOsByCourseNameIdRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(SubjectNameValue);
    }

    [HttpGet]
    [Route("get-selectedSubjectNameByBranchId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSubjectNameByBranchId(int branchId)
    {
        var subjectNames = await _mediator.Send(new GetSubjectNameByBranchIdRequest { BranchId = branchId });
        return Ok(subjectNames);
    }
    [HttpGet]
    [Route("get-selectedSubjectNameBySailorSubBranchId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSubjectNameBySailorSubBranchId(int saylorSubBranchId)
    {
        var subjectNames = await _mediator.Send(new GetSubjectNameBySailorSubBranchIdRequest { SaylorSubBranchId = saylorSubBranchId });
        return Ok(subjectNames);
    }

    [HttpGet]
    [Route("get-selectedSubjectNameForAssignments")] 
    public async Task<ActionResult> GetSelectedSubjectNameForAssignments(int baseSchoolNameId, int courseNameId)
    {
        var subjectMark = await _mediator.Send(new GetSelectedSubjectNameForAssignmentSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(subjectMark);
    }

    [HttpGet]
    [Route("get-bnaSubjectNameListByBnaSemesterId")]
    public async Task<ActionResult<List<BnaSubjectNameDto>>> GetBNASubjectNameListByBnaSemesterId(int bnaSemesterId)
    {
        var subjectName = await _mediator.Send(new GetBNASubjectNameListByBnaSemesterIdRequest
        {
            BnaSemesterId = bnaSemesterId
        });
        return Ok(subjectName);

    }

    [HttpGet]
    [Route("get-selectedSubjectByBnaSemesterId")]
    public async Task<ActionResult<List<BnaSubjectNameDto>>> GetSelectedSubjectByBnaSemesterIdRequest(int bnaSemesterId, int bnaSubjectCurriculumId)
    {
        var bnaSubjectNames = await _mediator.Send(new GetSelectedSubjectByBnaSemesterIdRequest
        {
            BnaSemesterId = bnaSemesterId,
            BnaSubjectCurriculumId=bnaSubjectCurriculumId
        });
        return Ok(bnaSubjectNames);
    }
    [HttpGet]
    [Route("get-selectedSubjectByBnaSemesterIdAndSubjectCurriculumId")]
    public async Task<ActionResult<List<BnaSubjectNameDto>>> GetSelectedSubjectByBnaSemesterIdAndSubjectCurriculumIdRequest(int bnaSemesterId, int bnaSubjectCurriculumId)
    {
        var bnaSubjectNames = await _mediator.Send(new GetSelectedSubjectByBnaSemesterIdAndSubjectCurriculumIdRequest
        {
            BnaSemesterId = bnaSemesterId,
            BnaSubjectCurriculumId= bnaSubjectCurriculumId
        });
        return Ok(bnaSubjectNames);
    }
}

