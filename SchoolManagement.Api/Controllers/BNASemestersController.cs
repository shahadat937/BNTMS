using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaSemester;
using SchoolManagement.Application.Features.BnaSemesters.Requests.Commands;
using SchoolManagement.Application.Features.BnaSemesters.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaSemester)]
[ApiController]
[Authorize]
public class BnaSemestersController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaSemestersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaSemesters")]
    public async Task<ActionResult<List<BnaSemesterDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaSemesters = await _mediator.Send(new GetBnaSemesterListRequest { QueryParams = queryParams });
        return Ok(BnaSemesters);
    }

    [HttpGet]
    [Route("get-bnaSemesterDetail/{id}")]
    public async Task<ActionResult<BnaSemesterDto>> Get(int id)
    {
        var BnaSemester = await _mediator.Send(new GetBnaSemesterDetailRequest { BnaSemesterId = id });
        return Ok(BnaSemester);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaSemester")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaSemesterDto BnaSemester)
    {
        var command = new CreateBnaSemesterCommand { BnaSemesterDto = BnaSemester };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaSemester/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaSemesterDto BnaSemester)
    {
        var command = new UpdateBnaSemesterCommand { BnaSemesterDto = BnaSemester };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaSemester/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaSemesterCommand { BnaSemesterId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedBnaSemesters")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBnaSemester()
    {
        var BnaSemester = await _mediator.Send(new GetSelectedBnaSemesterRequest { });
        return Ok(BnaSemester);
    }
}

