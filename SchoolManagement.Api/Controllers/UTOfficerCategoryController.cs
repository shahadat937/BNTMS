using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.UtofficerCategory;
using SchoolManagement.Application.Features.UtofficerCategorys.Requests.Commands;
using SchoolManagement.Application.Features.UtofficerCategorys.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.UtofficerCategory)]
[ApiController]
[Authorize]
public class UtofficerCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public UtofficerCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-utOfficerCategories")]
    public async Task<ActionResult<List<UtofficerCategoryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var UTOfficerCategories = await _mediator.Send(new GetUtofficerCategoryListRequest { QueryParams = queryParams });
        return Ok(UTOfficerCategories);
    }

    [HttpGet]
    [Route("get-utOfficerCategoryDetail/{id}")]
    public async Task<ActionResult<UtofficerCategoryDto>> Get(int id)
    {
        var UTOfficerCategories = await _mediator.Send(new GetUtofficerCategoryDetailRequest { UtofficerCategoryId = id });
        return Ok(UTOfficerCategories);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-utOfficerCategory")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateUtofficerCategoryDto UtofficerCategory)
    {
        var command = new CreateUtofficerCategoryCommand { UtofficerCategoryDto = UtofficerCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-utOfficerCategory/{id}")]
    public async Task<ActionResult> Put([FromBody] UtofficerCategoryDto UtofficerCategory)
    {
        var command = new UpdateUtofficerCategoryCommand { UtofficerCategoryDto = UtofficerCategory };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-utOfficerCategory/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteUtofficerCategoryCommand { UtofficerCategoryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedUtOfficerCategories")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedUtofficerCategory()
    {
        var UtofficerCategory = await _mediator.Send(new GetSelectedUtofficerCategoryRequest { });
        return Ok(UtofficerCategory);
    }

}
