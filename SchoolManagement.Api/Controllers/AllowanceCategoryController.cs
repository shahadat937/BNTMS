using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.AllowanceCategory;
using SchoolManagement.Application.Features.AllowanceCategorys.Requests.Commands;
using SchoolManagement.Application.Features.AllowanceCategorys.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.AllowanceCategory)]
[ApiController]
[Authorize]
public class AllowanceCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public AllowanceCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-AllowanceCategorys")]
    public async Task<ActionResult<List<AllowanceCategoryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var AllowanceCategorys = await _mediator.Send(new GetAllowanceCategoryListRequest { QueryParams = queryParams });
        return Ok(AllowanceCategorys);
    }


    [HttpGet]
    [Route("get-AllowanceCategoryDetail/{id}")]
    public async Task<ActionResult<AllowanceCategoryDto>> Get(int id)
    {
        var AllowanceCategory = await _mediator.Send(new GetAllowanceCategoryDetailRequest { AllowanceCategoryId = id });
        return Ok(AllowanceCategory);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-AllowanceCategory")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateAllowanceCategoryDto AllowanceCategory)
    {
        var command = new CreateAllowanceCategoryCommand { AllowanceCategoryDto = AllowanceCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-AllowanceCategory/{id}")]
    public async Task<ActionResult> Put([FromBody] AllowanceCategoryDto AllowanceCategory)
    {
        var command = new UpdateAllowanceCategoryCommand { AllowanceCategoryDto = AllowanceCategory };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-AllowanceCategory/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAllowanceCategoryCommand { AllowanceCategoryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedAllowanceCategorys")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAllowanceCategory()
    {
        var selectedAllowanceCategory = await _mediator.Send(new GetSelectedAllowanceCategoryRequest { });
        return Ok(selectedAllowanceCategory);
    }
    [HttpGet]
    [Route("get-AllowanceCategoryListByFromRankIdAndToRankId")]
    public async Task<ActionResult<List<AllowanceCategoryDto>>> GetAllowanceCategoryListByFromRankIdAndToRankId(int fromRankId, int toRankId)
    {
        var allowanceCategorys = await _mediator.Send(new GetAllowanceCategoryListByFromRankIdAndToRankIdRequest
        {
            FromRankId = fromRankId,
            ToRankId = toRankId
        });
        return Ok(allowanceCategorys);
    }

    [HttpGet]
    [Route("get-selectedAllowanceNameByFromRankIdAndToRankId")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedAllowanceNameByFromRankIdAndToRankId(int fromRankId, int toRankId)
    {
        var allowancNameValue = await _mediator.Send(new GetSelectedAllowanceNameByFromRankIdAndToRankIdRequest
        {
            FromRankId = fromRankId,
            ToRankId = toRankId,
        });
        return Ok(allowancNameValue);
    }
}

