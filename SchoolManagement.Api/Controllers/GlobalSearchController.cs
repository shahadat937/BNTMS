using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.GlobalSearch;
using SchoolManagement.Application.Features.GlobalSearch.Requests.Queries;

namespace SchoolManagement.Api.Controllers
{
    [Route(SMSRoutePrefix.GlobalSearch)]
    [ApiController]
    public class GlobalSearchController: Controller
    {
        private readonly IMediator _mediator;

        public GlobalSearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("searchAll")]
        public async Task<ActionResult> searchAll([FromQuery] QueryDto query)
        {
            var command = new SearchQueryRequest { Query = query };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
