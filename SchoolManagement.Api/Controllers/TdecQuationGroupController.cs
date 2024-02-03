using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Attendance.ApprovedAttendance;
using SchoolManagement.Application.DTOs.TdecQuationGroup;
using SchoolManagement.Application.DTOs.TdecQuationGroup.CreateTdecQuationGroup;
using SchoolManagement.Application.Features.TdecQuationGroups.Requests.Commands;
using SchoolManagement.Application.Features.TdecQuationGroups.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TdecQuationGroup)]
[ApiController]
[Authorize]
public class TdecQuationGroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public TdecQuationGroupController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-tdecQuationGroups")]
    public async Task<ActionResult<List<TdecQuationGroupDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TdecQuationGroups = await _mediator.Send(new GetTdecQuationGroupListRequest { QueryParams = queryParams });
        return Ok(TdecQuationGroups);
    }



    [HttpGet]
    [Route("get-TdecQuationGroupDetail/{id}")]
    public async Task<ActionResult<TdecQuationGroupDto>> Get(int id)
    {
        var TdecQuationGroup = await _mediator.Send(new GetTdecQuationGroupDetailRequest { TdecQuationGroupId = id });
        return Ok(TdecQuationGroup);
    }

     
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-tdecQuationGroup")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTdecQuationGroupDto TdecQuationGroup)
    {
        var command = new CreateTdecQuationGroupCommand { TdecQuationGroupDto = TdecQuationGroup };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-tdecQuationGroup/{id}")]
    public async Task<ActionResult> Put([FromBody] TdecQuationGroupDto TdecQuationGroup)
    {
        var command = new UpdateTdecQuationGroupCommand { TdecQuationGroupDto = TdecQuationGroup };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-tdecQuationGroup/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTdecQuationGroupCommand { TdecQuationGroupId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedTdecQuationGroup")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedTdecQuationGroup()
    {
        var TdecQuationGroup = await _mediator.Send(new GetSelectedTdecQuationGroupRequest { });
        return Ok(TdecQuationGroup);
    }

    [HttpGet]
    [Route("get-tdecQuationGroupByParams")]
    public async Task<ActionResult<List<TdecQuationGroupDto>>> GetTdecQuationGroupByParams(int baseSchoolNameId,int courseNameId,int courseDurationId, int bnaSubjectNameId)
    {
        var TdecQuationGroup = await _mediator.Send(new GetTdecQuationGroupByParamsRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            CourseDurationId = courseDurationId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(TdecQuationGroup);
    }
}

