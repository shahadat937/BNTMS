using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.InstallmentPaidDetail;
using SchoolManagement.Application.Features.InstallmentPaidDetails.Requests.Commands;
using SchoolManagement.Application.Features.InstallmentPaidDetails.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers;

[Route(SMSRoutePrefix.InstallmentPaidDetail)]
[ApiController]
[Authorize]
public class InstallmentPaidDetailController : ControllerBase
{
    private readonly IMediator _mediator;

    public InstallmentPaidDetailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-installmentpaiddetail")]
    public async Task<ActionResult<List<InstallmentPaidDetailDto>>> Get([FromQuery] QueryParams queryParams)
    {
        var InstallmentPaidDetail = await _mediator.Send(new GetInstallmentPaidDetailListRequest { QueryParams = queryParams });
        return Ok(InstallmentPaidDetail);
    }

    [HttpGet]
    [Route("get-installmentpaiddetaildetail/{id}")]
    public async Task<ActionResult<InstallmentPaidDetailDto>> Get(int id)
    {
        var InstallmentPaidDetail = await _mediator.Send(new GetInstallmentPaidDetailDetailRequest { Id = id });
        return Ok(InstallmentPaidDetail);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Route("save-installmentpaiddetail")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateInstallmentPaidDetailDto InstallmentPaidDetail)
    {
        var command = new CreateInstallmentPaidDetailCommand { InstallmentPaidDetailDto = InstallmentPaidDetail };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("update-installmentpaiddetail/{id}")]
    public async Task<ActionResult> Put([FromBody] InstallmentPaidDetailDto InstallmentPaidDetail)
    {
        var command = new UpdateInstallmentPaidDetailCommand { InstallmentPaidDetailDto = InstallmentPaidDetail };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("delete-installmentpaiddetail/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteInstallmentPaidDetailCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Route("change-installmentPaidDetailPaymentCompletedStatus")]
    public async Task<ActionResult> ActiveInstallmentPaidDetail(int installmentPaidDetailId, int paymentCompletedStatus)
    {
        var command = new ChangePaymentCompletedStatusCommand
        {
            InstallmentPaidDetailId = installmentPaidDetailId,
            PaymentCompletedStatus = paymentCompletedStatus
        };
        await _mediator.Send(command);
        return NoContent();
    }


}

