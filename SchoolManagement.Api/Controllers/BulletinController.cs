using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Bulletin;
using SchoolManagement.Application.Features.Bulletins.Requests.Commands;
using SchoolManagement.Application.Features.Bulletins.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Bulletin)]
[ApiController]
[Authorize]
public class BulletinController : ControllerBase
{
    private readonly IMediator _mediator;

    public BulletinController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bulletins")]
    public async Task<ActionResult<List<BulletinDto>>> Get([FromQuery] QueryParams queryParams,int baseSchoolNameId)
    {
        var Bulletines = await _mediator.Send(new GetBulletinListRequest { 
            QueryParams = queryParams,
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(Bulletines);
    }

    [HttpGet]
    [Route("get-bulletinDetail/{id}")]
    public async Task<ActionResult<BulletinDto>> Get(int id)
    {
        var Bulletin = await _mediator.Send(new GetBulletinDetailRequest { BulletinId = id });
        return Ok(Bulletin);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bulletin")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBulletinDto Bulletin)
    {
        var command = new CreateBulletinCommand { BulletinDto = Bulletin };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bulletin/{id}")]
    public async Task<ActionResult> Put([FromBody] BulletinDto Bulletin)
    {
        var command = new UpdateBulletinCommand { BulletinDto = Bulletin };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bulletin/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBulletinCommand { BulletinId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-activeBulletinList")]
    public async Task<ActionResult> GetActiveBulletinList(int baseSchoolNameId)
    {
        var bulletinList = await _mediator.Send(new GetBulletinListBySpRequest
        {
            BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(bulletinList);
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("change-bulletinStatus")]
    public async Task<ActionResult> ActiveCoursePlan(int bulletinId, int status)
    {
        var command = new ChangeBulletinStatusCommand { 
            BulletinId = bulletinId,
            Status = status
        };
        await _mediator.Send(command);
        return NoContent();
    }

}

