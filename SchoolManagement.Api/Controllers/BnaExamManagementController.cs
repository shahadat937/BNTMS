using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application;
using SchoolManagement.Application.Features.BnaClassRoutine.Requests.Queries;
using SchoolManagement.Application.Features.BnaExamManagements.Requests.Queries;

namespace SchoolManagement.Api.Controllers
{
    [Route(SMSRoutePrefix.BnaExamManagement)]
    [ApiController]
    public class BnaExamManagementController : ControllerBase
    {

        private readonly IMediator _mediator;

        public BnaExamManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-bnaSelectedCourseSectionsByBaseSchoolNameIdAndCourseNameId")]
        public async Task<ActionResult> GetCourseSection(int baseSchoolNameId, int courseNameId)
        {
            var courseSection = await _mediator.Send(new GetSelectedSectionBnaExamManagementRequest
            {
                BaseSchoolNameId = baseSchoolNameId,
                CourseNameId = courseNameId
            });
            return Ok(courseSection);
        }
    }
}
