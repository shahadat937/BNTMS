using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Attendance.ApprovedAttendance;
using SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup;
using SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup.CreateGuestSpeakerQuationGroup;
using SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Commands;
using SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.GuestSpeakerQuationGroup)]
[ApiController]
[Authorize]
public class GuestSpeakerQuationGroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public GuestSpeakerQuationGroupController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-GuestSpeakerQuationGroups")]
    public async Task<ActionResult<List<GuestSpeakerQuationGroupDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var GuestSpeakerQuationGroups = await _mediator.Send(new GetGuestSpeakerQuationGroupListRequest { QueryParams = queryParams });
        return Ok(GuestSpeakerQuationGroups);
    }



    [HttpGet]
    [Route("get-GuestSpeakerQuationGroupDetail/{id}")]
    public async Task<ActionResult<GuestSpeakerQuationGroupDto>> Get(int id)
    {
        var GuestSpeakerQuationGroup = await _mediator.Send(new GetGuestSpeakerQuationGroupDetailRequest { GuestSpeakerQuationGroupId = id });
        return Ok(GuestSpeakerQuationGroup);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-GuestSpeakerQuationGroup")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateGuestSpeakerQuationGroupDto GuestSpeakerQuationGroup)
    {
        var command = new CreateGuestSpeakerQuationGroupCommand
        {
            GuestSpeakerQuationGroupDto = GuestSpeakerQuationGroup
        };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-GuestSpeakerQuationGroup/{id}")]
    public async Task<ActionResult> Put([FromBody] GuestSpeakerQuationGroupDto GuestSpeakerQuationGroup)
    {
        var command = new UpdateGuestSpeakerQuationGroupCommand { GuestSpeakerQuationGroupDto = GuestSpeakerQuationGroup };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-GuestSpeakerQuationGroup/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteGuestSpeakerQuationGroupCommand { GuestSpeakerQuationGroupId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedGuestSpeakerQuationGroup")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedGuestSpeakerQuationGroup()
    {
        var GuestSpeakerQuationGroup = await _mediator.Send(new GetSelectedGuestSpeakerQuationGroupRequest { });
        return Ok(GuestSpeakerQuationGroup);
    }

    [HttpGet]
    [Route("get-GuestSpeakerQuationGroupByParams")]
    public async Task<ActionResult<List<GuestSpeakerQuationGroupDto>>> GetGuestSpeakerQuationGroupByParams(int baseSchoolNameId,int courseNameId,int courseDurationId, int bnaSubjectNameId)
    {
        var GuestSpeakerQuationGroup = await _mediator.Send(new GetGuestSpeakerQuationGroupByParamsRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(GuestSpeakerQuationGroup);
    }

    [HttpGet]
    [Route("get-GuestSpeakerQuationGroupByParamsSp")]
    public async Task<ActionResult> GetGuestSpeakerQuationGroupByParamsSp(int baseSchoolNameId,int courseNameId,int courseDurationId, int bnaSubjectNameId)
    {
        var GuestSpeakerQuationGroup = await _mediator.Send(new GetGuestSpeakerQuationGroupListFromSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(GuestSpeakerQuationGroup);
    }
}

