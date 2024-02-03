using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.InterServiceCourseDocType;
using SchoolManagement.Application.Features.InterServiceCourseDocTypes.Requests.Commands;
using SchoolManagement.Application.Features.InterServiceCourseDocTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.InterServiceCourseDocType)]
[ApiController]
[Authorize]
public class InterServiceCourseDocTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public InterServiceCourseDocTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-InterServiceCourseDocTypes")]
    public async Task<ActionResult<List<InterServiceCourseDocTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var InterServiceCourseDocTypes = await _mediator.Send(new GetInterServiceCourseDocTypeListRequest { QueryParams = queryParams });
        return Ok(InterServiceCourseDocTypes);
    }



    [HttpGet]
    [Route("get-InterServiceCourseDocTypeDetail/{id}")]
    public async Task<ActionResult<InterServiceCourseDocTypeDto>> Get(int id)
    {
        var InterServiceCourseDocType = await _mediator.Send(new GetInterServiceCourseDocTypeDetailRequest { InterServiceCourseDocTypeId = id });
        return Ok(InterServiceCourseDocType);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-InterServiceCourseDocType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateInterServiceCourseDocTypeDto InterServiceCourseDocType)
    {
        var command = new CreateInterServiceCourseDocTypeCommand { InterServiceCourseDocTypeDto = InterServiceCourseDocType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-InterServiceCourseDocType/{id}")]
    public async Task<ActionResult> Put([FromBody] InterServiceCourseDocTypeDto InterServiceCourseDocType)
    {
        var command = new UpdateInterServiceCourseDocTypeCommand { InterServiceCourseDocTypeDto = InterServiceCourseDocType };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-InterServiceCourseDocType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteInterServiceCourseDocTypeCommand { InterServiceCourseDocTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedInterServiceCourseDocType")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedInterServiceCourseDocType()
    {
        var InterServiceCourseDocType = await _mediator.Send(new GetSelectedInterServiceCourseDocTypeRequest { });
        return Ok(InterServiceCourseDocType);
    }
}

