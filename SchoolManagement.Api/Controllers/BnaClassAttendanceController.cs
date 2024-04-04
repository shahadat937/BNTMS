using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application;
using SchoolManagement.Application.Features.BnaClassAttendance.Request.Queries;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers
{
    [Route(SMSRoutePrefix.BnaClassAttendanceNew)]
    [ApiController]
    public class BnaClassAttendanceController : ControllerBase
    {

        private readonly IMediator _mediator;

        public BnaClassAttendanceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-BnaClassAttendance")]
        public async Task<ActionResult<List<SelectedModel>>> GetBnaClassAttendanceTrainee(int baseSchoolNameId, int bnaSubjectCurriculamId, int courseTitleId, int semesterId, int courseSectionId, int classPeriodId, string date)
        {
            var ClassAttendanceTrainee = await _mediator.Send(new GetBnaAttendanceQueryListRequest
            {
                BaseSchoolNameId = baseSchoolNameId,
                BnaSubjectCurriculamId = bnaSubjectCurriculamId,
                CourseTitleId = courseTitleId,
                SemesterId = semesterId,
                CourseSectionId = courseSectionId,
                ClassPeriodId = classPeriodId,
                Date = date
            });
            return Ok(ClassAttendanceTrainee);
        }
    }
}
