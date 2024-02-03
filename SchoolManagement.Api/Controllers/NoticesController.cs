using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.IndividualNotices;
using SchoolManagement.Application.DTOs.Notice;
using SchoolManagement.Application.Features.Notices.Requests.Commands;
using SchoolManagement.Application.Features.Notices.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Notice)]
[ApiController]
[Authorize]
public class NoticeController : ControllerBase
{
    private readonly IMediator _mediator;

    public NoticeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-notices")]
    public async Task<ActionResult<List<NoticeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Noticees = await _mediator.Send(new GetNoticeListRequest { QueryParams = queryParams });
        return Ok(Noticees);
    }

    [HttpGet]
    [Route("get-noticeDetail/{id}")]
    public async Task<ActionResult<NoticeDto>> Get(int id)
    {
        var Notice = await _mediator.Send(new GetNoticeDetailRequest { NoticeId = id });
        return Ok(Notice);
    }

    //[HttpPost] 
    //[ProducesResponseType(200)] 
    //[ProducesResponseType(400)]
    //[Route("save-individual-notice")]
    //public async Task<ActionResult<BaseCommandResponse>> SaveIndividualNotice([FromBody] CreateIndividualNoticeListDto Notice)
    //{
    //    var command = new CreateNoticeCommand { NoticeDto = Notice };
    //    var response = await _mediator.Send(command);
    //    return Ok(response);
    //    //  return Ok();
    //}

    [HttpPost]
    [ProducesResponseType(200)]  
    [ProducesResponseType(400)]
    [Route("save-notice")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateNoticeDto Notice)
    {
        var command = new CreateNoticeCommand { NoticeDto = Notice };
        var response = await _mediator.Send(command);
        return Ok(response);
        //  return Ok();
    }



    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-notice/{id}")]
    public async Task<ActionResult> Put([FromBody] NoticeDto Notice)
    {
        var command = new UpdateNoticeCommand { NoticeDto = Notice };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-notice/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteNoticeCommand { NoticeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedClassNoticeBySchool")]
    public async Task<ActionResult<List<NoticeDto>>> GetSelectedNoticeByschool(int baseSchoolNameId)
    {
        var ClassPeriodName = await _mediator.Send(new GetSelectedNoticeBySchoolRequest
        {
            BaseSchoolNameId = baseSchoolNameId, 
        });
        return Ok(ClassPeriodName);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("stop-notices/{id}")]
    public async Task<ActionResult> StopNotices(int id)
    {
        var command = new StopNoticeCommand { NoticeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

}

