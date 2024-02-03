using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ForeignCourseDocType;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.ForeignCourseDocTypes.Requests.Commands;
using SchoolManagement.Application.Features.ForeignCourseDocTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ForeignCourseDocType)]
[ApiController]
[Authorize]
public class ForeignCourseDocTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ForeignCourseDocTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-foreignCourseDocTypes")]
    public async Task<ActionResult<List<ForeignCourseDocTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ForeignCourseDocTypes = await _mediator.Send(new GetForeignCourseDocTypeListRequest { QueryParams = queryParams });
        return Ok(ForeignCourseDocTypes);
    }

    

    [HttpGet]
    [Route("get-foreignCourseDocTypeDetail/{id}")]
    public async Task<ActionResult<ForeignCourseDocTypeDto>> Get(int id)
    {
        var ForeignCourseDocType = await _mediator.Send(new GetForeignCourseDocTypeDetailRequest { ForeignCourseDocTypeId = id });
        return Ok(ForeignCourseDocType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-foreignCourseDocType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateForeignCourseDocTypeDto ForeignCourseDocType)
    {
        var command = new CreateForeignCourseDocTypeCommand { ForeignCourseDocTypeDto = ForeignCourseDocType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-foreignCourseDocType/{id}")]
    public async Task<ActionResult> Put([FromBody] ForeignCourseDocTypeDto ForeignCourseDocType)
    {
        var command = new UpdateForeignCourseDocTypeCommand { ForeignCourseDocTypeDto = ForeignCourseDocType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-foreignCourseDocType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteForeignCourseDocTypeCommand { ForeignCourseDocTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedForeignCourseDocTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedForeignCourseDocType()
    {
        var ForeignCourseDocType = await _mediator.Send(new GetSelectedForeignCourseDocTypeRequest { });
        return Ok(ForeignCourseDocType);
    }
}

