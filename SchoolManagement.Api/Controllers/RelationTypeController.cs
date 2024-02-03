using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.RelationType;
using SchoolManagement.Application.Features.RelationTypes.Requests.Commands;
using SchoolManagement.Application.Features.RelationTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.RelationType)]
[ApiController]
[Authorize]
public class RelationTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public RelationTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-relationTypes")]
    public async Task<ActionResult<List<RelationTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var RelationTypes = await _mediator.Send(new GetRelationTypeListRequest { QueryParams = queryParams });
        return Ok(RelationTypes);
    }

    [HttpGet]
    [Route("get-relationTypeDetail/{id}")]
    public async Task<ActionResult<RelationTypeDto>> Get(int id)
    {
        var RelationTypes = await _mediator.Send(new GetRelationTypeDetailRequest { RelationTypeId = id });
        return Ok(RelationTypes);
    }



    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-relationType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateRelationTypeDto RelationType)
    {
        var command = new CreateRelationTypeCommand { RelationTypeDto = RelationType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-relationType/{id}")]
    public async Task<ActionResult> Put([FromBody] RelationTypeDto RelationType)
    {
        var command = new UpdateRelationTypeCommand { RelationTypeDto = RelationType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-relationType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteRelationTypeCommand { RelationTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedrelationTypes")]
    public async Task<ActionResult<List<SelectedModel>>> getselectedrelationtype()
    {
        var relationType = await _mediator.Send(new GetSelectedRelationTypeRequest { });
        return Ok(relationType);
    }
}

