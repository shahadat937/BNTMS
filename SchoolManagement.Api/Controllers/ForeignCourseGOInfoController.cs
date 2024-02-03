using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ForeignCourseGOInfo;
using SchoolManagement.Application.Features.ForeignCourseGOInfos.Requests.Commands;
using SchoolManagement.Application.Features.ForeignCourseGOInfos.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ForeignCourseGOInfo)]
[ApiController]
[Authorize]
public class ForeignCourseGOInfoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ForeignCourseGOInfoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-ForeignCourseGOInfos")]
    public async Task<ActionResult<List<ForeignCourseGOInfoDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ForeignCourseGOInfos = await _mediator.Send(new GetForeignCourseGOInfoListRequest { QueryParams = queryParams });
        return Ok(ForeignCourseGOInfos);
    }

    [HttpGet]
    [Route("get-ForeignCourseGOInfoDetail/{id}")]
    public async Task<ActionResult<ForeignCourseGOInfoDto>> Get(int id)
    {
        var ForeignCourseGOInfo = await _mediator.Send(new GetForeignCourseGOInfoDetailRequest { ForeignCourseGOInfoId = id });
        return Ok(ForeignCourseGOInfo);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-ForeignCourseGOInfo")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateForeignCourseGOInfoDto ForeignCourseGOInfo)
    {
        var command = new CreateForeignCourseGOInfoCommand { ForeignCourseGOInfoDto = ForeignCourseGOInfo };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-ForeignCourseGOInfo/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateForeignCourseGOInfoDto ForeignCourseGOInfo)
    {
        var command = new UpdateForeignCourseGOInfoCommand { CreateForeignCourseGOInfoDto = ForeignCourseGOInfo };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ForeignCourseGOInfo/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteForeignCourseGOInfoCommand { ForeignCourseGOInfoId = id };
        await _mediator.Send(command);
        return NoContent();
    }
    // relational data get 
    //[HttpGet]
    //[Route("get-selectedForeignCourseGOInfos")]
    //public async Task<ActionResult<List<SelectedModel>>> getselectedForeignCourseGOInfo()
    //{
    //    var selectedForeignCourseGOInfo = await _mediator.Send(new GetSelectedForeignCourseGOInfoRequest { });
    //    return Ok(selectedForeignCourseGOInfo);
    //}
}

