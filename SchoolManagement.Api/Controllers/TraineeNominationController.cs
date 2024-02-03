using SchoolManagement.Api.Models;
using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ReadingMaterial;
using SchoolManagement.Application.DTOs.TraineeNomination;
using SchoolManagement.Application.Features.ReadingMaterials.Requests.Commands;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Commands;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TraineeNomination)]
[ApiController]
[Authorize]
public class TraineeNominationController : ControllerBase
{
    private readonly IMediator _mediator;

    public TraineeNominationController(IMediator mediator)
    {
        _mediator = mediator;
    }



    [HttpGet]
    [Route("get-traineeNominations")]
    public async Task<ActionResult<List<TraineeNominationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TraineeNominations = await _mediator.Send(new GetTraineeNominationListRequest { QueryParams = queryParams });
        return Ok(TraineeNominations);
    }

    [HttpGet]
    [Route("get-traineeNominationDetail/{id}")]
    public async Task<ActionResult<TraineeNominationDto>> Get(int id)
    {
        var TraineeNomination = await _mediator.Send(new GetTraineeNominationDetailRequest { TraineeNominationId = id });
        return Ok(TraineeNomination);
    }

    [HttpGet]
    [Route("get-selectedTraineeByCourseDurationId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedTraineeByCourseDurationId(int courseDurationId)
    {
        var selectedTrainee = await _mediator.Send(new GetSelectedTraineeNominationByCourseDurationIdRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(selectedTrainee);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-traineeNomination")]   
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTraineeNominationDto TraineeNomination)
    {
        var command = new CreateTraineeNominationCommand { TraineeNominationDto = TraineeNomination };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("update-traineeNominationList")]

    public async Task<ActionResult<BaseCommandResponse>> UpdateTraineeNominationList([FromBody] TraineeNominationList nomination)
    {
        var command = new UpdateTraineeNominationListCommand { TraineeNominationListDto = nomination };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("update-traineeNominationList-Forreligation")]

    public async Task<ActionResult<BaseCommandResponse>> UpdateTraineeNominationListForReligation([FromBody] TraineeNominationListForReligation nomination)
    {
        var command = new UpdateTraineeNominationListForReligationCommand { TraineeNominationList = nomination };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-traineereligation/{id}")]
    public async Task<ActionResult> UpdateReligation([FromForm] TraineeReligationDto traineeReligation)
    {
        var command = new UpdateNominationCommand { TraineeReligationDto = traineeReligation };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-traineeNomination/{id}")]
    public async Task<ActionResult> Put([FromBody] TraineeNominationDto TraineeNomination)
    {
        var command = new UpdateTraineeNominationCommand { TraineeNominationDto = TraineeNomination };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-traineeNomination/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTraineeNominationCommand { TraineeNominationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-traineeNominationDetailByCourseDurationId")]
    public async Task<ActionResult<TraineeNominationDto>> GetTraineeNominationDetailsByCourseDuration(int courseDurationId)
    {
        var TraineeNomination = await _mediator.Send(new GetTraineeNominationDetailByCourseDurationIdRequest
        {
            CourseDurationId = courseDurationId
        });

        return Ok(TraineeNomination);
    }

    [HttpGet]
    [Route("get-traineeNominationsByCourseDurationId")]
    public async Task<ActionResult<List<TraineeNominationDto>>> Get([FromQuery] QueryParams queryParams, int courseDurationId)
    {
        var TraineeNominations = await _mediator.Send(new GetTraineeNominationListByCourseDurationIdRequest
        {
            QueryParams = queryParams,
            CourseDurationId = courseDurationId
        });
        return Ok(TraineeNominations);
    }

    [HttpGet]
    [Route("get-traineeNominationsForForeignCourseOtherDocByCourseDurationId")]
    public async Task<ActionResult<List<TraineeNominationDto>>> GetTraineeNominationsForForeignCourseOtherDocByCourseDurationId(int courseDurationId)
    {
        var traineeNominations = await _mediator.Send(new GetTraineeNominationsForForeignCourseOtherDocByCourseDurationIdRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(traineeNominations);

    }
    [HttpGet]
    [Route("get-traineeNominationsForForeignCourseOtherDocByCourseDurationIdandCourseNameId")]
    public async Task<ActionResult<List<TraineeNominationDto>>> GetTraineeNominationsForForeignCourseOtherDocByCourseDurationIdAndCourseNameId(int courseDurationId, int courseNameId)
    {
        var traineeNominations = await _mediator.Send(new GetForeignCourseOtherDocByCourseDurationIdAndCourseNameIdRequest
        {
            CourseDurationId = courseDurationId,
            CourseNameId = courseNameId
        });
        return Ok(traineeNominations);
    }


    [HttpGet]
    [Route("get-traineeNominationsForAttendanceByCourseDurationId")]
    public async Task<ActionResult<List<TraineeNominationDto>>> GetTraineeNominationListForAttendanceByCourseDurationId(int courseDurationId, int courseSectionId)
    {
        var traineeNominations = await _mediator.Send(new GetTraineeNominationListForAttendanceByCourseDurationIdRequest
        {
            CourseDurationId = courseDurationId,
            CourseSectionId = courseSectionId
        });
        return Ok(traineeNominations);
    }

    [HttpGet]
    [Route("get-traineeNominationsListForAssessmentByCourseDurationIdAndTraineeId")]
    public async Task<ActionResult<List<TraineeNominationDto>>> GetTraineeNominationsListForAssessmentByCourseDurationIdAndTraineeId(int courseDurationId)
    {
        var traineeNominations = await _mediator.Send(new GetTraineeNominationsListForAssessmentByCourseDurationIdAndTraineeIdRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(traineeNominations);
    }


    [HttpGet]
    [Route("get-traineeNominationsForJcoExamByBranch")]
    public async Task<ActionResult<List<TraineeNominationDto>>> GetTraineeNominationListNominationsForJcoExamByBranch(int courseDurationId, int saylorBranchId, int saylorSubBranchId)
    {
        var traineeNominations = await _mediator.Send(new GetTraineeNominationListNominationsForJcoExamByBranchRequest
        {
            CourseDurationId = courseDurationId,
            SaylorBranchId = saylorBranchId,
            SaylorSubBranchId = saylorSubBranchId

        });
        return Ok(traineeNominations);
    }

    [HttpGet]
    [Route("get-traineeNominationListForInterServiceByCourseDurationId")]
    public async Task<ActionResult<List<TraineeNominationDto>>> GetTraineeNominationListForInterServiceByCourseDurationId(int courseDurationId)
    {
        var TraineeNominations = await _mediator.Send(new GetTraineeNominationListForInterServiceByCourseDurationIdRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(TraineeNominations);
    }

    [HttpGet]
    [Route("get-selectedTraineeNominationCount")]
    public async Task<int> CourseDurationIdByBaseSchoolNameAndCourseName(int traineeId, int courseNameId)
    {
        var nominationCount = await _mediator.Send(new GetTraineeNominationCountByCourseNameIdAndTraineeIdRequest
        {
            TraineeId = traineeId,
            CourseNameId = courseNameId
        });
        return nominationCount;
    }

    [HttpGet]
    [Route("get-nominatedTraineeForProfileUpdatespRequest")]
    public async Task<ActionResult> GetNominatedTraineeForProfileUpdatespRequest(int baseSchoolNameId, string searchText)
    {
        var trainee = await _mediator.Send(new GetNominatedTraineeForProfileUpdateSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            SearchText = searchText
        });
        return Ok(trainee);
    }

    [HttpGet]
    [Route("get-traineeNominationListByCourseDurationIdspRequest")]
    public async Task<ActionResult> GetTraineeNominationListByCourseDurationIdSpRequest(int courseDurationId)
    {
        var trainee = await _mediator.Send(new GetTraineeNominationListByCourseDurationIdSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(trainee);
    }

    [HttpGet]
    [Route("get-traineeNominationListByTypeCourseDurationIdspRequest")]
    public async Task<ActionResult> GetTraineeNominationListByTypeCourseDurationIdSpRequest(int courseDurationId)
    {
        var trainee = await _mediator.Send(new GetTraineeNominationListByTypeAndCourseDurationIdSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(trainee);
    }

    [HttpGet]
    [Route("get-traineeAttendanceByCourseDurationIdSpRequest")]
    public async Task<ActionResult> GetTraineeAttendanceByCourseDurationIdSpRequest(int traineeId,int courseDurationId)
    {
        var trainee = await _mediator.Send(new GetTraineeAttendanceByCourseDurationIdSpRequest
        {
            TraineeId = traineeId,
            CourseDurationId = courseDurationId
        });
        return Ok(trainee);
    }

    [HttpGet]
    [Route("get-traineeattendanceListByCourseDurationIdspRequest")]
    public async Task<ActionResult> GetTraineeAttendanceListByCourseDurationIdSpRequest(int baseSchoolNameId,int courseNameId,int courseDurationId,int subjectNameId,int courseSectionId,int classRoutineId, int attendanceStatus)
    {
        var trainee = await _mediator.Send(new GetTraineeAttendanceListByCourseDurationIdSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            BnaSubjectNameId = subjectNameId,
            CourseSectionId = courseSectionId,
            ClassRoutineId = classRoutineId,
            AttendanceStatus =attendanceStatus
        });
        return Ok(trainee);
    }

    [HttpGet]
    [Route("get-traineeattendanceListForReExamSpRequest")]
    public async Task<ActionResult> GetTraineeAttendanceListForReExamSpRequest(int baseSchoolNameId,int courseNameId,int courseDurationId,int subjectNameId,int courseSectionId,int classRoutineId, int attendanceStatus)
    {
        var trainee = await _mediator.Send(new GetTraineeAttendanceListForReExamSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            BnaSubjectNameId = subjectNameId,
            CourseSectionId = courseSectionId,
            ClassRoutineId = classRoutineId,
            AttendanceStatus =attendanceStatus
        });
        return Ok(trainee);
    }

    [HttpGet]
    [Route("get-traineeListForAssignmentsSpRequest")]
    public async Task<ActionResult> GetTraineeListForAssignmentsSpRequest(int courseDurationId, int courseNameId,int courseSectionId)
    {
        var trainee = await _mediator.Send(new GetTraineeListForAssignmentSpRequest
        {
            CourseDurationId = courseDurationId,
            CourseNameId = courseNameId,
            CourseSectionId = courseSectionId,
        });
        return Ok(trainee);
    }

    [HttpGet]
    [Route("get-traineeNominationListByCourseDurationIdForNbcdspRequest")]
    public async Task<ActionResult> GetTraineeNominationListByCourseDurationIdNbcdSpRequest(int courseDurationId)
    {
        var trainee = await _mediator.Send(new GetTraineeNominationListByCourseDurationIdForNbcdSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(trainee);
    }
    [HttpGet]
    [Route("get-traineeNominationsByBnaSemesterDurationId")]
    public async Task<ActionResult<List<TraineeNominationDto>>> GetTraineeNominationListByBnaSemesterDuration([FromQuery] QueryParams queryParams, int bnaSemesterDurationId)
    {
        var TraineeNominations = await _mediator.Send(new GetTraineeNominationListByBnaSemesterDurationIdRequest
        {
            QueryParams = queryParams,
            BnaSemesterDurationId = bnaSemesterDurationId
        });
        return Ok(TraineeNominations);
    }
    [HttpGet]
    [Route("get-traineeNominationListForBnaByBnaSemesterDurationIdspRequest")]
    public async Task<ActionResult> GetTraineeNominationListForBnaByBnaSemesterDurationIdSpRequest(int bnaSemesterDurationId)
    {
        var trainee = await _mediator.Send(new GetTraineeNominationListForBnaByBnaSemesterDurationIdSpRequest
        {
            BnaSemesterDurationId = bnaSemesterDurationId
        });
        return Ok(trainee);
    }
}


 