using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Department;
using SchoolManagement.Application.Features.Departments.Requests.Commands;
using SchoolManagement.Application.Features.Departments.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Department)]
[ApiController]
[Authorize]
public class DepartmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DepartmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-Departments")]
    public async Task<ActionResult<List<DepartmentDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Departments = await _mediator.Send(new GetDepartmentListRequest { QueryParams = queryParams });
        return Ok(Departments);
    }

    [HttpGet]
    [Route("get-DepartmentDetail/{id}")]
    public async Task<ActionResult<DepartmentDto>> Get(int id)
    {
        var Department = await _mediator.Send(new GetDepartmentDetailRequest { DepartmentId = id });
        return Ok(Department);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Department")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDepartmentDto Department)
    {
        var command = new CreateDepartmentCommand { DepartmentDto = Department };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Department/{id}")]
    public async Task<ActionResult> Put([FromBody] DepartmentDto Department)
    {
        var command = new UpdateDepartmentCommand { DepartmentDto = Department };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Department/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDepartmentCommand { DepartmentId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedDepartments")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDepartment()
    {
        var Department = await _mediator.Send(new GetSelectedDepartmentRequest { });
        return Ok(Department);
    }
}

