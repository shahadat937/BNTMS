using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.FamilyInfo;
using SchoolManagement.Application.Features.FamilyInfos.Requests.Commands;
using SchoolManagement.Application.Features.FamilyInfos.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.FamilyInfo)]
[ApiController]
[Authorize]
public class FamilyInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public FamilyInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-FamilyInfos")]
    public async Task<ActionResult<List<FamilyInfoDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var FamilyInfos = await _mediator.Send(new GetFamilyInfoListRequest { QueryParams = queryParams });
        return Ok(FamilyInfos);
    }


    [HttpGet]
    [Route("get-FamilyInfoDetail/{id}")]
    public async Task<ActionResult<FamilyInfoDto>> Get(int id)
    {
        var FamilyInfo = await _mediator.Send(new GetFamilyInfoDetailRequest { FamilyInfoId = id });
        return Ok(FamilyInfo);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-FamilyInfo")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateFamilyInfoDto FamilyInfo)
    {
        var command = new CreateFamilyInfoCommand { FamilyInfoDto = FamilyInfo };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-FamilyInfo/{id}")]
    public async Task<ActionResult> Put([FromBody] FamilyInfoDto FamilyInfo)
    {
        var command = new UpdateFamilyInfoCommand { FamilyInfoDto = FamilyInfo };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-FamilyInfo/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteFamilyInfoCommand { FamilyInfoId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedFamilyInfos")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedFamilyInfo()
    {
        var selectedFamilyInfo = await _mediator.Send(new GetSelectedFamilyInfoRequest { });
        return Ok(selectedFamilyInfo);
    }
    [HttpGet]
    [Route("get-familyInfoListByPno")]
    public async Task<ActionResult<List<FamilyInfoDto>>> GetFamilyInfoListByPno(int traineeId)
    {
        var familyInfos = await _mediator.Send(new GetFamilyInfoListByPnoRequest
        {
            TraineeId = traineeId
        });
        return Ok(familyInfos);
    }

    [HttpGet]
    [Route("get-familyInfoListByTraineeId")]
    public async Task<ActionResult<List<FamilyInfoDto>>> GetFamilyInfoListByTraineeId(int traineeId)
    {
        var familyInfos = await _mediator.Send(new GetFamilyInfoListTraineeIdRequest
        {
            TraineeId = traineeId
        });
        return Ok(familyInfos);
    }
}

