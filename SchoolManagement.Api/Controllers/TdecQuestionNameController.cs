using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.TdecQuestionName;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.TdecQuestionNames.Requests.Commands;
using SchoolManagement.Application.Features.TdecQuestionNames.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.TdecQuestionName)]
[ApiController]
[Authorize]
public class TdecQuestionNameController : ControllerBase
{
    private readonly IMediator _mediator;

    public TdecQuestionNameController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-tdecQuestionNames")]
    public async Task<ActionResult<List<TdecQuestionNameDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var TdecQuestionNames = await _mediator.Send(new GetTdecQuestionNameListRequest { QueryParams = queryParams });
        return Ok(TdecQuestionNames);
    }

    [HttpGet]
    [Route("get-tdecQuestionNameFilteredList")]
    public async Task<ActionResult<List<TdecQuestionNameDto>>> GetTdecList([FromQuery] QueryParams queryParams,int baseSchoolNameId)
    {
        var TdecQuestionNames = await _mediator.Send(new GetTdecQuestionNameFilterdListRequest
        { 
            QueryParams = queryParams,
            BaseSchoolNameId =baseSchoolNameId
        });
        return Ok(TdecQuestionNames);
    }


    [HttpGet]
    [Route("get-tdecQuestionNameDetail/{id}")]
    public async Task<ActionResult<TdecQuestionNameDto>> Get(int id)
    {
        var TdecQuestionName = await _mediator.Send(new GetTdecQuestionNameDetailRequest { TdecQuestionNameId = id });
        return Ok(TdecQuestionName);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-tdecQuestionName")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateTdecQuestionNameDto TdecQuestionName)
    {
        var command = new CreateTdecQuestionNameCommand { TdecQuestionNameDto = TdecQuestionName };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-tdecQuestionName/{id}")]
    public async Task<ActionResult> Put([FromBody] TdecQuestionNameDto TdecQuestionName)
    {
        var command = new UpdateTdecQuestionNameCommand { TdecQuestionNameDto = TdecQuestionName };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-tdecQuestionName/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteTdecQuestionNameCommand { TdecQuestionNameId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedTdecQuestionName")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedTdecQuestionName()
    {
        var TdecQuestionName = await _mediator.Send(new GetSelectedTdecQuestionNameRequest { });
        return Ok(TdecQuestionName);
    }
     
    [HttpGet]
    [Route("get-tdecQuestionNameList")]
    public async Task<ActionResult<List<TdecQuestionNameDto>>> GetTdecQuestionNameList(int baseSchoolNameId)
    {
        var TdecQuestionName = await _mediator.Send(new GetTdecListRequest 
        { 
          BaseSchoolNameId = baseSchoolNameId
        });
        return Ok(TdecQuestionName);
    }
}

