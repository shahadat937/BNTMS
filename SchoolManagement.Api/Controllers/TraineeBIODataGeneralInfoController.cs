using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Commands;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using SchoolManagement.Application.Features.TraineeBIODataGeneralInfos.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;


[Route(SMSRoutePrefix.TraineeBioDataGeneralInfo)]
[ApiController]
[Authorize]
public class TraineeBioDataGeneralInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public TraineeBioDataGeneralInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-traineeBioDataGeneralInfoes")]
    public async Task<ActionResult<List<TraineeBioDataGeneralInfoDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TraineeBioDataGeneralInfos = await _mediator.Send(new GetTraineeBioDataGeneralInfoListRequest { QueryParams = queryParams });
        return Ok(TraineeBioDataGeneralInfos);
    }

    [HttpGet]
    [Route("get-traineeListForUserCreate")]
    public async Task<ActionResult> GetTraineeListForUserCreate(string pno)
    {
        var proceduredTrainee = await _mediator.Send(new GetTraineeListForUserCreateRequest
        {
            Pno = pno
        });
        return Ok(proceduredTrainee);
    }

    [HttpGet]
    [Route("get-foreignOfficerBioDataGeneralInfoes")]
    public async Task<ActionResult<List<TraineeBioDataGeneralInfoDto>>> GetForeignOfficerList([FromQuery] QueryParams queryParams)
    {
        var TraineeBioDataGeneralInfos = await _mediator.Send(new GetTraineeBioDataGeneralInfoListForForeignRequest { QueryParams = queryParams });
        return Ok(TraineeBioDataGeneralInfos);
    }



    [HttpGet]
    [Route("get-civilInstructorBioDataGeneralInfoes")]
    public async Task<ActionResult<List<TraineeBioDataGeneralInfoDto>>> GetCivilInstructorList([FromQuery] QueryParams queryParams)
    {
        var TraineeBioDataGeneralInfos = await _mediator.Send(new GetTraineeBioDataGeneralInfoListCivilInstructorRequest { QueryParams = queryParams });
        return Ok(TraineeBioDataGeneralInfos);
    }

    [HttpGet]
    [Route("get-sailors")]

    public async Task<ActionResult<List<TraineeBioDataGeneralInfoDto>>> GetSailorList([FromQuery] QueryParams queryParams)
    {
        var TraineeBioDataGeneralInfos = await _mediator.Send(new GetSaylorBioDataGeneralInfoListRequest { QueryParams = queryParams });
        return Ok(TraineeBioDataGeneralInfos);
    }

    [HttpGet]
    [Route("get-traineedetails/{traineeId}")]

    public async Task<ActionResult<TraineeBioDataGeneralInfoDto>> GetTraineeDetails(int traineeId)
    {
        var TraineeBioDataGeneralInfo = await _mediator.Send(new GetTraineeBioDataGeneralInfoByTraineeId { TraineeId = traineeId });
        return Ok(TraineeBioDataGeneralInfo);
    }


    [HttpGet]
    [Route("get-traineedetail/{id}")]
    public async Task<ActionResult<TraineeBioDataGeneralInfoDto>> Get(int id)
    {
        var TraineeBioDataGeneralInfo = await _mediator.Send(new GetTraineeBioDataGeneralInfoDetailRequest { TraineeId = id });
        return Ok(TraineeBioDataGeneralInfo);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-traineeBioDataGeneralInfo")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateTraineeBioDataGeneralInfoDto createTraineeBioDataGeneralInfo)
    {
        var command = new CreateTraineeBioDataGeneralInfoCommand { TraineeBioDataGeneralInfoDto = createTraineeBioDataGeneralInfo };
        var response = await _mediator.Send(command);
        return Ok(response);

    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-traineeBioDataGeneralInfo/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateTraineeBioDataGeneralInfoDto createTraineeBioDataGeneralInfoDto)
    {
        var command = new UpdateTraineeBioDataGeneralInfoCommand { CreateTraineeBioDataGeneralInfoDto = createTraineeBioDataGeneralInfoDto };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-traineeBioDataGeneralInfo/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTraineeBioDataGeneralInfoCommand { TraineeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedTraineeByPno")] 
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedTraineeByPno()
    {
        var trainee = await _mediator.Send(new GetSelectedTraineeBioDataGeneralInfoRequest { });
        return Ok(trainee); 
    }

    [HttpGet]
    [Route("get-autocompleteTraineeByPno")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompleteTraineeByPno(string pNo,int courseDurationId, int courseNameId)
    {
        var trainee = await _mediator.Send(new GetAutoCompleteTraineeBioDataGeneralInfoRequest
        {
            PNo = pNo,
            CourseDurationId = courseDurationId,
            CourseNameId =courseNameId,
            //TraineeId = traineeId
        });
        return Ok(trainee);
    }
    


    [HttpGet]
    [Route("get-autocompletePnoForFamilyInfo")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompletePnoForFamilyInfo(string pno)
    {
        var trainee = await _mediator.Send(new GetAutoCompletePnoForFamilyInfoRequest
        {
            Pno = pno,
        });
        return Ok(trainee);
    }

    [HttpGet]
    [Route("get-autocompleteTraineeByPnoForUser")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompleteTraineeByPnoForUser(string pno)
    {
        var trainee = await _mediator.Send(new GetAutoCompleteTraineeByPnoForUserRequest
        {
            Pno = pno,
        });
        return Ok(trainee);
    }

    [HttpGet]
    [Route("get-selectedPresentBilletByTraineeId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSubjectNamesBySchoolAndCourse(int traineeId)
    {
        var presentBillet = await _mediator.Send(new GetPresentBilletRequest
        {
          TraineeId=traineeId
        });
        return Ok(presentBillet);
    }

    [HttpGet]
    [Route("get-autocompletePnoForNbcdNomination")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompletePnoForNbcdNomination(string pno)
    {
        var trainee = await _mediator.Send(new GetAutoCompletePnoForNbcdRequest
        {
            Pno = pno,
        });
        return Ok(trainee);
    }
    [HttpGet]
    [Route("get-autocompleteForBnaTraineeByPno")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompleteForBnaTraineeByPno(string pNo,int bnaSemesterDurationId, int courseDurationId, int courseNameId)
    {
        var trainee = await _mediator.Send(new GetAutoCompleteForBnaTraineeBioDataGeneralInfoRequest
        {
            PNo = pNo,
            BnaSemesterDurationId=bnaSemesterDurationId,
            CourseDurationId = courseDurationId,
            CourseNameId = courseNameId,
            //TraineeId = traineeId
        });
        return Ok(trainee);
    }

}