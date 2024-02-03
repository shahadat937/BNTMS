using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.IndividualNotice;
using SchoolManagement.Application.DTOs.IndividualNotices;
using SchoolManagement.Application.Features.IndividualNotices.Requests.Commands;
using SchoolManagement.Application.Features.IndividualNotices.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.IndividualNotice)]
[ApiController]
[Authorize]
public class IndividualNoticeController : ControllerBase
{
    private readonly IMediator _mediator;

    public IndividualNoticeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-individualNotices")]
    public async Task<ActionResult<List<IndividualNoticeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var IndividualNoticees = await _mediator.Send(new GetIndividualNoticeListRequest { QueryParams = queryParams });
        return Ok(IndividualNoticees);
    }

    [HttpGet]
    [Route("get-individualNoticeDetail/{id}")]
    public async Task<ActionResult<IndividualNoticeDto>> Get(int id)
    {
        var IndividualNotice = await _mediator.Send(new GetIndividualNoticeDetailRequest { IndividualNoticeId = id });
        return Ok(IndividualNotice);
    }

    //[HttpPost]
    //[ProducesResponseType(200)]
    //[ProducesResponseType(400)]
    //[Route("save-individual-notice")]
    //public async Task<ActionResult<BaseCommandResponse>> SaveIndividualNotice([FromBody] CreateIndividualNoticeListDto Notice)
    //{
    //    var command = new CreateIndividualNoticeCommand { IndividualNoticeDto = Notice };
    //    var response = await _mediator.Send(command);
    //    return Ok(response);
    //}

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-individualNotice")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateIndividualNoticeListDto IndividualNotice)
    {
        var command = new CreateIndividualNoticeCommand { IndividualNoticeDto = IndividualNotice };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-individualNotice/{id}")]
    public async Task<ActionResult> Put([FromBody] IndividualNoticeDto IndividualNotice)
    {
        var command = new UpdateIndividualNoticeCommand { IndividualNoticeDto = IndividualNotice };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-individualNotice/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteIndividualNoticeCommand { IndividualNoticeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedClassIndividualNoticeBySchool")]
    public async Task<ActionResult<List<IndividualNoticeDto>>> GetSelectedIndividualNoticeByschool(int baseSchoolNameId)
    {
        var ClassPeriodName = await _mediator.Send(new GetSelectedIndividualNoticeBySchoolRequest
        {
            BaseSchoolNameId = baseSchoolNameId, 
        });
        return Ok(ClassPeriodName);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("stop-individualNotices/{id}")]
    public async Task<ActionResult> StopIndividualNotices(int id)
    {
        var command = new StopIndividualNoticeCommand { IndividualNoticeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

}

