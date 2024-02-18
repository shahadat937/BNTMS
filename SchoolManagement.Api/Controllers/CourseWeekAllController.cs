using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseWeekAll;
using SchoolManagement.Application.Features.CourseWeekAll.Requests.Queries;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Queries;

namespace SchoolManagement.Api.Controllers
{
    [Route(SMSRoutePrefix.CourseWeekAll)]
    [ApiController]
     //[Authorize]
    public class CourseWeekAllController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CourseWeekAllController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[HttpGet]
        //[Route("get-course-week-all")]
        //public async Task<ActionResult<List<CourseWeekAllDto>>> Get([FromQuery] QueryParams queryParams)
        //{

        //    var CourseWeeks = await _mediator.Send(new GetCourseWeekAllListRequest { QueryParams = queryParams });
        //    return Ok(CourseWeeks);


        //}


        [HttpGet]
        [Route("get-courseWeeks")]
        public async Task<ActionResult> Get([FromQuery] QueryParams queryParams, int baseSchoolNameId=0)
        {
            var CourseWeeks = await _mediator.Send(new GetCourseWeekAllListRequest { QueryParams = queryParams, BaseSchoolNameId = baseSchoolNameId });
            return Ok(CourseWeeks);
        }

        [HttpGet]
        [Route("get-course-week-all")]

        public async Task<ActionResult> GetCourseWeekAll(int baseSchoolNameId)
        {
            var dataForPrintWeeklyRoutine = await _mediator.Send(new GetCourseWeekAllListRequest
            {
                BaseSchoolNameId = baseSchoolNameId
            });
            return Ok(dataForPrintWeeklyRoutine);
        }
    }
}
