using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseWeekAll;
using SchoolManagement.Application.DTOs.CourseWeeks;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Api.Controllers
{
    [Route(SMSRoutePrefix.CourseWeeks)]
    [ApiController]
    [Authorize]
    public class CourseWeekAllController : Controller
    {
        private readonly IMediator _mediator;
  
        public CourseWeekAllController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("get-courseWeekAll")]
        public async Task<ActionResult<List<courseWeekAllDto>>> Get( int baseSchoolNameId)
        {
            var CourseWeeks = await _mediator.Send(new GetCourseWeekListRequest { BaseSchoolNameId = baseSchoolNameId });
            return Ok(CourseWeeks);
        }
    }
}
