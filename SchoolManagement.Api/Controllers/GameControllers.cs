using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Games;
using SchoolManagement.Application.Features.Games.Requests.Commands;
using SchoolManagement.Application.Features.Games.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Game)]
[ApiController]
[Authorize]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;

    public GameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-games")]
    public async Task<ActionResult<List<GameDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Gamees = await _mediator.Send(new GetGameListRequest { QueryParams = queryParams });
        return Ok(Gamees);
    }


    [HttpGet]
    [Route("get-gameDetail/{id}")]
    public async Task<ActionResult<GameDto>> Get(int id)
    {
        var Game = await _mediator.Send(new GetGameDetailRequest { Id = id });
        return Ok(Game);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-game")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateGameDto Game)
    {
        var command = new CreateGameCommand { GameDto = Game };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-game/{id}")]
    public async Task<ActionResult> Put([FromBody] GameDto Game)
    {
        var command = new UpdateGameCommand { GameDto = Game };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-game/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteGameCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedGame")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedGame()
    {
        var codeValueByType = await _mediator.Send(new GetSelectedGameRequest { });
        return Ok(codeValueByType);
    }

}

