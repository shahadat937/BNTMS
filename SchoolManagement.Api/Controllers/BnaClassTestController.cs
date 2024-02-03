using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaClassTest;
using SchoolManagement.Application.Features.BnaClassTests.Requests.Commands;
using SchoolManagement.Application.Features.BnaClassTests.Requests.Queries;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaClassTest)]
[ApiController]
[Authorize]
public class BnaClassTestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaClassTestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaClassTests")]
    public async Task<ActionResult<List<BnaClassTestDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaClassTests = await _mediator.Send(new GetBnaClassTestListRequest { QueryParams = queryParams });
        return Ok(BnaClassTests);
    }

    [HttpGet]
    [Route("get-bnaClassTestDetail/{id}")]
    public async Task<ActionResult<BnaClassTestDto>> Get(int id)
    {
        var BnaClassTest = await _mediator.Send(new GetBnaClassTestDetailRequest { BnaClassTestId = id });
        return Ok(BnaClassTest);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaClassTest")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaClassTestDto BnaClassTest)
    {
        var command = new CreateBnaClassTestCommand { BnaClassTestDto = BnaClassTest };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaClassTest/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaClassTestDto BnaClassTest)
    {
        var command = new UpdateBnaClassTestCommand { BnaClassTestDto = BnaClassTest };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaClassTest/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaClassTestCommand { BnaClassTestId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    //[HttpGet]
    //[Route("get-selectedBnaClassTests")]
    //public async Task<ActionResult<List<SelectedModel>>> GetSelectedBnaClassTest()
    //{
    //    var BnaClassTest = await _mediator.Send(new GetSelectedBnaClassTestRequest { });
    //    return Ok(BnaClassTest);
    //}
}

