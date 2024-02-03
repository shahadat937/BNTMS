using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ClassType;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.ClassTypes.Requests.Commands;
using SchoolManagement.Application.Features.ClassTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ClassType)]
[ApiController]
[Authorize]
public class ClassTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClassTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-classTypes")]
    public async Task<ActionResult<List<ClassTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ClassTypes = await _mediator.Send(new GetClassTypeListRequest { QueryParams = queryParams });
        return Ok(ClassTypes);
    }

    

    [HttpGet]
    [Route("get-classTypeDetail/{id}")]
    public async Task<ActionResult<ClassTypeDto>> Get(int id)
    {
        var ClassType = await _mediator.Send(new GetClassTypeDetailRequest { ClassTypeId = id });
        return Ok(ClassType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-classType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateClassTypeDto ClassType)
    {
        var command = new CreateClassTypeCommand { ClassTypeDto = ClassType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-classType/{id}")]
    public async Task<ActionResult> Put([FromBody] ClassTypeDto ClassType)
    {
        var command = new UpdateClassTypeCommand { ClassTypeDto = ClassType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-classType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteClassTypeCommand { ClassTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedClassTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedClassType()
    {
        var ClassType = await _mediator.Send(new GetSelectedClassTypeRequest { });
        return Ok(ClassType);
    }
     
    [HttpGet]
    [Route("get-selectedClassTypeByParameterRequestFromClassRoutine")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedClassType(int baseSchoolNameId, int courseNameId)
    {
        var ClassPeriodName = await _mediator.Send(new GetSelectedClassTypeByParametersFromClassRoutineRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(ClassPeriodName);
    }
}

