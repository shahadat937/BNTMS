using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.GameSport;
using SchoolManagement.Application.Features.GameSports.Requests.Commands;
using SchoolManagement.Application.Features.GameSports.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.GameSport)]
[ApiController]
[Authorize]
public class GameSportController : ControllerBase
{
    private readonly IMediator _mediator;

    public GameSportController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-gameSports")]
    public async Task<ActionResult<List<GameSportDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var GameSports = await _mediator.Send(new GetGameSportListRequest { QueryParams = queryParams });
        return Ok(GameSports);
    }


    [HttpGet]
    [Route("get-gameSportDetail/{id}")]
    public async Task<ActionResult<GameSportDto>> Get(int id)
    {
        var GameSports = await _mediator.Send(new GetGameSportDetailRequest { GameSportId = id });
        return Ok(GameSports);
    }



    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-gameSport")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateGameSportDto GameSport)
    {
        var command = new CreateGameSportCommand { GameSportDto = GameSport };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-gameSport/{id}")]
    public async Task<ActionResult> Put([FromBody] GameSportDto GameSport)
    {
        var command = new UpdateGameSportCommand { GameSportDto = GameSport };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-gameSport/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteGameSportCommand { GameSportId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<GameSportDto>>> getdatabytraineeid(int Traineeid)
    {
        var GameSports = await _mediator.Send(new GetGameSportListByTraineeRequest { Traineeid = Traineeid });
        return Ok(GameSports);
    }
}

