using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Board;
using SchoolManagement.Application.Features.Boards.Requests.Commands;
using SchoolManagement.Application.Features.Boards.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Board)]
[ApiController]
[Authorize]
public class BoardController : ControllerBase
{
    private readonly IMediator _mediator;

    public BoardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-boards")]
    public async Task<ActionResult<List<BoardDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Boards = await _mediator.Send(new GetBoardListRequest { QueryParams = queryParams });
        return Ok(Boards);
    }

    

    [HttpGet]
    [Route("get-boardDetail/{id}")]
    public async Task<ActionResult<BoardDto>> Get(int id)
    {
        var Boards = await _mediator.Send(new GetBoardDetailRequest { BoardId = id });
        return Ok(Boards);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-board")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBoardDto Board)
    {
        var command = new CreateBoardCommand { BoardDto = Board };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-board/{id}")]
    public async Task<ActionResult> Put([FromBody] BoardDto Board)
    {
        var command = new UpdateBoardCommand { BoardDto = Board };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-board/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBoardCommand { BoardId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data

    [HttpGet]
    [Route("get-selectedBoards")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBoard()
    {
        var selectedBoard = await _mediator.Send(new GetSelectedBoardRequest { });
        return Ok(selectedBoard);
    }
}

