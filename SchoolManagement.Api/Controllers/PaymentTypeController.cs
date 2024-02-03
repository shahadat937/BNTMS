using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.PaymentType;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.PaymentTypes.Requests.Commands;
using SchoolManagement.Application.Features.PaymentTypes.Requests.Queries;
using SchoolManagement.Shared.Models;


namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.PaymentType)]
[ApiController]
[Authorize]
public class PaymentTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-paymentTypes")]
    public async Task<ActionResult<List<PaymentTypeDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var PaymentTypes = await _mediator.Send(new GetPaymentTypeListRequest { QueryParams = queryParams });
        return Ok(PaymentTypes);
    }

    

    [HttpGet]
    [Route("get-paymentTypeDetail/{id}")]
    public async Task<ActionResult<PaymentTypeDto>> Get(int id)
    {
        var PaymentType = await _mediator.Send(new GetPaymentTypeDetailRequest { PaymentTypeId = id });
        return Ok(PaymentType);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-paymentType")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreatePaymentTypeDto PaymentType)
    {
        var command = new CreatePaymentTypeCommand { PaymentTypeDto = PaymentType };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-paymentType/{id}")]
    public async Task<ActionResult> Put([FromBody] PaymentTypeDto PaymentType)
    {
        var command = new UpdatePaymentTypeCommand { PaymentTypeDto = PaymentType };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-paymentType/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeletePaymentTypeCommand { PaymentTypeId = id };
        await _mediator.Send(command);
        return NoContent();
    }

    // relational data get 

    [HttpGet]
    [Route("get-selectedPaymentTypes")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedPaymentType()
    {
        var PaymentType = await _mediator.Send(new GetSelectedPaymentTypeRequest { });
        return Ok(PaymentType);
    }
     
    [HttpGet]
    [Route("get-selectedPaymentTypeByParameterRequestFromClassRoutine")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedPaymentType(int baseSchoolNameId, int courseNameId)
    {
        var ClassPeriodName = await _mediator.Send(new GetSelectedPaymentTypeByParametersFromClassRoutineRequest
        {
            BaseSchoolNameId = baseSchoolNameId,
            CourseNameId = courseNameId
        });
        return Ok(ClassPeriodName);
    }
}

