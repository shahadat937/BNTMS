using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.FamilyNomination;
using SchoolManagement.Application.Features.FamilyNominations.Requests.Commands;
using SchoolManagement.Application.Features.FamilyNominations.Requests.Queries;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.FamilyNomination)]
[ApiController]
[Authorize]
public class FamilyNominationController : ControllerBase
{
    private readonly IMediator _mediator;

    public FamilyNominationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-familynomination")]
    public async Task<ActionResult<List<FamilyNominationDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var FamilyNomination = await _mediator.Send(new GetFamilyNominationListRequest { QueryParams = queryParams });
        return Ok(FamilyNomination);
    }

    [HttpGet]
    [Route("get-familynominationdetail/{id}")]
    public async Task<ActionResult<FamilyNominationDto>> Get(int id)
    {
        var FamilyNomination = await _mediator.Send(new GetFamilyNominationDetailRequest { Id = id });
        return Ok(FamilyNomination);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-familynomination")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateFamilyNominationDto FamilyNomination)
    {
        var command = new CreateFamilyNominationCommand { FamilyNominationDto = FamilyNomination };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-familyNominationList")]

    public async Task<ActionResult<BaseCommandResponse>> SaveFamilyNominationList([FromBody] FamilyNominationListDto familyNominationListDto)
    {
        var command = new CreateFamilyNominationListCommand { FamilyNominationListDto = familyNominationListDto };
        var response = await _mediator.Send(command);
        return Ok(response);
        //return Ok();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-familynomination/{id}")]
    public async Task<ActionResult> Put([FromBody] FamilyNominationDto FamilyNomination)
    {
        var command = new UpdateFamilyNominationCommand { FamilyNominationDto = FamilyNomination };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-familynomination/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteFamilyNominationCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }


   
}

