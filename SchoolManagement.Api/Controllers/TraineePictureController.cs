using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TraineePicture;
using SchoolManagement.Application.Features.TraineePictures.Requests.Commands;
using SchoolManagement.Application.Features.TraineePictures.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TraineePicture)]
[ApiController]
[Authorize]
public class TraineePictureController : ControllerBase
{
    private readonly IMediator _mediator;

    public TraineePictureController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-traineePictures")]
    public async Task<ActionResult<List<TraineePictureDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TraineePictures = await _mediator.Send(new GetTraineePictureListRequest { QueryParams = queryParams });
        return Ok(TraineePictures);
    }

    [HttpGet]
    [Route("get-traineePictureDetail/{id}")]
    public async Task<ActionResult<TraineePictureDto>> Get(int id)
    {
        var TraineePicture = await _mediator.Send(new GetTraineePictureDetailRequest { TraineePictureId = id });
        return Ok(TraineePicture);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-traineePicture")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTraineePictureDto TraineePicture)
    {
        var command = new CreateTraineePictureCommand { TraineePictureDto = TraineePicture };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-traineePicture/{id}")]
    public async Task<ActionResult> Put([FromBody] TraineePictureDto TraineePicture)
    {
        var command = new UpdateTraineePictureCommand { TraineePictureDto = TraineePicture };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-traineePicture/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTraineePictureCommand { TraineePictureId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}

