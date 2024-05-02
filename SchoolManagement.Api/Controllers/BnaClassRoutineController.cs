using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaClassRoutines;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.Features.BnaClassRoutine.Requests.Commands;
using SchoolManagement.Application.Features.BnaClassRoutine.Requests.Queries;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Commands;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;

namespace SchoolManagement.Api.Controllers
{
    [Route(SMSRoutePrefix.BnaClassRoutine)]
    [ApiController]
    [Authorize]
    public class BnaClassRoutineController : ControllerBase
    {

        private readonly IMediator _mediator;

        public BnaClassRoutineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-bnaClassRoutineAll")]
        public async Task<ActionResult> GetBnaClassRoutine(string bnaSelectedSubjectCurriculumId, string selectedCourseNameId, string selectedCourseDurationId, string selectedBnaSemesterId, string selectedCourseSectionId, int selectedCourseWeekId)
        {
            var BnaClassRoutine = await _mediator.Send(new GetNewBnaClassRoutineListRequest
            {
                bnaSelectedSubjectCurriculumId = bnaSelectedSubjectCurriculumId,
                selectedCourseNameId = selectedCourseNameId,
                selectedCourseDurationId = selectedCourseDurationId,
                selectedBnaSemesterId = selectedBnaSemesterId,
                selectedCourseSectionId = selectedCourseSectionId,
                selectedCourseWeekId = selectedCourseWeekId
            });
            return Ok(BnaClassRoutine);
        }

        [HttpGet]
        [Route("get-bnaInstructorInfo")]
        public async Task<ActionResult> GetBnaInstructorInfo(string bnaSelectedSubjectCurriculumId, string selectedCourseNameId, string selectedCourseDurationId, string selectedBnaSemesterId, string selectedCourseSectionId, int selectedCourseWeekId)
        {
            var BnaClassRoutine = await _mediator.Send(new GetBnaInstructorInfoRequest
            {
                bnaSelectedSubjectCurriculumId = bnaSelectedSubjectCurriculumId,
                selectedCourseNameId = selectedCourseNameId,
                selectedCourseDurationId = selectedCourseDurationId,
                selectedBnaSemesterId = selectedBnaSemesterId,
                selectedCourseSectionId = selectedCourseSectionId,
                selectedCourseWeekId = selectedCourseWeekId
            });
            return Ok(BnaClassRoutine);
        }

        [HttpPost]
        [Route("save-bnaclassRoutine")]
        public async Task<ActionResult<BaseCommandResponse>> SaveBnaClassRoutine(BnaClassRoutineListDto ClassRoutine)
        {
            var command = new CreateBnaClassRoutineCommand { BnaClassRoutineDto = ClassRoutine };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
