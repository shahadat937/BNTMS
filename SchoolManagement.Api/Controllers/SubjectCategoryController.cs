using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.SubjectCategorys;
using SchoolManagement.Application.Features.SubjectCategorys.Requests.Commands;
using SchoolManagement.Application.Features.SubjectCategorys.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.SubjectCategory)]
[ApiController]
[Authorize]
public class SubjectCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubjectCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-subjectCategories")]
    public async Task<ActionResult<List<SubjectCategoryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var SubjectCategorys = await _mediator.Send(new GetSubjectCategoryListRequest { QueryParams = queryParams });
        return Ok(SubjectCategorys);
    }

    [HttpGet]
    [Route("get-subjectCategoryDetail/{id}")]
    public async Task<ActionResult<SubjectCategoryDto>> Get(int id)
    {
        var SubjectCategory = await _mediator.Send(new GetSubjectCategoryDetailRequest { SubjectCategoryId = id });
        return Ok(SubjectCategory);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-subjectCategory")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSubjectCategoryDto SubjectCategory)
    {
        var command = new CreateSubjectCategoryCommand { SubjectCategoryDto = SubjectCategory };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-subjectCategory/{id}")]
    public async Task<ActionResult> Put([FromBody] SubjectCategoryDto SubjectCategory)
    {
        var command = new UpdateSubjectCategoryCommand { SubjectCategoryDto = SubjectCategory };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-subjectCategory/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteSubjectCategoryCommand { SubjectCategoryId = id };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpGet]
    [Route("get-selectedSubjectCategories")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedSubjectCategory()
    {
        var subjectCategory = await _mediator.Send(new GetSelectedSubjectCategoryRequest { });
        return Ok(subjectCategory);
    }
}
