using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseModule;
using SchoolManagement.Application.Features.CourseModules.Requests.Commands;
using SchoolManagement.Application.Features.CourseModules.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CourseModule)]
[ApiController]
[Authorize]
public class CourseModuleController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseModuleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-courseModules")]
    public async Task<ActionResult<List<CourseModuleDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CourseModules = await _mediator.Send(new GetCourseModuleListRequest { QueryParams = queryParams });
        return Ok(CourseModules);
    }

    

    [HttpGet]
    [Route("get-courseModuleDetail/{id}")]
    public async Task<ActionResult<CourseModuleDto>> Get(int id)
    {
        var CourseModule = await _mediator.Send(new GetCourseModuleDetailRequest { CourseModuleId = id });
        return Ok(CourseModule);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-courseModule")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseModuleDto CourseModule)
    {
        var command = new CreateCourseModuleCommand { CourseModuleDto = CourseModule };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-courseModule/{id}")]
    public async Task<ActionResult> Put([FromBody] CourseModuleDto CourseModule)
    {
        var command = new UpdateCourseModuleCommand { CourseModuleDto = CourseModule };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-courseModule/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCourseModuleCommand { CourseModuleId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedCourseModules")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseModule()
    {
        var CourseModuleValue = await _mediator.Send(new GetSelectedCourseModuleRequest { });
        return Ok(CourseModuleValue);
    }

    [HttpGet]
    [Route("get-selectedCourseModulesByBaseSchoolNameIdAndCourseNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseModuleByBaseSchoolNameIdAndCourseNameId(int baseSchoolNameId,int courseNameId)
    {
        var CourseModuleValue = await _mediator.Send(new GetSelectedCourseModuleByBaseNameIdAndCourseNameIdRequest
        { 
         BaseSchoolNameId = baseSchoolNameId,
         CourseNameId = courseNameId,
        }); 
        return Ok(CourseModuleValue);
    }

    [HttpGet]
    [Route("get-selectedCourseModuleByBaseSchoolNameId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseModuleByBaseSchoolNameId(int baseSchoolNameId)
    {
        var courseModuleByBaseSchoolName = await _mediator.Send(new GetSelectedCourseModuleByBaseSchoolNameIdRequest { BaseSchoolNameId = baseSchoolNameId });
        return Ok(courseModuleByBaseSchoolName);
    }

    [HttpGet]
    [Route("get-CourseModuleListByBaseSchoolNameIdAndCourseNameId")] 
    public async Task<ActionResult<List<CourseModuleDto>>> GetCourseModuleListByBaseSchoolNameIdandCourseNameId(int baseSchoolNameId,int courseNameId)
    {
        var courseModules = await _mediator.Send(new GetCourseModuleListByBaseNameIdAndCourseNameIdRequest
        { 
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId =courseNameId
        });
        return Ok(courseModules); 
    }

    
}

