using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.MigrationDocument;
using SchoolManagement.Application.Features.MigrationDocuments.Requests.Commands;
using SchoolManagement.Application.Features.MigrationDocuments.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;
 
[Route(SMSRoutePrefix.MigrationDocument)]
[ApiController]
[Authorize]
public class MigrationDocumentController : ControllerBase
{
    private readonly IMediator _mediator;

    public MigrationDocumentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-migrationdocuments")]
    public async Task<ActionResult<List<MigrationDocumentDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var MigrationDocuments = await _mediator.Send(new GetMigrationDocumentListRequest { QueryParams = queryParams });
        return Ok(MigrationDocuments);
    }


    [HttpGet]
    [Route("get-migrationdocumentdetail/{id}")]
    public async Task<ActionResult<MigrationDocumentDto>> Get(int id)
    {
        var MigrationDocument = await _mediator.Send(new GetMigrationDocumentDetailRequest { Id = id });
        return Ok(MigrationDocument);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-migrationdocument")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMigrationDocumentDto MigrationDocument)
    {
        var command = new CreateMigrationDocumentCommand { MigrationDocumentDto = MigrationDocument };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-migrationdocument/{id}")]
    public async Task<ActionResult> Put([FromBody] MigrationDocumentDto MigrationDocument)
    {
        var command = new UpdateMigrationDocumentCommand { MigrationDocumentDto = MigrationDocument };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-migrationdocument/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteMigrationDocumentCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    
}

