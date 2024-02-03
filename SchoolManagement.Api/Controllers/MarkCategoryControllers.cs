using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MarkCategory;
using SchoolManagement.Application.Features.MarkCategorys.Requests.Commands;
using SchoolManagement.Application.Features.MarkCategorys.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.MarkCategory)]
[ApiController]
[Authorize]
public class MarkCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public MarkCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-MarkCategorys")]
    public async Task<ActionResult<List<MarkCategoryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MarkCategorye = await _mediator.Send(new GetMarkCategoryListRequest { QueryParams = queryParams });
        return Ok(MarkCategorye);
    }

    [HttpGet]
    [Route("get-MarkCategorydetail/{id}")]
    public async Task<ActionResult<MarkCategoryDto>> Get(int id)
    {
        var MarkCategory = await _mediator.Send(new GetMarkCategoryDetailRequest { Id = id });
        return Ok(MarkCategory);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-MarkCategory")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMarkCategoryDto MarkCategory)
    {
        var command = new CreateMarkCategoryCommand { MarkCategoryDto = MarkCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-MarkCategory/{id}")]
    public async Task<ActionResult> Put([FromBody] MarkCategoryDto MarkCategory)
    {
        var command = new UpdateMarkCategoryCommand { MarkCategoryDto = MarkCategory };
        await _mediator.Send(command);
        return NoContent(); 
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-MarkCategory/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMarkCategoryCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedMarkCategorys")] 
    public async Task<ActionResult<List<SelectedModel>>> getselectedmaritialstatus()
    {
        var relationType = await _mediator.Send(new GetSelectedMarkCategoryRequest { });
        return Ok(relationType);
    }


}

