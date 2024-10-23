using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BudgetAllocation;
using SchoolManagement.Application.DTOs.BudgetTransaction;
using SchoolManagement.Application.Features.BudgetAllocations.Requests.Queries;
using SchoolManagement.Application.Features.BudgetTransactionType.Handler.Queries;
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
                BudgetCodeID = budgetCodeId
            });
            return Ok(BudgetTransaction);
        }
    }
    }
