using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ForeignTrainingCourseReport;
using SchoolManagement.Application.Features.ForeignTrainingCourseReports.Requests.Commands;
using SchoolManagement.Application.Features.ForeignTrainingCourseReports.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ForeignTrainingCourseReport)]
[ApiController]
[Authorize]
public class ForeignTrainingCourseReportController : ControllerBase
{
    private readonly IMediator _mediator;

    public ForeignTrainingCourseReportController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-ForeignTrainingCourseReports")]
    public async Task<ActionResult<List<ForeignTrainingCourseReportDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ForeignTrainingCourseReports = await _mediator.Send(new GetForeignTrainingCourseReportListRequest { QueryParams = queryParams });
        return Ok(ForeignTrainingCourseReports);
    }



    [HttpGet]
    [Route("get-ForeignTrainingCourseReportsByStudent")]
    public async Task<ActionResult<List<ForeignTrainingCourseReportDto>>> Get([FromQuery] QueryParams queryParams, int traineeId, int courseDurationId)
    {
        var ForeignTrainingCourseReports = await _mediator.Send(new GetForeignTrainingReportByStudentListRequest
        { 
            QueryParams = queryParams,
            TraineeId = traineeId,
            CourseDurationId = courseDurationId
        
        });
        return Ok(ForeignTrainingCourseReports);
    }




    [HttpGet]
    [Route("get-ForeignTrainingCourseReportDetail/{id}")]
    public async Task<ActionResult<ForeignTrainingCourseReportDto>> Get(int id)
    {
        var ForeignTrainingCourseReport = await _mediator.Send(new GetForeignTrainingCourseReportDetailRequest { ForeignTrainingCourseReportid = id });
        return Ok(ForeignTrainingCourseReport);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-ForeignTrainingCourseReport")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateForeignTrainingCourseReportDto ForeignTrainingCourseReport)
    {
        var command = new CreateForeignTrainingCourseReportCommand { ForeignTrainingCourseReportDto = ForeignTrainingCourseReport };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-ForeignTrainingCourseReport/{id}")]
    public async Task<ActionResult> Put([FromBody] ForeignTrainingCourseReportDto ForeignTrainingCourseReport)
    {
        var command = new UpdateForeignTrainingCourseReportCommand { ForeignTrainingCourseReportDto = ForeignTrainingCourseReport };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-ForeignTrainingCourseReport/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteForeignTrainingCourseReportCommand { ForeignTrainingCourseReportid = id };
        await _mediator.Send(command);
        return NoContent();
    }

    
}

