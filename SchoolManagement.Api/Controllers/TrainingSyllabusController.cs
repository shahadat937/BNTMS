using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TrainingSyllabus;
using SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Commands;
using SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TrainingSyllabus)]
[ApiController]
[Authorize]
public class TrainingSyllabusController : ControllerBase
{
    private readonly IMediator _mediator;

    public TrainingSyllabusController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-trainingSyllabuses")]
    public async Task<ActionResult<List<TrainingSyllabusDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TrainingSyllabuss = await _mediator.Send(new GetTrainingSyllabusListRequest { QueryParams = queryParams });
        return Ok(TrainingSyllabuss);
    }



    [HttpGet]
    [Route("get-trainingSyllabusDetail/{id}")]
    public async Task<ActionResult<TrainingSyllabusDto>> Get(int id)
    {
        var TrainingSyllabus = await _mediator.Send(new GetTrainingSyllabusDetailRequest { TrainingSyllabusId = id });
        return Ok(TrainingSyllabus);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-trainingSyllabus")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTrainingSyllabusDto TrainingSyllabus)
    {
        var command = new CreateTrainingSyllabusCommand { TrainingSyllabusDto = TrainingSyllabus };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-trainingSyllabus/{id}")]
    public async Task<ActionResult> Put([FromBody] TrainingSyllabusDto TrainingSyllabus)
    {
        var command = new UpdateTrainingSyllabusCommand { TrainingSyllabusDto = TrainingSyllabus };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-trainingSyllabus/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTrainingSyllabusCommand { TrainingSyllabusId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedTrainingSyllabus")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedTrainingSyllabus()
    {
        var TrainingSyllabus = await _mediator.Send(new GetSelectedTrainingSyllabusRequest { });
        return Ok(TrainingSyllabus);
    }
    [HttpGet]
    [Route("get-trainingSyllabusListBySchoolIdCourseNameIdAndSubjectNameId")]
    public async Task<ActionResult<List<TrainingSyllabusDto>>> GetTrainingSyllabusListBySchoolIdCourseNameIdAndSubjectNameId(int baseSchoolNameId, int courseNameId, int bnaSubjectNameId)
    {
        var familyInfos = await _mediator.Send(new GetTrainingSyllabusListBySchoolIdCourseNameIdAndSubjectNameIdRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(familyInfos);
    }

    [HttpGet]
    [Route("get-trainingSyllabusListByParamsFromSpRequest")]

    public async Task<ActionResult> GetTrainingSyllabusListByParamsFromSpRequest(int baseSchoolNameId, int courseNameId, int bnaSubjectNameId)
    {
        var TrainingSyllabuses = await _mediator.Send(new GetTrainingSyllabusListByParamsFromSpRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId,
            BnaSubjectNameId = bnaSubjectNameId
        });
        return Ok(TrainingSyllabuses);
    }
}

