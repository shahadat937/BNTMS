using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.PaymentDetail;
using SchoolManagement.Application.Features.PaymentDetails.Requests.Commands;
using SchoolManagement.Application.Features.PaymentDetails.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.PaymentDetail)]
[ApiController]
[Authorize]
public class PaymentDetailController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentDetailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-paymentdetails")]
    public async Task<ActionResult<List<PaymentDetailDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var PaymentDetail = await _mediator.Send(new GetPaymentDetailListRequest { QueryParams = queryParams });
        return Ok(PaymentDetail);
    }

    [HttpGet]
    [Route("get-paymentdetailsdetail/{id}")]
    public async Task<ActionResult<PaymentDetailDto>> Get(int id)
    {
        var PaymentDetail = await _mediator.Send(new GetPaymentDetailDetailRequest { Id = id });
        return Ok(PaymentDetail);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-paymentdetail")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreatePaymentDetailDto PaymentDetail)
    {
        var command = new CreatePaymentDetailCommand { PaymentDetailDto = PaymentDetail };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-paymentdetail/{id}")]
    public async Task<ActionResult> Put([FromBody] PaymentDetailDto PaymentDetail)
    {
        var command = new UpdatePaymentDetailCommand { PaymentDetailDto = PaymentDetail };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-paymentdetail/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeletePaymentDetailCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [Route("get-selectedpaymentdetails")]
    public async Task<ActionResult<List<SelectedModel>>> GetSelectedPaymentDetail()
    {
        var Weight = await _mediator.Send(new GetSelectedPaymentDetailRequest { });
        return Ok(Weight);
    }
}

