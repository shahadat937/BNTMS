using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.InterServiceMark;
using SchoolManagement.Application.Features.InterServiceMarks.Requests.Commands;
using SchoolManagement.Application.Features.InterServiceMarks.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.InterServiceMark)]
[ApiController]
[Authorize]
public class InterServiceMarkController : ControllerBase
{
    private readonly IMediator _mediator;

    public InterServiceMarkController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-InterServiceMarks")]
    public async Task<ActionResult<List<InterServiceMarkDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var InterServiceMarks = await _mediator.Send(new GetInterServiceMarkListRequest { QueryParams = queryParams });
        return Ok(InterServiceMarks);
    }


    [HttpGet]
    [Route("get-InterServiceMarkDetail/{id}")]
    public async Task<ActionResult<InterServiceMarkDto>> Get(int id)
    {
        var InterServiceMark = await _mediator.Send(new GetInterServiceMarkDetailRequest { InterServiceMarkId = id });
        return Ok(InterServiceMark);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-InterServiceMark")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateInterServiceMarkDto InterServiceMark)
    {
        var command = new CreateInterServiceMarkCommand { InterServiceMarkDto = InterServiceMark };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-interServiceMarklist")]
     
    public async Task<ActionResult<BaseCommandResponse>> SaveInterServiceMarkList([FromForm] InterServiceMarkListDto interServiceMarkListDto)
    {
        var command = new CreateInterServiceMarkListCommand { InterServiceMarkListDto = new InterServiceMarkListDto() };
        var response = await _mediator.Send(command);
        return Ok(response);
        //return Ok();
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-InterServiceMark/{id}")]
    public async Task<ActionResult> Put([FromBody] InterServiceMarkDto InterServiceMark)
    {
        var command = new UpdateInterServiceMarkCommand { InterServiceMarkDto = InterServiceMark };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-InterServiceMark/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteInterServiceMarkCommand { InterServiceMarkId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedInterServiceMarks")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedInterServiceMark()
    {
        var selectedInterServiceMark = await _mediator.Send(new GetSelectedInterServiceMarkRequest { });
        return Ok(selectedInterServiceMark);
    }
    [HttpGet]
    [Route("get-InterServiceMarkListByPno")]
    public async Task<ActionResult<List<InterServiceMarkDto>>> GetInterServiceMarkListByPno( int traineeId)
    {
        var iSMarks = await _mediator.Send(new GetInterServiceMarkListByPnoRequest
        {
            TraineeId = traineeId
        });
        return Ok(iSMarks);
    }
    
}

