using Microsoft.Data.SqlClient;
using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Features.CourseDurations.Requests.Commands;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CourseDurations)]
[ApiController]
[Authorize]
public class CourseDurationController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseDurationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-courseDurations")]
    public async Task<ActionResult<List<CourseDurationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CourseDurations = await _mediator.Send(new GetCourseDurationListRequest { QueryParams = queryParams });
        return Ok(CourseDurations);
    }

    

    [HttpGet]
    [Route("get-courseDurationDetail/{id}")]
    public async Task<ActionResult<CourseDurationDto>> Get(int id)
    {
        var CourseDuration = await _mediator.Send(new GetCourseDurationDetailRequest { CourseDurationId = id });
        return Ok(CourseDuration);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-courseDuration")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseDurationDto CourseDuration)
    {
        var command = new CreateCourseDurationCommand { CourseDurationDto = CourseDuration };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
     
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-courseDuration-fornbcd")]
    public async Task<ActionResult<BaseCommandResponse>> SaveCourseDurationForNbcd([FromBody] CreateCourseDurationDto CourseDuration,int baseSchoolNameId)
    {
        var command = new CreateCourseDurationForNbcdCommand
        { 
            CourseDurationDto = CourseDuration,
            BaseSchoolNameId = baseSchoolNameId
        };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-courseDuration/{id}")]
    public async Task<ActionResult> Put([FromBody] CourseDurationDto CourseDuration)
    {
        var command = new UpdateCourseDurationCommand { CourseDurationDto = CourseDuration };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-nbcdCourseDuration/{id}")] 
    public async Task<ActionResult> UpdateNbcdCourseDuration([FromBody] UpdateNbcdCourseDurationDto CourseDuration)
    {
        var command = new UpdateNbcdCourseDurationCommand { CourseDurationDto = CourseDuration };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-courseDuration/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCourseDurationCommand { CourseDurationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedCourseDurationBySchoolName")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedcoursedurationbyschoolname(int baseSchoolNameId)
    {
        var selectedCourseDuration = await _mediator.Send(new GetSelectedCourseDurationBySchoolNameRequest { BaseSchoolNameId = baseSchoolNameId });
        return Ok(selectedCourseDuration);
    }

    [HttpGet]
    [Route("get-courseDurationsForMist")]
    public async Task<ActionResult<List<CourseDurationDto>>> GetCourseDurationForMist([FromQuery] QueryParams queryParams)
    {
        var CourseDurations = await _mediator.Send(new GetCourseDurationListForMistRequest { QueryParams = queryParams });
        return Ok(CourseDurations);
    }

    [HttpGet]
    [Route("get-selectedCourseForRoutine")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedcoursedurationforeoutine(int baseSchoolNameId)
    {
        var selectedCourseDuration = await _mediator.Send(new GetSelectedCourseDurationForRoutineCopyRequest { BaseSchoolNameId = baseSchoolNameId });
        return Ok(selectedCourseDuration);
    }


    [HttpGet]
    [Route("get-selectedCourseDurationByCourseTypeId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseDurationByCourseType(int courseTypeId)
    {
        var selectedCourseDuration = await _mediator.Send(new GetSelectedCourseDurationByCourseTypeIdRequest { CourseTypeId = courseTypeId });
        return Ok(selectedCourseDuration);
    }

    //new  

    [HttpGet]
    [Route("get-courseDurationByBaseSchool")]
    public async Task<ActionResult<List<SelectedModel>>> GetDataByBaseSchoolNameId(int baseSchoolNameId)
    {
        var courseDurations = await _mediator.Send(new GetCourseDurationByBaseSchoolNameIdRequest { BaseSchoolNameId = baseSchoolNameId });
        return Ok(courseDurations);
    }


    [HttpGet]
    [Route("get-courseDurationListBySchoolId")]
    public async Task<ActionResult<List<CourseDurationDto>>> GetCourseDurationListByBaseSchoolNameId(int baseSchoolNameId)
    {
        var courseDurations = await _mediator.Send(new GetCourseDurationListByBaseSchoolNameIdRequest { BaseSchoolNameId = baseSchoolNameId });
        return Ok(courseDurations);
    }

    [HttpGet]
    [Route("get-courseDurationByCourseType")]
    public async Task<ActionResult<List<CourseDurationDto>>> GetCourseDurationByCourseType([FromQuery] QueryParams queryParams, int courseTypeId)
    {
        var localCourses = await _mediator.Send(new GetCourseDurationByCourseTypeIdRequest 
        {
            CourseTypeId  = courseTypeId,
            QueryParams = queryParams
        });
        return Ok(localCourses); 
    }


    [HttpGet]
    [Route("get-courseDurationByCourseTypeFilter")]
    public async Task<ActionResult> GetCourseDurationByCourseTypeFilter(int viewStatus, int courseTypeId)
    {
        var localCourses = await _mediator.Send(new GetCourseDurationByCourseTypeIdFilterRequest
        {
            CourseTypeId = courseTypeId,
            ViewStatus =viewStatus
        });
        
        return Ok(localCourses);
    }


    //[HttpGet]
    //[Route("get-courseInfoBySchoolAndCourse")]
    //public async Task<ActionResult> GetCourseInfoBySchoolAndCourse(int baseSchoolNameId, int courseNameId, int courseDurationId)
    //{
    //    var CourseTrainee = await _mediator.Send(new GetCourseInfoBySchoolAndCourseFromSpRequest
    //    {
    //        BaseSchoolNameId = baseSchoolNameId,
    //        CourseNameId = courseNameId,
    //        CourseDurationId = courseDurationId
    //    });
    //    return Ok(CourseTrainee);
    //}

    [HttpGet]
    [Route("get-courseDurationByCourseTypeForInterService")]
    public async Task<ActionResult> GetCourseDurationForInterserviceByCourseType(int courseTypeId)
    {
        var localCourses = await _mediator.Send(new GetCourseDurationForInterserviceByCourseTypeIdRequest
        {
            CourseTypeId = courseTypeId,
        }); 
        return Ok(localCourses);
    }


    [HttpGet]
    [Route("get-selectedCourseTitleByBaseSchool")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseTitleByBaseSchool(int baseSchoolNameId)
    {
        var CourseTitleByBaseSchool = await _mediator.Send(new GetCourseTitleByBaseSchoolNameIdRequest { BaseSchoolNameId = baseSchoolNameId });
        return Ok(CourseTitleByBaseSchool);
    }

    [HttpGet]
    [Route("get-selectedCourseDurationByParameterRequestFromRoutine")]
    public async Task<ActionResult<List<SelectedModel>>> CourseDurationByParameterRequestFromRoutine(int baseSchoolNameId,int courseNameId, int classPeriodId)
    {
        var courseDurations = await _mediator.Send(new GetSelectedCourseDurationByParametersFromClassRoutineRequest
        { 
            BaseSchoolNameId = baseSchoolNameId,
            ClassPeriodId = classPeriodId,
            CourseNameId =courseNameId 
        });
        return Ok(courseDurations); 
    }

    [HttpGet]
    [Route("get-selectedCourseDurationIdByBaseSchoolNameAndCourseNameRequest")]
    public async Task<int> CourseDurationIdByBaseSchoolNameAndCourseName(int baseSchoolNameId, int courseNameId)
    {
        var courseDurationId = await _mediator.Send(new GetCourseDurationByBaseSchoolNameAndCourseNameRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return courseDurationId;
    }

    [HttpGet]
    [Route("get-selectedCourseNameFromCourseDurations")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseNameFromCourseDuration()
    {
        var selectedCourseDuration = await _mediator.Send(new GetSelectedCourseNameFromCourseDurationRequest { });
        return Ok(selectedCourseDuration);
    }


    [HttpGet]
    [Route("get-selectedCourseNameByCourseTypeIdFromDuration")]
    public async Task<ActionResult<List<CourseDurationDto>>> GetselectedCourseNameByCourseTypeIdFromDuration(int courseTypeId)
    {
        var interServices = await _mediator.Send(new GetSelectedCourseNameByCourseTypeIdFromCourseDurationRequest
        {
            CourseTypeId = courseTypeId
        });
        return Ok(interServices);
    }
    [HttpGet]
    [Route("get-selectedCourseNameByOrganizationNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseNameByOrganizationNameId(int organizationNameId)
    {
        var CourseNameByOrganizationName = await _mediator.Send(new GetCourseNameByOrganizationNameIdRequest { OrganizationNameId = organizationNameId });
        return Ok(CourseNameByOrganizationName);
    }
    [HttpGet]
    [Route("get-selectedCourseDurationByParameterRequestFromEntryEvaluation")]
    public async Task<ActionResult<List<SelectedModel>>> CourseDurationByParameterRequestFromEntryEvaluation(int baseSchoolNameId, int courseNameId)
    {
        var courseDurations = await _mediator.Send(new GetSelectedCourseDurationByParametersFromNewEntryEvaluationRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(courseDurations);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("deactive-courseDuration/{id}")]
    public async Task<ActionResult> DeActiveCoursePlan(int id)
    {
        var command = new DeActivateCourseDurationCommand { CourseDurationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-courseDurationForEventCalendar")]
    public async Task<ActionResult<List<SelectedModel>>> GetCourseDurationForEventCalendar()
    {
        var courseDurationForEventCalendar = await _mediator.Send(new GetCourseDurationListForEventCalendarFromSpRequest
        {
            
        });
        return Ok(courseDurationForEventCalendar);
    }
    [HttpGet]
    [Route("get-selectedCourseNameBySchoolNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseNameBySchoolNameId(int baseSchoolNameId)
    {
        var courseBySchoolNameId = await _mediator.Send(new GetCourseNameBySchoolNameIdRequest
        {
            BaseSchoolNameId = baseSchoolNameId
            
        });
        return Ok(courseBySchoolNameId);
    }

    [HttpGet]
    [Route("get-foreignCourseListByCountryId")]
    public async Task<ActionResult<List<CourseDurationDto>>> GetForeignCourseListByCountryId(int countryId)
    {
        var foreignCourses = await _mediator.Send(new GetForeignCourseListByCountryIdRequest
        {
            CountryId = countryId
        });
        return Ok(foreignCourses);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("change-courseCompleteStatus")]
    public async Task<ActionResult> ActiveCoursePlan(int courseDurationId, int isCompleteStatus)
    {
        var command = new ChangeCourseDurationStatusCommand
        {
            CourseDurationId = courseDurationId,
            IsCompletedStatus = isCompleteStatus
        };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [Route("get-selectedInterServiceCourseListByCourseNameIdAndOrganizationNameId")]
    public async Task<ActionResult<List<CourseDurationDto>>> GetInterServiceCourseListByCourseNameIdAndOrganizationNameId(int courseNameId, int organizationNameId)
    {
        var interService = await _mediator.Send(new GetInterServiceCourseListByCourseNameIdAndOrganizationNameIdRequest
        {
            CourseNameId = courseNameId,
            OrganizationNameId = organizationNameId
        });
        return Ok(interService);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("stop-interService/{id}")]
    public async Task<ActionResult> StopInterService(int id)
    {
        var command = new StopInterServiceCommand { CourseDurationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("running-interService/{id}")]
    public async Task<ActionResult> RunningInterService(int id)
    {
        var command = new RunningInterServiceCommand { CourseDurationId = id };
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpGet]
    [Route("get-interServiceCourseByParameters")]

    public async Task<ActionResult> GetInterServiceCourseByParameters( int courseNameId, int organizationNameId)
    {
        var CourseInstructorByParameters = await _mediator.Send(new GetInterServiceCourseByParametersRequest
        {
            CourseNameId = courseNameId,
            OrganizationNameId= organizationNameId
        });
        return Ok(CourseInstructorByParameters);
    }
    [HttpGet]
    [Route("get-courseDurationByCourseNameId")]
    public async Task<ActionResult<List<CourseDurationDto>>> GetCourseDurationByCourseNameId([FromQuery] QueryParams queryParams)
    {
        var localCourses = await _mediator.Send(new GetCourseDurationByCourseNameIdRequest
        {
            //CourseTypeId = courseTypeId,
            QueryParams = queryParams
        });
        return Ok(localCourses);
    }

    [HttpGet]
    [Route("get-courseDurationByCourseNameInQExamId")]
    public async Task<ActionResult<List<CourseDurationDto>>> GetCourseDurationByCourseNameInQExamId([FromQuery] QueryParams queryParams)
    {
        var localCourses = await _mediator.Send(new GetCourseDurationByCourseNameInQExamIdRequest
        {
            //CourseTypeId = courseTypeId,
            QueryParams = queryParams
        });
        return Ok(localCourses);
    }


    [HttpGet]
    [Route("get-selectedCourseDurationByCourseTypeIdAndCourseNameId")]
    public async Task<ActionResult<List<SelectedModel>>> CourseDurationByCourseTypeIdAndCourseNameId(int courseTypeId,int courseNameId)
    {
        var courseDuration = await _mediator.Send(new GetSelectedCourseDurationByCourseTypeIdAndCourseNameIdRequest
        { 
            CourseTypeId=courseTypeId,
            CourseNameId=courseNameId
        });
        return Ok(courseDuration);
    }
    [HttpGet]
    [Route("get-selectedCourseNameByCountryId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseNameByCountryId(int country)
    {
        var CourseNameBycountry = await _mediator.Send(new GetCourseNameByCountryIdRequest { CountryId =  country });
        return Ok(CourseNameBycountry);
    }
    [HttpGet]
    [Route("get-courseDurationByCourseNameInJCOsTrainingId")]
    public async Task<ActionResult<List<CourseDurationDto>>> GetCourseDurationByCourseNameInJCOsTrainingId([FromQuery] QueryParams queryParams)
    {
        var localCourses = await _mediator.Send(new GetCourseDurationByCourseNameInJCOsTrainingIdRequest
        {
            QueryParams = queryParams
        });
        return Ok(localCourses);
    }
    [HttpGet]
    [Route("get-selectedCourseNameByCourseTypeIdAndCompletedStatusFromCourseDuration")]
    public async Task<ActionResult<List<CourseDurationDto>>> GetSelectedCourseNameByCourseTypeIdAndCompletedStatusFromCourseDuration()
    {
        var foreignCourse = await _mediator.Send(new GetSelectedCourseNameByCourseTypeIdAndCompletedStatusFromCourseDurationRequest
        {
            //CourseTypeId = courseTypeId
        });
        return Ok(foreignCourse);
    }


    [HttpGet]
    [Route("get-nominatedTraineeCountByDurationId")]
    public async Task<ActionResult> GetNominatedTraineeCountByDurationId(int courseDurationId)
    {
        var CourseTrainee = await _mediator.Send(new GetNominatedTraineeCountByDurationIdSpRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(CourseTrainee);
    }


    [HttpGet]
    [Route("get-courseInfoBySchoolAndCourse")]
    public async Task<ActionResult> GetCourseInfoBySchoolAndCourse(int baseSchoolNameId,int courseNameId,int courseDurationId)
    {
        var CourseTrainee = await _mediator.Send(new GetCourseInfoBySchoolAndCourseFromSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId
        });
        return Ok(CourseTrainee);
    }

    [HttpGet]
    [Route("get-courseDurtationInfoByTrainee")]
    public async Task<ActionResult> GetCourseDurtationInfoByTrainee(int traineeId)
    {
        var CourseTrainee = await _mediator.Send(new GetCourseDurtationInfoByTraineeSpRequest
        {
            TraineeId = traineeId
        });
        return Ok(CourseTrainee);
    }

    [HttpGet]
    [Route("get-selectedCourseDurationBySchoolNameAndDuration")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCoursedurationByschoolnameAndDuration(int baseSchoolNameId)
    {
        var selectedCourseDuration = await _mediator.Send(new GetSelectedCourseDurationBySchoolNameAndDurationRequest { BaseSchoolNameId = baseSchoolNameId });
        return Ok(selectedCourseDuration);
    }

    [HttpGet]
    [Route("get-nbcdCourseDurationByBaseSchoolNameId")]
    public async Task<ActionResult> GetNbCdCourseDurationByBaseSchoolNameId(int baseSchoolNameId,int courseDurationId)
    {
        var NbcdCourseList = await _mediator.Send(new GetNbcdCourseByBaseSchoolFromSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseDurationId = courseDurationId
        });
        return Ok(NbcdCourseList);
    }

    [HttpGet]
    [Route("get-nbcdSchoolNameByBaseSchoolNameId")]
    public async Task<ActionResult> GetNbCdSchoolNameByCourseDurationId(int courseDurationId)
    {
        var CourseTrainee = await _mediator.Send(new GetNbcdSchoolNameByCourseDurationIdRequest
        {
            CourseDurationId = courseDurationId
        });
        return Ok(CourseTrainee);
    }

    [HttpGet]
    [Route("get-nbcdCourseDurationByNbcdSchoolId")]
    public async Task<ActionResult> GetNbcdCourseDurationByNbcdSchoolId(int nbcdSchoolId)
    {
        var CourseTrainee = await _mediator.Send(new GetCourseDurationListForNbcdFromSpRequest
        {
            NbcdSchoolId = nbcdSchoolId,
            CurrentDate =DateTime.Now
        });
        return Ok(CourseTrainee);
    }

    [HttpGet]
    [Route("get-runningCourseByNbcdSchoolNomination")]
    public async Task<ActionResult> GetRunningCourseByNbcdSchoolNomination(int courseTypeId, DateTime currentDate, int baseSchoolNameId, int viewStatus)
    {
        var courses = await _mediator.Send(new GetRunningCourseDurationListByNbcdSchoolNominationFromSpRequest
        {
            CourseTypeId = courseTypeId,
            CurrentDate = currentDate,
            BaseSchoolNameId = baseSchoolNameId,
            ViewStatus = viewStatus
        });
        return Ok(courses);
    }
    [HttpGet]
    [Route("get-runningCourseListForForeingTrainee")]
    public async Task<ActionResult> GetRunningCourseDurationfromprocedure( DateTime CurrentDate, int viewStatus)
    {
        var proceduredCourses = await _mediator.Send(new GetRunningCourseListForForeingTraineeSpRequest
        {
          
            CurrentDate = CurrentDate,
            ViewStatus = viewStatus
        });
        return Ok(proceduredCourses);
    }
    [HttpGet]
    [Route("get-runningCourseListForForeingTraineeDetails")]
    public async Task<ActionResult> GetRunningCourseForForeingTraineeDetail(DateTime CurrentDate, int viewStatus)
    {
        var proceduredCourses = await _mediator.Send(new GetRunningCourseListForForeingTraineeDetailsSpRequest
        {

            CurrentDate = CurrentDate,
            ViewStatus = viewStatus
        });
        return Ok(proceduredCourses);
    }
    [HttpGet]
    [Route("get-runningCourseListForForeingTraineeCountry")]
    public async Task<ActionResult> GetRunningCourseForForeingTraineeCountry(DateTime CurrentDate, int viewStatus)
    {
        var proceduredCourses = await _mediator.Send(new GetRunningCourseListForForeingTraineeCountrySpRequest
        {

            CurrentDate = CurrentDate,
            ViewStatus = viewStatus
        });
        return Ok(proceduredCourses);
    }
    [HttpGet]
    [Route("get-runningCourseListForForeingTraineeDesignation")]
    public async Task<ActionResult> GetRunningCourseForForeingTraineeDesignation(DateTime CurrentDate, int viewStatus)
    {
        var proceduredCourses = await _mediator.Send(new GetRunningCourseListForForeingTraineeDesignationSpRequest
        {

            CurrentDate = CurrentDate,
            ViewStatus = viewStatus
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-runningCourseListForForeingTraineeUpcoming")]
    public async Task<ActionResult> GetRunningCourseForForeingTraineeUpcoming(DateTime CurrentDate)
    {
        var proceduredCourses = await _mediator.Send(new GetRunningCourseListForForeingTraineeUpcomingSpRequest
        {

            CurrentDate = CurrentDate
        });
        return Ok(proceduredCourses);
    }

    [HttpGet]
    [Route("get-selectedCourseDurationForBna")]
    public async Task<ActionResult<List<SelectedModel>>> CourseDurationForBna()
    {
        var courseDuration = await _mediator.Send(new GetSelectedCourseDurationForBnaRequest
        {
            //CourseTypeId = courseTypeId,
            //CourseNameId = courseNameId
        });
        return Ok(courseDuration);
    }

    [HttpGet]
    [Route("get-courseDurationListForBnaByCourseTypeFilter")]
    public async Task<ActionResult> GetCourseDurationListForBnaByCourseTypeFilter(int viewStatus, int courseTypeId)
    {
        var localCourses = await _mediator.Send(new GetCourseDurationListForBnaByCourseTypeIdFilterRequest
        {
            CourseTypeId = courseTypeId,
            ViewStatus = viewStatus
        });

        return Ok(localCourses);
    }
    [HttpGet]
    [Route("get-upcomingCourseDurationListForBnaByBase")]
    public async Task<ActionResult> GetUpcomingCourseDurationListForBnaByBase(int baseNameId, DateTime CurrentDate)
    {
        var proceduredCourses = await _mediator.Send(new GetUpcomingCourseListForBnaByBaseFromSpRequest
        {
            BaseNameId = baseNameId,
            CurrentDate = CurrentDate
        });
        return Ok(proceduredCourses);
    }
}

