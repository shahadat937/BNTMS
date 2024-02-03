using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaInstructorType;
using SchoolManagement.Application.Features.BnaInstructorTypees.Requests.Queries;
using SchoolManagement.Application.Features.BnaInstructorTypes.Requests.Commands;
using SchoolManagement.Application.Features.BnaInstructorTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaInstructorType)]
[ApiController]
[Authorize]
public class BnaInstructorTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaInstructorTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaInstructorTypes")]
    public async Task<ActionResult<List<BnaInstructorTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaInstructorTypes = await _mediator.Send(new GetBnaInstructorTypeListRequest { QueryParams = queryParams });
        return Ok(BnaInstructorTypes);
    }

    [HttpGet]
    [Route("get-bnaInstructorTypeDetail/{id}")]
    public async Task<ActionResult<BnaInstructorTypeDto>> Get(int id)
    {
        var BnaInstructorTypes = await _mediator.Send(new GetBnaInstructorTypeDetailRequest { BnaInstructorTypeId = id });
        return Ok(BnaInstructorTypes);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaInstructorType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaInstructorTypeDto BnaInstructorType)
    {
        var command = new CreateBnaInstructorTypeCommand { BnaInstructorTypeDto = BnaInstructorType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaInstructorType/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaInstructorTypeDto BnaInstructorType)
    {
        var command = new UpdateBnaInstructorTypeCommand { BnaInstructorTypeDto = BnaInstructorType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaInstructorType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaInstructorTypeCommand { BnaInstructorTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get  

    [HttpGet]
    [Route("get-selectedBnaInstructorTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBnainstructortype()
    {
        var Bnainstructortype = await _mediator.Send(new GetSelectedBnaInstructorTypeRequest { });
        return Ok(Bnainstructortype);
    }
}

