using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaCurriculumUpdate;
using SchoolManagement.Application.Features.BnaCurriculumUpdates.Requests.Commands;
using SchoolManagement.Application.Features.BnaCurriculumUpdates.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaCurriculumUpdate)]
[ApiController]
[Authorize]
public class BnaCurriculumUpdateController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaCurriculumUpdateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaCurriculumUpdates")]
    public async Task<ActionResult<List<BnaCurriculumUpdateDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaCurriculumUpdates = await _mediator.Send(new GetBnaCurriculumUpdateListRequest { QueryParams = queryParams });
        return Ok(BnaCurriculumUpdates);
    }

    [HttpGet]
    [Route("get-bnaCurriculumUpdateDetail/{id}")]
    public async Task<ActionResult<BnaCurriculumUpdateDto>> Get(int id)
    {
        var BnaCurriculumUpdate = await _mediator.Send(new GetBnaCurriculumUpdateDetailRequest { BnaCurriculumUpdateId = id });
        return Ok(BnaCurriculumUpdate);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaCurriculumUpdate")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaCurriculumUpdateDto BnaCurriculumUpdate)
    {
        var command = new CreateBnaCurriculumUpdateCommand { BnaCurriculumUpdateDto = BnaCurriculumUpdate };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaCurriculumUpdate/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaCurriculumUpdateDto BnaCurriculumUpdate)
    {
        var command = new UpdateBnaCurriculumUpdateCommand { BnaCurriculumUpdateDto = BnaCurriculumUpdate };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaCurriculumUpdate/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaCurriculumUpdateCommand { BnaCurriculumUpdateId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

