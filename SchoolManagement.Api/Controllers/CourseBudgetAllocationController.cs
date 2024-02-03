using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseBudgetAllocation;
using SchoolManagement.Application.Features.Bulletins.Requests.Commands;
using SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Commands;
using SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CourseBudgetAllocation)]
[ApiController]
[Authorize]
public class CourseBudgetAllocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseBudgetAllocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-courseBudgetAllocations")]
    public async Task<ActionResult<List<CourseBudgetAllocationDto>>> Get([FromQuery] QueryParams queryParams,int courseNameId, int traineeId)
    {
        var CourseBudgetAllocations = await _mediator.Send(new GetCourseBudgetAllocationListRequest 
        { 
            QueryParams = queryParams,
            CourseNameId =courseNameId,
            TraineeId = traineeId
        });
        return Ok(CourseBudgetAllocations);
    }
     
    [HttpGet] 
    [Route("get-scheduleInstallmentListByCourseDurationId")]
    public async Task<ActionResult<List<CourseBudgetAllocationDto>>> GetScheduleInstallmentListByCourseDurationId([FromQuery] QueryParams queryParams, int courseDurationId)
    {
        var CourseBudgetAllocations = await _mediator.Send(new GetCourseBudgetAllocationsListByPaymentTypeIdAndCourseDurationIdRequest
        {
            QueryParams = queryParams,
            CourseDurationId = courseDurationId
        });
        return Ok(CourseBudgetAllocations);
    }



    [HttpGet]
    [Route("get-courseBudgetAllocationDetail/{id}")]
    public async Task<ActionResult<CourseBudgetAllocationDto>> Get(int id)
    {
        var CourseBudgetAllocations = await _mediator.Send(new GetCourseBudgetAllocationDetailRequest { CourseBudgetAllocationId = id });
        return Ok(CourseBudgetAllocations);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-courseBudgetAllocation")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseBudgetAllocationDto CourseBudgetAllocation)
    {
        var command = new CreateCourseBudgetAllocationCommand { CourseBudgetAllocationDto = CourseBudgetAllocation };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-courseBudgetAllocation/{id}")]
    public async Task<ActionResult> Put([FromBody] CourseBudgetAllocationDto CourseBudgetAllocation)
    {
        var command = new UpdateCourseBudgetAllocationCommand { CourseBudgetAllocationDto = CourseBudgetAllocation };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-courseBudgetAllocation/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCourseBudgetAllocationCommand { CourseBudgetAllocationId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data

    [HttpGet]
    [Route("get-selectedCourseBudgetAllocations")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCourseBudgetAllocation()
    {
        var selectedCourseBudgetAllocation = await _mediator.Send(new GetSelectedCourseBudgetAllocationRequest { });
        return Ok(selectedCourseBudgetAllocation);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType] 
    [Route("change-courseBudgetAllocationStatus")]
    public async Task<ActionResult> DeactiveCourseBudgetAllocation(int courseBudgetAllocationId, int status)
    {
        var command = new ChangeCourseBudgetAllocationStatusCommand
        {
            CourseBudgetAllocationId = courseBudgetAllocationId,
            Status = status 
        };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType] 
    [Route("change-receivedStatus")]
    public async Task<ActionResult> ChangeReceivedStatus(int courseBudgetAllocationId, int receivedstatus)
    {
        var command = new ChangeReceivedStatusCommand
        {
            CourseBudgetAllocationId = courseBudgetAllocationId,
            ReceivedStatus = receivedstatus 
        };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("accepted-CourseBudgetAllocation/{id}")]
    public async Task<ActionResult> AcceptedCourseBudgetAllocation(int id)
    {
        var command = new AcceptedCourseBudgetAllocationCommand { CourseBudgetAllocationId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

