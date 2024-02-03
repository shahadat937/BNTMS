using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.ExamPeriodTypes;
using SchoolManagement.Application.Features.ExamPeriodTypes.Requests.Commands;
using SchoolManagement.Application.Features.ExamPeriodTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.ExamPeriodType)]
[ApiController]
[Authorize]
public class ExamPeriodTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExamPeriodTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-examPeriodTypes")]
    public async Task<ActionResult<List<ExamPeriodTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var ExamPeriodTypes = await _mediator.Send(new GetExamPeriodTypeListRequest { QueryParams = queryParams });
        return Ok(ExamPeriodTypes);
    }


    [HttpGet]
    [Route("get-examPeriodTypeDetail/{id}")]
    public async Task<ActionResult<ExamPeriodTypeDto>> Get(int id)
    {
        var ExamPeriodType = await _mediator.Send(new GetExamPeriodTypeDetailRequest { ExamPeriodTypeId = id });
        return Ok(ExamPeriodType);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-examPeriodType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateExamPeriodTypeDto ExamPeriodType)
    {
        var command = new CreateExamPeriodTypeCommand { ExamPeriodTypeDto = ExamPeriodType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-examPeriodType/{id}")]
    public async Task<ActionResult> Put([FromBody] ExamPeriodTypeDto ExamPeriodType)
    {
        var command = new UpdateExamPeriodTypeCommand { ExamPeriodTypeDto = ExamPeriodType };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-examPeriodType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteExamPeriodTypeCommand { ExamPeriodTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedExamPeriodType ")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedExamPeriodType()
    {
        var ExamPeriodTypeName = await _mediator.Send(new GetSelectedExamPeriodTypeRequest { });
        return Ok(ExamPeriodTypeName);
    }
}


