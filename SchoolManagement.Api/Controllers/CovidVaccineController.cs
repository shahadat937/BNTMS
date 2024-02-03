using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CovidVaccine;
using SchoolManagement.Application.Features.CovidVaccines.Requests.Commands;
using SchoolManagement.Application.Features.CovidVaccines.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.CovidVaccine)]
[ApiController]
[Authorize]
public class CovidVaccineController : ControllerBase
{
    private readonly IMediator _mediator;

    public CovidVaccineController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-CovidVaccines")]
    public async Task<ActionResult<List<CovidVaccineDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var CovidVaccines = await _mediator.Send(new GetCovidVaccineListRequest { QueryParams = queryParams });
        return Ok(CovidVaccines);
    }


    [HttpGet]
    [Route("get-CovidVaccineDetail/{id}")]
    public async Task<ActionResult<CovidVaccineDto>> Get(int id)
    {
        var CovidVaccine = await _mediator.Send(new GetCovidVaccineDetailRequest { CovidVaccineId = id });
        return Ok(CovidVaccine);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-CovidVaccine")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCovidVaccineDto CovidVaccine)
    {
        var command = new CreateCovidVaccineCommand { CovidVaccineDto = CovidVaccine };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-CovidVaccine/{id}")]
    public async Task<ActionResult> Put([FromBody] CovidVaccineDto CovidVaccine)
    {
        var command = new UpdateCovidVaccineCommand { CovidVaccineDto = CovidVaccine };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-CovidVaccine/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteCovidVaccineCommand { CovidVaccineId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get   

    [HttpGet]
    [Route("get-selectedCovidVaccines")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedCovidVaccine()
    {
        var selectedCovidVaccine = await _mediator.Send(new GetSelectedCovidVaccineRequest { });
        return Ok(selectedCovidVaccine);
    }
    [HttpGet]
    [Route("get-CovidVaccineListByPno")]
    public async Task<ActionResult<List<CovidVaccineDto>>> GetCovidVaccineListByPno(int traineeId)
    {
        var CovidVaccines = await _mediator.Send(new GetCovidVaccineListByPnoRequest
        {
            TraineeId = traineeId
        });
        return Ok(CovidVaccines);
    }

    [HttpGet]
    [Route("get-CovidVaccineListByTraineeId")]
    public async Task<ActionResult<List<CovidVaccineDto>>> GetCovidVaccineListByTraineeId(int traineeId)
    {
        var CovidVaccines = await _mediator.Send(new GetCovidVaccineListTraineeIdRequest
        {
            TraineeId = traineeId
        });
        return Ok(CovidVaccines);
    }
}

