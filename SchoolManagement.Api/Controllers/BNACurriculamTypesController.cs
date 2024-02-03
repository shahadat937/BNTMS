using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaCurriculamType;
using SchoolManagement.Application.Features.BnaCurriculamTypes.Requests.Commands;
using SchoolManagement.Application.Features.BnaCurriculamTypes.Requests.Queries;
using SchoolManagement.Application.Features.CurriculamTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.BnaCurriculamType)]
[ApiController]
[Authorize]
public class BnaCurriculamTypesController : ControllerBase
{
    private readonly IMediator _mediator;

    public BnaCurriculamTypesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-bnaCurriculamTypes")]
    public async Task<ActionResult<List<BnaCurriculamTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var BnaCurriculamTypes = await _mediator.Send(new GetBnaCurriculamTypeListRequest { QueryParams = queryParams });
        return Ok(BnaCurriculamTypes);
    }


    [HttpGet]
    [Route("get-bnaCurriculamTypeDetail/{id}")]
    public async Task<ActionResult<BnaCurriculamTypeDto>> Get(int id)
    {
        var BnaCurriculamType = await _mediator.Send(new GetBnaCurriculamTypeDetailRequest { BnaCurriculamTypeId = id });
        return Ok(BnaCurriculamType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-bnaCurriculamType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaCurriculamTypeDto BnaCurriculamType)
    {
        var command = new CreateBnaCurriculamTypeCommand { BnaCurriculamTypeDto = BnaCurriculamType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-bnaCurriculamType/{id}")]
    public async Task<ActionResult> Put([FromBody] BnaCurriculamTypeDto BnaCurriculamType)
    {
        var command = new UpdateBnaCurriculamTypeCommand { BnaCurriculamTypeDto = BnaCurriculamType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-bnaCurriculamType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteBnaCurriculamTypeCommand { BnaCurriculamTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedBnaCurriculamTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedBnaCurriculumType()
    {
        var selectedBnaBnaCurriculumType = await _mediator.Send(new GetSelectedBnaCurriculamTypeRequest { });
        return Ok(selectedBnaBnaCurriculumType);
    }
}

