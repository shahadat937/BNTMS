using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.GuestSpeakerQuestionName;
using SchoolManagement.Application.DTOs.TdecQuestionName;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Commands;
using SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Queries;
using SchoolManagement.Application.Features.TdecQuestionNames.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.GuestSpeakerQuestionName)]
[ApiController]
[Authorize]
public class GuestSpeakerQuestionNameController : ControllerBase
{
    private readonly IMediator _mediator;

    public GuestSpeakerQuestionNameController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-GuestSpeakerQuestionNames")]
    public async Task<ActionResult<List<GuestSpeakerQuestionNameDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var GuestSpeakerQuestionNames = await _mediator.Send(new GetGuestSpeakerQuestionNameListRequest { QueryParams = queryParams });
        return Ok(GuestSpeakerQuestionNames);
    }


    [HttpGet]
    [Route("get-GuestSpeakerQuestionNameDetail/{id}")]
    public async Task<ActionResult<GuestSpeakerQuestionNameDto>> Get(int id)
    {
        var GuestSpeakerQuestionName = await _mediator.Send(new GetGuestSpeakerQuestionNameDetailRequest { GuestSpeakerQuestionNameId = id });
        return Ok(GuestSpeakerQuestionName);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-GuestSpeakerQuestionName")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateGuestSpeakerQuestionNameDto GuestSpeakerQuestionName)
    {
        var command = new CreateGuestSpeakerQuestionNameCommand { GuestSpeakerQuestionNameDto = GuestSpeakerQuestionName };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-GuestSpeakerQuestionName/{id}")]
    public async Task<ActionResult> Put([FromBody] GuestSpeakerQuestionNameDto GuestSpeakerQuestionName)
    {
        var command = new UpdateGuestSpeakerQuestionNameCommand { GuestSpeakerQuestionNameDto = GuestSpeakerQuestionName };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-GuestSpeakerQuestionName/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteGuestSpeakerQuestionNameCommand { GuestSpeakerQuestionNameId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedGuestSpeakerQuestionName")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedGuestSpeakerQuestionName()
    {
        var GuestSpeakerQuestionName = await _mediator.Send(new GetSelectedGuestSpeakerQuestionNameRequest { });
        return Ok(GuestSpeakerQuestionName);
    }

    [HttpGet] 
    [Route("get-guestSpeakerQuestionNameList")]
    public async Task<ActionResult<List<TdecQuestionNameDto>>> GetTdecQuestionNameList(int baseSchoolNameId)
    {
        var guestSpeakerList = await _mediator.Send(new GetGuestSpeakerQuestionListRequest
        {
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(guestSpeakerList);
    }

    [HttpGet]
    [Route("get-guestSpeakerList")]
    public async Task<ActionResult<List<TdecQuestionNameDto>>> GetGuestSpeakerList([FromQuery] QueryParams queryParams, int baseSchoolNameId)
    {
        var TdecQuestionNames = await _mediator.Send(new GetGuestSpeakerListRequest
        {
            QueryParams = queryParams,
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(TdecQuestionNames);
    }
}

