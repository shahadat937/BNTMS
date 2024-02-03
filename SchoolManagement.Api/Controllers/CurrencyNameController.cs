using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CurrencyName;
using SchoolManagement.Application.Features.CurrencyNames.Requests.Commands;
using SchoolManagement.Application.Features.CurrencyNames.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CurrencyName)]
[ApiController]
[Authorize]
public class CurrencyNameController : ControllerBase
{
    private readonly IMediator _mediator;

    public CurrencyNameController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-CurrencyNames")]
    public async Task<ActionResult<List<CurrencyNameDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CurrencyNames = await _mediator.Send(new GetCurrencyNameListRequest { QueryParams = queryParams });
        return Ok(CurrencyNames);
    }


    [HttpGet]
    [Route("get-CurrencyNameDetail/{id}")]
    public async Task<ActionResult<CurrencyNameDto>> Get(int id)
    {
        var CurrencyName = await _mediator.Send(new GetCurrencyNameDetailRequest { CurrencyNameId = id });
        return Ok(CurrencyName);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-CurrencyName")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCurrencyNameDto CurrencyName)
    {
        var command = new CreateCurrencyNameCommand { CurrencyNameDto = CurrencyName };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-CurrencyName/{id}")]
    public async Task<ActionResult> Put([FromBody] CurrencyNameDto CurrencyName)
    {
        var command = new UpdateCurrencyNameCommand { CurrencyNameDto = CurrencyName };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-CurrencyName/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCurrencyNameCommand { CurrencyNameId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedCurrencyNames")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCurrencyName()
    {
        var selectedCurrencyName = await _mediator.Send(new GetSelectedCurrencyNameRequest { });
        return Ok(selectedCurrencyName);
    }
    [HttpGet]
    [Route("get-selectedCurrencyByCountry")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCurrencyByCountry(int countryId)
    {
        var currencyByCountry= await _mediator.Send(new GetCurrencyByCountryIdRequest { CountryId = countryId });
        return Ok(currencyByCountry);
    }
}

