﻿using SchoolManagement.Application;
using SchoolManagement.Application.Contracts.Identity;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;
using SchoolManagement.Application.DTOs.User;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Queries;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Commands;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using SchoolManagement.Application.Features.TraineeBIODataGeneralInfos.Requests.Commands;
using SchoolManagement.Application.Features.TraineeBIODataGeneralInfos.Requests.Queries;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Commands;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;


[Route(SMSRoutePrefix.TraineeBioDataGeneralInfo)]
[ApiController]
[Authorize]
public class TraineeBioDataGeneralInfoController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserService _userService;

    public TraineeBioDataGeneralInfoController(IMediator mediator, IUserService userService)
    {
        _mediator = mediator;
        _userService = userService;
    }

    [HttpGet]
    [Route("get-traineeBioDataGeneralInfoes")]
    public async Task<ActionResult<List<TraineeBioDataGeneralInfoDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TraineeBioDataGeneralInfos = await _mediator.Send(new GetTraineeBioDataGeneralInfoListRequest { QueryParams = queryParams });
        return Ok(TraineeBioDataGeneralInfos);
    }

    [HttpGet]
    [ResponseCache(Duration = 10)]
    [Route("get-traineeListForUserCreate")]
    public async Task<ActionResult> GetTraineeListForUserCreate(string pno, int pageSize, int pageNumber)
    {
        var proceduredTrainee = await _mediator.Send(new GetTraineeListForUserCreateRequest
        {
            Pno = pno,
            PageSize = pageSize,
            PageNumber = pageNumber
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
    [Route("get-midBioDataGeneralInfoes")]
    public async Task<ActionResult<List<TraineeBioDataGeneralInfoDto>>> GetMidList([FromQuery] QueryParams queryParams)
    {
        var TraineeBioDataGeneralInfos = await _mediator.Send(new GetTraineeBioDataGeneralInfoListForMidRequest { QueryParams = queryParams });
        return Ok(TraineeBioDataGeneralInfos);
    }

    [HttpGet]
    [Route("get-cadetBioDataGeneralInfoes")]
    public async Task<ActionResult<List<TraineeBioDataGeneralInfoDto>>> GetCadetList([FromQuery] QueryParams queryParams)
    {
        var TraineeBioDataGeneralInfos = await _mediator.Send(new GetTraineeBioDataGeneralInfoListForCadetRequest { QueryParams = queryParams });
        return Ok(TraineeBioDataGeneralInfos);
    }

    [HttpGet]
    [Route("get-i-s-BioDataGeneralInfoes")]
    public async Task<ActionResult<List<TraineeBioDataGeneralInfoDto>>> GetIsList([FromQuery] QueryParams queryParams)
    {
        var TraineeBioDataGeneralInfos = await _mediator.Send(new GetTraineeBioDataGeneralInfoListForIsRequest { QueryParams = queryParams });
        return Ok(TraineeBioDataGeneralInfos);
    }

    [HttpGet]
    [Route("get-BioDataGeneralInfoes-by-trainee-status")]
    public async Task<ActionResult<List<TraineeBioDataGeneralInfoDto>>> GetTrainneListByStatusId([FromQuery] QueryParams queryParams, int traineeStatusId)
    {
        var TraineeBioDataGeneralInfos = await _mediator.Send(new GetTraineeBioDataGeneralInfoListForByTraineeStatusRequest {
            QueryParams = queryParams,
            TraineeStatusId = traineeStatusId
        });
        return Ok(TraineeBioDataGeneralInfos);
    }

     [HttpGet]
    [Route("get-service-instructor-biodata")]
    public async Task<ActionResult<List<TraineeBioDataGeneralInfoDto>>> GetServiceInstructorBioData([FromQuery] QueryParams queryParams, string branchId)
    {
        var TraineeBioDataGeneralInfos = await _mediator.Send(new GetServiceInstructorBioDataRequest
        {
            QueryParams = queryParams,
            BranchId = branchId
        });
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

        await _userService.CreateUser("", response.Id.ToString(), createTraineeBioDataGeneralInfo);
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
        await _userService.DeleteBioDataUser(id);
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
    [Route("get-autocompletePnoAndName")]
    public async Task<ActionResult<List<SelectedModel>>> GetAutoCompletePnoAndName(string pno)
    {
        var trainee = await _mediator.Send(new GetAutoCompleteTraineePnoAndName
        {
            PNo = pno
        } );
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

    [HttpPost]
    [Route("post-biodataExeclfile")]
    public async Task <ActionResult> UploadBioDataFile([FromForm] IFormFile file, int traineeStatusId)
    {
        var bioData = await _mediator.Send(new UploadTraineeBIODataGeneralInfoCommand
        {
            TraineeBIODataGeneralInfoFile = file,
            TraineeStatusId = traineeStatusId
            
        });
        return Ok(bioData);
    }

    [HttpPost]
    [Route("post-biodataExeclfileForOfficerAndCivil")]
    public async Task<ActionResult> UploadBioDataFileForOfficerAndCivil([FromForm] IFormFile file, int traineeStatusId, int officerTypeId)
    {
        var bioData = await _mediator.Send(new UploadTraineeBIODataGeneralInfoCommand
        {
            TraineeBIODataGeneralInfoFile = file,
            TraineeStatusId = traineeStatusId,
            officerTypeId = officerTypeId

        });
        return Ok(bioData);
    }

    [HttpGet]
    [Route("get-selected-instructor-by-school")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedInstructorBySchool(int branchId)
    {
        var trainee = await _mediator.Send(new GetSelectedTraineeBioDataGeneralInfoRequestBySchoolRequest
        {
            BranchId = branchId

        });
        return Ok(trainee);
    }

    [HttpPost]
    [Route("get-upload-service-instructor-execl-file")]
    public async Task<ActionResult> UploadServiceInstructorListBySchool([FromForm] IFormFile file, string branchId)
    {
        var trainee = await _mediator.Send(new UploadServiceInstructorCommand
        {
            ServiceInstructorFile = file,
            BranchId = branchId
        });
        return Ok(trainee);
    }

    [HttpPost]
    [Route("get-upload-service-instructor-execl-file-by-admin")]
    public async Task<ActionResult> UploadServiceInstructorListByMasterAdmin([FromForm] IFormFile file)
    {
        var trainee = await _mediator.Send(new UploadServiceInstructorByAdminCommand
        {
            ServiceInstructorFile = file,

        });
        return Ok(trainee);
    }

}