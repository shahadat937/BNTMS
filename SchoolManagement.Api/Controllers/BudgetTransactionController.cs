using SchoolManagement.Api.Models;
using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BudgetAllocation;
using SchoolManagement.Application.DTOs.BudgetTransaction;
using SchoolManagement.Application.Features.BudgetAllocations.Handler.Commands;
using SchoolManagement.Application.Features.BudgetAllocations.Requests.Queries;
using SchoolManagement.Application.Features.BudgetTransactionType.Handler.Command;
using SchoolManagement.Application.Features.BudgetTransactionType.Request.Command;

//using SchoolManagement.Application.Features.BudgetTransactionType.Handler.Queries;
using SchoolManagement.Application.Features.BudgetTransactionType.Request.Queries;

namespace SchoolManagement.Api.Controllers
{
    [Route(SMSRoutePrefix.BudgetTransaction)]
    [ApiController]
    [Authorize]
    public class BudgetTransactionController : ControllerBase
    {
        private IMediator _mediator;

        public BudgetTransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("get-BudgetTransaction")]
        public async Task<ActionResult<List<BudgetTransactionDto>>> Get([FromQuery] QueryParams queryParams, int budgetCodeId, int budgetTypeId)
        {
            var BudgetTransaction = await _mediator.Send(new GetBudgetTransactionListRequest
            {
                QueryParams = queryParams,
                BudgetTypeId = budgetTypeId,
                BudgetCodeId = budgetCodeId
            });

            return Ok(BudgetTransaction);
        }

        [HttpGet]
        [Route("get-BudgetTransactionDetail/{id}")]
        public async Task<ActionResult<BudgetTransactionDto>> Get(int id)
        {
            var BudgetTransaction = await _mediator.Send(new GetBudgetTransactionDetailRequest { BudgetTransactionId = id });
            return Ok(BudgetTransaction);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Route("save-BudgetTransaction")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBudgetTransactionDto BudgetTransaction)
        {
            var command = new CreateBudgetTransactionCommandHandler { BudgetTransactionDto = BudgetTransaction };
            var response = await _mediator.Send(command);
            return Ok(response);

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Route("update-BudgetAllocation/{id}")]
        public async Task<ActionResult> Put([FromBody] BudgetTransactionDto BudgetTransaction)
        {
            var command = new UpdateBudgetTransactionCommand { BudgetTransactionDto = BudgetTransaction };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Route("delete-BudgetTransaction/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteBudgetTransactionCommand { BudgetTransactionId = id };
            await _mediator.Send(command);
            return NoContent();
        }



    }
    }
 