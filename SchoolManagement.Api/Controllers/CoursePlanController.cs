using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CoursePlan;
using SchoolManagement.Application.Features.CoursePlans.Requests.Commands;
using SchoolManagement.Application.Features.CoursePlans.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CoursePlan)]
[ApiController]
[Authorize]
public class CoursePlanController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoursePlanController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-coursePlans")]
    public async Task<ActionResult<List<CoursePlanDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CoursePlans = await _mediator.Send(new GetCoursePlanListRequest { QueryParams = queryParams });
        return Ok(CoursePlans);
    }



    [HttpGet]
    [Route("get-coursePlanDetail/{id}")]
    public async Task<ActionResult<CoursePlanDto>> Get(int id)
    {
        var CoursePlan = await _mediator.Send(new GetCoursePlanDetailRequest { CoursePlanCreateId = id });
        return Ok(CoursePlan);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-coursePlan")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCoursePlanDto CoursePlan)
    {
        var command = new CreateCoursePlanCommand { CoursePlanDto = CoursePlan };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-coursePlan/{id}")]
    public async Task<ActionResult> Put([FromBody] CoursePlanDto CoursePlan)
    {
        var command = new UpdateCoursePlanCommand { CoursePlanDto = CoursePlan };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-coursePlan/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCoursePlanCommand { CoursePlanCreateId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data

    [HttpGet]
    [Route("get-selectedCoursePlans")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCoursePlan()
    {
        var CoursePlanName = await _mediator.Send(new GetSelectedCoursePlanRequest { });
        return Ok(CoursePlanName);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)] 
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("deactive-coursePlan/{id}")]
    public async Task<ActionResult> DeActiveCoursePlan(int id)
    {
        var command = new DeActivateCoursePlanCommand { CoursePlanCreateId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("active-coursePlan/{id}")]
    public async Task<ActionResult> ActiveCoursePlan(int id)
    {
        var command = new ActivateCoursePlanCommand { CoursePlanCreateId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

