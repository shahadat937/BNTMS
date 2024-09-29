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

        [HttpGet]
        [Route("get-searchedTraineeDetail/{traineeId}")]
        public async Task<ActionResult> GetSearchedTraineeDetail(int traineeId)
        {
            var command = new GetSearchedTraineeDetailRequest { TraineeId = traineeId };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("get-searchedInstructorDetail/{instructorId}")]
        public async Task<ActionResult> GetSearchedInstructorDetail(int instructorId)
        {
            var command = new GetSearchedInstructorDetailRequest { instructorId = instructorId };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Route("get-searchedCourseDetail/{courseDurationId}")]
        public async Task<ActionResult> GetSearchedCourseDeatail(int courseDurationId)
        {
            var command = new GetSearchedCourseDetailRequest { CourseDurationId = courseDurationId };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
