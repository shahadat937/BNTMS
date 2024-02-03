using SchoolManagement.Api.Models;
using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SubjectMark;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Commands;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SubjectMark)]
[ApiController]
[Authorize]
public class SubjectMarkController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubjectMarkController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-subjectmarks")]
    public async Task<ActionResult<List<SubjectMarkDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var SubjectMarke = await _mediator.Send(new GetSubjectMarkListRequest { QueryParams = queryParams });
        return Ok(SubjectMarke);
    }

    [HttpGet]
    [Route("get-subjectmarkdetail/{id}")]
    public async Task<ActionResult<SubjectMarkDto>> Get(int id)
    {
        var SubjectMark = await _mediator.Send(new GetSubjectMarkDetailRequest { Id = id });
        return Ok(SubjectMark);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)] 
    [Route("save-subjectmark")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSubjectMarkDto SubjectMark)
    {
        var command = new CreateSubjectMarkCommand { SubjectMarkDto = SubjectMark };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-subjectmark/{id}")]
    public async Task<ActionResult> Put([FromBody] SubjectMarkDto SubjectMark)
    {
        var command = new UpdateSubjectMarkCommand { SubjectMarkDto = SubjectMark };
        await _mediator.Send(command);
        return NoContent(); 
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-subjectmark/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSubjectMarkCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-SelectedSubjectMarkByBaseSchoolCourseNameAndBnaSubjectNameId")]
    public async Task<ActionResult<List<SubjectMarkDto>>> SelectedSubjectMarkByBaseSchoolCourseNameAndBnaSubjectNameId(int baseSchoolNameId, int courseNameId, int bnaSubjectNameId) 
    {
        var bnaSubjectNames = await _mediator.Send(new GetSelectedSubjectMarkByBaseNameIdCourseIdAndSubjectIdRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId,
        });
        return Ok(bnaSubjectNames);
    }

    [HttpGet]
    [Route("get-selectedSubjectMarkByParameters")]
    public async Task<ActionResult<List<SubjectMarkDto>>> GetSelectedSubjectMarkByParametersRequest(int baseSchoolNameId, int courseNameId, int courseModuleId, int bnaSubjectNameId)
    {
        var subjectMarks = await _mediator.Send(new GetSelectedSubjectMarkByParametersRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseModuleId = courseModuleId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(subjectMarks);
    }

    [HttpGet]
    [Route("get-selectedSubjectMarkBySubject")]
    public async Task<ActionResult<List<SubjectMarkDto>>> GetSelectedSubjectMarkBySubjectRequest(int baseSchoolNameId, int courseNameId, int bnaSubjectNameId)
    {
        var subjectMarks = await _mediator.Send(new GetSelectedSubjectMarkBySubjectRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(subjectMarks);
    }

    [HttpGet]
    [Route("get-selectedMarkTypeByParametersFromSubjectMark")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedMarkTypeByParametersFromSubjectMark(int baseSchoolNameId, int courseNameId, int courseDurationId, int bnaSubjectNameId, int courseModuleId)
    {
        var SubjectMarkValue = await _mediator.Send(new GetSelectedMarkTypeByParametersFromSubjectMarkRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            BnaSubjectNameId = bnaSubjectNameId,
            CourseModuleId = courseModuleId,
        });
        return Ok(SubjectMarkValue);
    }

    [HttpGet]
    [Route("get-approvedMarkTypeByParametersFromSubjectMark")]
    public async Task<ActionResult<List<SelectedModel>>> GetApproveMarkTypeByParametersFromSubjectMark(int baseSchoolNameId, int courseNameId, int courseDurationId, int bnaSubjectNameId, int courseModuleId, bool isApproved)
    {
        var SubjectMarkValue = await _mediator.Send(new GetApproveMarkTypeByParametersFromSubjectMarkRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            BnaSubjectNameId = bnaSubjectNameId,
            CourseModuleId = courseModuleId,
            IsApproved = isApproved
        });
        return Ok(SubjectMarkValue);
    }

    [HttpGet]
    [Route("get-approvedMarkTypeByParametersForCentralExam")]
    public async Task<ActionResult<List<SelectedModel>>> GetApproveMarkTypeByParametersForCentralExam(int courseNameId, int courseDurationId, int bnaSubjectNameId, bool isApproved)
    {
        var SubjectMarkValue = await _mediator.Send(new GetApproveMarkTypeByParametersForCentralExamRequest
        {
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            BnaSubjectNameId = bnaSubjectNameId,
            IsApproved = isApproved
        });
        return Ok(SubjectMarkValue);
    }

    [HttpGet]
    [Route("get-selectedSubjectMarkByCourseNameIdAndBnaSubjectNameId")]
    public async Task<ActionResult<List<SubjectMarkDto>>> GetSelectedSubjectMarkByCourseNameIdAndBnaSubjectNameId(int courseNameId,int bnaSubjectNameId)
    {
        var subjectMarks = await _mediator.Send(new GetSelectedSubjectMarkListByCourseNameIdAndSubjectNameIdRequest
        {
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(subjectMarks);
    }

    [HttpGet]
    [Route("get-selectedSubjectMarkByCourseNameIdSubjectNameId")]
    public async Task<ActionResult<List<SubjectMarkDto>>> SelectedSubjectMarkByCourseNameIdSubjectNameId(int courseNameId, int bnaSubjectNameId)
    {
        var bnaSubjectNames = await _mediator.Send(new GetSelectedSubjectMarkByCourseNameIdSubjectNameIdRequest
        {
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId,
        });
        return Ok(bnaSubjectNames);
    }

    [HttpGet] 
    [Route("get-selectedMarkTypeByCourseNameIdAndSubjectNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedMarkTypeByCourseNameIdAndSubjectNameId(int courseNameId, int courseDurationId, int bnaSubjectNameId)
    {
        var SubjectMarkValue = await _mediator.Send(new GetSelectedMarkTypeByCourseNameIdAndSubjectNameIdRequest
        {
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            BnaSubjectNameId = bnaSubjectNameId,
        });
        return Ok(SubjectMarkValue);
    }

    [HttpGet] 
    [Route("get-selectedMarkTypeBySubjectNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedMarkTypeBySubjectNameId(int bnaSubjectNameId)
    {
        var SubjectMarkValue = await _mediator.Send(new GetSelectedMarkTypeBySubjectNameIdRequest
        {
            BnaSubjectNameId = bnaSubjectNameId,
        });
        return Ok(SubjectMarkValue);
    }

    [HttpGet]
    [Route("get-selectedSubjectMarkForassignmens")]
    public async Task<ActionResult> GetSelectedSubjectMarkForAssignments(int courseNameId,int baseSchoolNameId, int bnaSubjectNameId)
    {
        var subjectMark = await _mediator.Send(new GetSelectedSubjectMarkForAssignmentsSpRequest
        {
            CourseNameId = courseNameId,
            BaseSchoolNameId = baseSchoolNameId,
            BnaSubjectNameId =bnaSubjectNameId
        });
        return Ok(subjectMark);
    }
    [HttpGet]
    [Route("get-selectedSubjectMarkByBnaSemester")]
    public async Task<ActionResult<List<SubjectMarkDto>>> GetSelectedSubjectMarkByBnaSemesterRequest(int baseSchoolNameId, int courseNameId, int bnaSemesterId, int bnaSubjectNameId)
    {
        var subjectMarks = await _mediator.Send(new GetSelectedSubjectMarkByBnaSemesterRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            BnaSemesterId = bnaSemesterId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(subjectMarks);
    }
    [HttpGet]
    [Route("get-selectedMarkTypeForBnaBySubjectNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedMarkTypeForBnaBySubjectNameId(int bnaSubjectNameId)
    {
        var SubjectMarkValue = await _mediator.Send(new GetSelectedMarkTypeForBnaBySubjectNameIdRequest
        {
            BnaSubjectNameId = bnaSubjectNameId,
        });
        return Ok(SubjectMarkValue);
    }
}

