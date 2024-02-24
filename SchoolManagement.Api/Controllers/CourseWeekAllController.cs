using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.CourseWeekAll;
using SchoolManagement.Application.DTOs.CourseWeeks;
using SchoolManagement.Application.Features.CourseWeekAll.Requests.Commands;
using SchoolManagement.Application.Features.CourseWeekAll.Requests.Queries;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Commands;
using SchoolManagement.Shared.Models;
using System.Net.Sockets;



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
        public async Task<ActionResult> Get([FromQuery] QueryParams queryParams, int baseSchoolNameId)
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


        [HttpGet]
        [Route("get-dropdown-course-week-all")]
        public async Task<ActionResult<List<SelectedModel>>> GetDropdownCourseWeekAll(int baseSchoolNameId)
        {
            var allCourseWeek = await _mediator.Send(new GetDropdownCourseWeekAllListRequest { 
                BaseSchoolNameId = baseSchoolNameId
            });
            return Ok(allCourseWeek);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Route("save-courseWeekAll")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCourseWeekAllDto CourseWeekAll)
        {
            var command = new CreateCourseWeekAllCommand { CourseWeekAllDto= CourseWeekAll };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        //[Route("update-courseWeek/{id}")]
        //public async Task<ActionResult> Put([FromBody] Application.DTOs.CourseWeekAll.CourseWeekAllDto CourseWeek, [FromRoute] int id)
        //{
        //    var command = new UpdateCourseWeekAllCommand { CourseWeekAllDto = CourseWeek };
        //    await _mediator.Send(command);
        //    return NoContent();
        //}
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Route("update-courseWeek/{id}")]
        public async Task<ActionResult> Put([FromBody] Application.DTOs.CourseWeeks.CourseWeekAllDto CourseWeek)
        {
            var command = new UpdateCourseWeekCommand { CourseWeekDto = CourseWeek };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
