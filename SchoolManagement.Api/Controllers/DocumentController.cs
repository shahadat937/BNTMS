using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Document;
using SchoolManagement.Application.Features.Documents.Requests.Commands;
using SchoolManagement.Application.Features.Documents.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Document)]
[ApiController]
[Authorize]
public class DocumentController : ControllerBase
{
    private readonly IMediator _mediator;

    public DocumentController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    [Route("get-Documents")]
    public async Task<ActionResult<List<DocumentDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Documents = await _mediator.Send(new GetDocumentListRequest { QueryParams = queryParams });
        return Ok(Documents);
    }



    [HttpGet]
    [Route("get-DocumentDetail/{id}")]
    public async Task<ActionResult<DocumentDto>> Get(int id)
    {
        var Document = await _mediator.Send(new GetDocumentDetailRequest { DocumentId = id });
        return Ok(Document);
    }




    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-Document")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateDocumentDto Document)
    {
        var command = new CreateDocumentCommand { DocumentDto = Document };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-Document/{id}")]
    public async Task<ActionResult> Put([FromForm] CreateDocumentDto Document)
    {
        var command = new UpdateDocumentCommand { CreateDocumentDto = Document };
        await _mediator.Send(command);
        return NoContent();
    }


    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-Document/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteDocumentCommand { DocumentId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedDocument")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedDocument()
    {
        var Document = await _mediator.Send(new GetSelectedDocumentRequest { });
        return Ok(Document);
    }
}

