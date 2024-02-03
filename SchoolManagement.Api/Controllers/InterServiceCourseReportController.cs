using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.InterServiceCourseReport;
using SchoolManagement.Application.Features.InterServiceCourseReports.Requests.Commands;
using SchoolManagement.Application.Features.InterServiceCourseReports.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.InterServiceCourseReport)]
[ApiController]
[Authorize]
public class InterServiceCourseReportController : ControllerBase
{
    private readonly IMediator _mediator;

    public InterServiceCourseReportController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-InterServiceCourseReports")]
    public async Task<ActionResult<List<InterServiceCourseReportDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var InterServiceCourseReports = await _mediator.Send(new GetInterServiceCourseReportListRequest { QueryParams = queryParams });
        return Ok(InterServiceCourseReports);
    }



    [HttpGet]
    [Route("get-InterServiceCourseReportsByStudent")]
    public async Task<ActionResult<List<InterServiceCourseReportDto>>> Get([FromQuery] QueryParams queryParams, int traineeId, int courseDurationId)
    {
        var InterServiceCourseReports = await _mediator.Send(new GetInterServiceReportByStudentListRequest
        { 
            QueryParams = queryParams,
            TraineeId = traineeId,
            CourseDurationId = courseDurationId
        
        });
        return Ok(InterServiceCourseReports);
    }




    [HttpGet]
    [Route("get-InterServiceCourseReportDetail/{id}")]
    public async Task<ActionResult<InterServiceCourseReportDto>> Get(int id)
    {
        var InterServiceCourseReport = await _mediator.Send(new GetInterServiceCourseReportDetailRequest { InterServiceCourseReportid = id });
        return Ok(InterServiceCourseReport);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-InterServiceCourseReport")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateInterServiceCourseReportDto InterServiceCourseReport)
    {
        var command = new CreateInterServiceCourseReportCommand { InterServiceCourseReportDto = InterServiceCourseReport };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-InterServiceCourseReport/{id}")]
    public async Task<ActionResult> Put([FromBody] InterServiceCourseReportDto InterServiceCourseReport)
    {
        var command = new UpdateInterServiceCourseReportCommand { InterServiceCourseReportDto = InterServiceCourseReport };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-InterServiceCourseReport/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteInterServiceCourseReportCommand { InterServiceCourseReportid = id };
        await _mediator.Send(command);
        return NoContent();
    }

    
}

