using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseTypes;
using SchoolManagement.Application.Features.CourseTypes.Requests.Commands;
using SchoolManagement.Application.Features.CourseTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CourseTypes)]
[ApiController]
[Authorize]
public class CourseTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-courseTypes")]
    public async Task<ActionResult<List<CourseTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CourseTypes = await _mediator.Send(new GetCourseTypeListRequest { QueryParams = queryParams });
        return Ok(CourseTypes);
    }

    

    [HttpGet]
    [Route("get-courseTypeDetail/{id}")]
    public async Task<ActionResult<CourseTypeDto>> Get(int id)
    {
        var CourseType = await _mediator.Send(new GetCourseTypeDetailRequest { CourseTypeId = id });
        return Ok(CourseType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-courseType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseTypeDto CourseType)
    {
        var command = new CreateCourseTypeCommand { CourseTypeDto = CourseType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-courseType/{id}")]
    public async Task<ActionResult> Put([FromBody] CourseTypeDto CourseType)
    {
        var command = new UpdateCourseTypeCommand { CourseTypeDto = CourseType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-courseType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCourseTypeCommand { CourseTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedCourseTypes")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedcoursetype()
    {
        var selectedCourseType = await _mediator.Send(new GetSelectedCourseTypeRequest { });
        return Ok(selectedCourseType);
    }

    [HttpGet]
    [Route("get-selectedCourseTypeForMist")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedcoursetypeForMist()
    {
        var selectedCourseType = await _mediator.Send(new GetSelectedCourseTypeForMistRequest { });
        return Ok(selectedCourseType);
    }
}

