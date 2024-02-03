using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.Country;
using SchoolManagement.Application.Features.Countrys.Requests.Commands;
using SchoolManagement.Application.Features.Countrys.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.Country)]
[ApiController]
[Authorize]
public class CountryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CountryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-countries")]
    public async Task<ActionResult<List<CountryDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var Countrys = await _mediator.Send(new GetCountryListRequest { QueryParams = queryParams });
        return Ok(Countrys);
    }

    [HttpGet]
    [Route("get-countryDetail/{id}")]
    public async Task<ActionResult<CountryDto>> Get(int id)
    {
        var Country = await _mediator.Send(new GetCountryDetailRequest { CountryId = id });
        return Ok(Country);
    }

    

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-country")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCountryDto Country)
    {
        var command = new CreateCountryCommand { CountryDto = Country };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-country/{id}")]
    public async Task<ActionResult> Put([FromBody] CountryDto Country)
    {
        var command = new UpdateCountryCommand { CountryDto = Country };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-country/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCountryCommand { CountryId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedCountries")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCountry()
    {
        var selectedCountry = await _mediator.Send(new GetSelectedCountryRequest { });
        return Ok(selectedCountry);
    }

    [HttpGet]
    [Route("get-selectedCountryByCountryGroup")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCountryByCountryGroup(int countryGroupId)
    {
        var countryByCountryGroup = await _mediator.Send(new GetCountryByCountryGroupIdRequest { CountryGroupId = countryGroupId });
        return Ok(countryByCountryGroup);
    }
}

