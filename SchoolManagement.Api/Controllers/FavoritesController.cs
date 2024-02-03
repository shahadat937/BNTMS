using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.Favorites;
using SchoolManagement.Application.Features.Favorite.Requests.Commands;
using SchoolManagement.Application.Features.Favorite.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Favorites)]
[ApiController]
[Authorize]
public class FavoritesController : ControllerBase
{
    private readonly IMediator _mediator;

    public FavoritesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-favorites")]
    public async Task<ActionResult<List<FavoritesDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var favorites = await _mediator.Send(new GetFavoritesListRequest { QueryParams = queryParams });
        return Ok(favorites);
    }

    [HttpGet]
    [Route("get-favoritesDetail/{id}")]
    public async Task<ActionResult<FavoritesDto>> Get(int id)
    {
        var favorites = await _mediator.Send(new GetFavoritesDetailRequest { Id = id });
        return Ok(favorites);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-favorites")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateFavoritesDto Favorites)
    {
        var command = new CreateFavoritesCommand { FavoritesDto = Favorites };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-favorites/{id}")]
    public async Task<ActionResult> Put([FromBody] FavoritesDto Favorites)
    {
        var command = new UpdateFavoritesCommand { FavoritesDto = Favorites };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-favorites/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteFavoritesCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [Route("get-listByTrainee")]
    public async Task<ActionResult<List<FavoritesDto>>> getdatabytraineeid(int Traineeid)
    {
        var Favorites = await _mediator.Send(new GetFavoritesListByTraineeRequest { Traineeid = Traineeid });
        return Ok(Favorites);
    }
}

