using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaExamMark;
using SchoolManagement.Application.Features.BnaExamMarks.Requests.Commands;
using SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaExamMark)]
[ApiController]
[Authorize]
public class BnaExamMarkController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaExamMarkController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaExamMarks")]
    public async Task<ActionResult<List<BnaExamMarkDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaExamMarks = await _mediator.Send(new GetBnaExamMarkListRequest { QueryParams = queryParams });
        return Ok(BnaExamMarks);
    }

    [HttpGet]
    [Route("get-bnaExamMarkDetail/{id}")]
    public async Task<ActionResult<BnaExamMarkDto>> Get(int id)
    {
        var BnaExamMark = await _mediator.Send(new GetBnaExamMarkDetailRequest { BnaExamMarkId = id });
        return Ok(BnaExamMark);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaExamMark")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaExamMarkDto BnaExamMark)
    {
        var command = new CreateBnaExamMarkCommand { BnaExamMarkDto = BnaExamMark };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaExamMarklist")]

    public async Task<ActionResult<BaseCommandResponse>> SaveBnaExamMarklist([FromBody] BnaExamMarkListDto bnaExamMark)
    {
        var command = new CreateBnaExamMarkListCommand { BnaExamMarkListDto = bnaExamMark };
        var response = await _mediator.Send(command);
        return Ok(response);
        //return Ok();
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("approve-bnaExamMarklist")]

    public async Task<ActionResult<BaseCommandResponse>> ApproveBnaExamMarklist([FromBody] ApproveBnaExamMarkListDto bnaExamMark)
    {
        var command = new ApproveBnaExamMarkListCommand { ApproveBnaExamMarkListDto = bnaExamMark };
        var response = await _mediator.Send(command);
        return Ok(response);
        //return Ok();
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("instructorApprove-bnaExamMarklist")]

    public async Task<ActionResult<BaseCommandResponse>> InstructorApproveBnaExamMarklist([FromBody] ApproveBnaExamMarkListDto bnaExamMark)
    {
        var command = new InstructorApproveBnaExamMarkListCommand { ApproveBnaExamMarkListDto = bnaExamMark };
        var response = await _mediator.Send(command);
        return Ok(response);
        //return Ok();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaExamMark/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaExamMarkDto BnaExamMark)
    {
        var command = new UpdateBnaExamMarkCommand { BnaExamMarkDto = BnaExamMark };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaExamMark/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaExamMarkCommand { BnaExamMarkId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-examMarkListByParameters")]
    public async Task<ActionResult<List<BnaExamMarkDto>>> GetExamMarkListByParametersRequest(int baseSchoolNameId, int courseNameId, int courseDurationId, int bnaSubjectNameId, int subjectMarkId, bool approveStatus)
    {
        var bnaExamMarks = await _mediator.Send(new GetExamMarkListByParametersRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            BnaSubjectNameId = bnaSubjectNameId,
            SubjectMarkId = subjectMarkId,
            ApproveStatus = approveStatus
        });
        return Ok(bnaExamMarks);
    }

    [HttpGet]
    [Route("get-examMarkFilteredListByParameters")]
    public async Task<ActionResult<List<BnaExamMarkDto>>> GetExamMarkFilteredListByParametersRequest(int baseSchoolNameId, int courseNameId, int courseDurationId, int bnaSubjectNameId, int subjectMarkId, bool approveStatus,int courseSectionId, int classRoutineId)
    {
        var bnaExamMarks = await _mediator.Send(new GetExamMarkFilterListByParametersRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId,
            CourseDurationId = courseDurationId,
            SubjectMarkId = subjectMarkId,
            ApproveStatus = approveStatus,
            CourseSectionId =courseSectionId,
            ClassRoutineId = classRoutineId
        });
        return Ok(bnaExamMarks);
    }

    [HttpGet]
    [Route("get-centralExamMarkListByParameters")]
    public async Task<ActionResult<List<BnaExamMarkDto>>> GetCentralExamMarkListByParametersRequest(int courseNameId, int bnaSubjectNameId, int subjectMarkId, bool approveStatus, int submissionStatus)
    {
        var bnaExamMarks = await _mediator.Send(new GetCentralExamMarkListByParametersRequest
        {
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId,
            SubjectMarkId = subjectMarkId,
            ApproveStatus = approveStatus,
            SubmissionStatus = submissionStatus
        });
        return Ok(bnaExamMarks);
    }

    [HttpGet]
    [Route("get-traineeMarkListByDuration")]

    public async Task<ActionResult> GetTraineeMarkListByDuration(int courseDurationId)
    {
        var traineeMarkList = await _mediator.Send(new GetTraineeMarkListByDurationSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(traineeMarkList);
    }

    [HttpGet]
    [Route("get-traineeMarkListByDurationForStuffClg")]

    public async Task<ActionResult> GetTraineeMarkListByDurationForStuffClg(int courseDurationId)
    {
        var traineeMarkList = await _mediator.Send(new GetTraineeMarkListByDurationForStuffClgSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(traineeMarkList);
    }

    [HttpGet]
    [Route("get-traineeMarkListByDurationForQexam")]

    public async Task<ActionResult> GetTraineeMarkListByDurationForQexam(int courseDurationId)
    {
        var traineeMarkList = await _mediator.Send(new GetTraineeMarkListByDurationForQexamSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(traineeMarkList);
    }

    [HttpGet]
    [Route("get-traineeMarkListByDurationForJco")]

    public async Task<ActionResult> GetTraineeMarkListByDurationForJco(int courseDurationId)
    {
        var traineeMarkList = await _mediator.Send(new GetTraineeMarkListByDurationForJcoSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(traineeMarkList);
    }

    [HttpGet]
    [Route("get-traineeMarkListByDurationandId")]

    public async Task<ActionResult> GetTraineeMarkListByDurationandId(int courseDurationId, int traineeId)
    {
        var traineeMarkListById = await _mediator.Send(new GetTraineeMarkListByDurationAndIdSpRequest
        {
            CourseDurationId = courseDurationId,
            TraineeId = traineeId
        });
        return Ok(traineeMarkListById);
    }

    [HttpGet]
    [Route("get-markSheetByTraineeAndDurationandId")]

    public async Task<ActionResult> GetMarkSheetByTraineeAndDurationandId(int courseDurationId, int traineeId)
    {
        var traineeMarkListById = await _mediator.Send(new GetMarkSheetByTraineeIdAndDurationSpRequest
        {
            CourseDurationId = courseDurationId,
            TraineeId = traineeId
        });
        return Ok(traineeMarkListById);
    }



    [HttpGet]
    [Route("get-schoolExamApproveList")]
    public async Task<ActionResult> GetschoolExamApproveListBySp(int baseSchoolNameId)
    {
        var proceduredCourses = await _mediator.Send(new GetSchoolExamApproveListSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(proceduredCourses);
    }


    [HttpGet]
    [Route("get-traineeMarkListByParameters")]
    public async Task<ActionResult> GetTraineeMarkListByParameter(int courseDurationId,int baseSchoolNameId, int traineeId)
    {
        var traineeMarkList = await _mediator.Send(new GetTraineeMarkListByParameterSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseDurationId = courseDurationId,
            TraineeId =traineeId
        }); 
        return Ok(traineeMarkList);
    }


    [HttpGet]
    [Route("get-traineePerformanceDetailsByParameters")]
    public async Task<ActionResult> GetTraineePerformanceDetailsByParameter(int courseDurationId,int baseSchoolNameId, int traineeId)
    {
        var traineeMarkList = await _mediator.Send(new GetTraineePerformanceDetailsByParameterSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseDurationId = courseDurationId,
            TraineeId =traineeId
        }); 
        return Ok(traineeMarkList);
    }


    [HttpGet]
    [Route("get-traineeCertificateDetailsByParameters")]
    public async Task<ActionResult> GetTraineeCertificateDetailsByParameter(int courseDurationId,int baseSchoolNameId, int traineeId)
    {
        var traineeMarkList = await _mediator.Send(new GetTraineeCertificateDetailsByParameterSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseDurationId = courseDurationId,
            TraineeId =traineeId
        }); 
        return Ok(traineeMarkList);
    }

    [HttpGet]
    [Route("get-exammarkListForValidation")]
    public async Task<ActionResult> GetExamMarkListForValidation(int baseSchoolNameId,int courseDurationId, int courseSectionId,int bnaSubjectNameId,int markTypeId)
    {
        var traineeMarkList = await _mediator.Send(new GetExamMarkListForValidationSpRequest
        {
            BaseSchoolNameId =baseSchoolNameId,
            CourseDurationId =courseDurationId,
            CourseSectionId =courseSectionId,
            BnasubjectNameId =bnaSubjectNameId,
            MarkTypeId =markTypeId,
        });
        return Ok(traineeMarkList);
    }
}

