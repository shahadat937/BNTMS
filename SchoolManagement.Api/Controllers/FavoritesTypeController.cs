using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.FavoritesType;
using SchoolManagement.Application.Features.FavoritesTypes.Requests.Commands;
using SchoolManagement.Application.Features.FavoritesTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.FavoritesType)]
[ApiController]
[Authorize]
public class FavoritesTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public FavoritesTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-favoritesTypes")]
    public async Task<ActionResult<List<FavoritesTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var FavoritesTypes = await _mediator.Send(new GetFavoritesTypeListRequest { QueryParams = queryParams });
        return Ok(FavoritesTypes);
    }


    [HttpGet]
    [Route("get-favoritesTypeDetail/{id}")]
    public async Task<ActionResult<FavoritesTypeDto>> Get(int id)
    {
        var FavoritesType = await _mediator.Send(new GetFavoritesTypeDetailRequest { FavoritesTypeId = id });
        return Ok(FavoritesType);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("seve-favoritesType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateFavoritesTypeDto FavoritesType)
    {
        var command = new CreateFavoritesTypeCommand { FavoritesTypeDto = FavoritesType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-favoritesType/{id}")]
    public async Task<ActionResult> Put([FromBody] FavoritesTypeDto FavoritesType)
    {
        var command = new UpdateFavoritesTypeCommand { FavoritesTypeDto = FavoritesType };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-favoritesType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteFavoritesTypeCommand { FavoritesTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [Route("get-selectedFavoritesType")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedFavoritesType()
    {
        var favorites = await _mediator.Send(new GetSelectedFavoritesTypeRequest { });
        return Ok(favorites);
    }

}

