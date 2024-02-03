using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.DocumentTypes;
using SchoolManagement.Application.Features.DocumentTypes.Requests.Commands;
using SchoolManagement.Application.Features.DocumentTypes.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.DocumentTypes)]
[ApiController]
[Authorize]
public class DocumentTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public DocumentTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-documentTypes")]
    public async Task<ActionResult<List<DocumentTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var DocumentTypes = await _mediator.Send(new GetDocumentTypeListRequest { QueryParams = queryParams });
        return Ok(DocumentTypes);
    }



    [HttpGet]
    [Route("get-documentTypeDetail/{id}")]
    public async Task<ActionResult<DocumentTypeDto>> Get(int id)
    {
        var DocumentType = await _mediator.Send(new GetDocumentTypeDetailRequest { DocumentTypeId = id });
        return Ok(DocumentType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-documentType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateDocumentTypeDto DocumentType)
    {
        var command = new CreateDocumentTypeCommand { DocumentTypeDto = DocumentType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-documentType/{id}")]
    public async Task<ActionResult> Put([FromBody] DocumentTypeDto DocumentType)
    {
        var command = new UpdateDocumentTypeCommand { DocumentTypeDto = DocumentType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-documentType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDocumentTypeCommand { DocumentTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }
    // relational data

    [HttpGet]
    [Route("get-selectedDocumentTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDocumentType()
    {
        var DocumentTypeName = await _mediator.Send(new GetSelectedDocumentTypeRequest { });
        return Ok(DocumentTypeName);
    }
}


