using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application;
using SchoolManagement.Application.DTOs.BnaClassPeriod;
using SchoolManagement.Application.DTOs.ClassPeriod;
using SchoolManagement.Application.Features.BnaClassPeriods.Requests.Commands;
using SchoolManagement.Application.Features.BnaClassPeriods.Requests.Queries;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Commands;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Queries;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Api.Controllers
{
    [Route(SMSRoutePrefix.BnaClassPeriod)]
    [ApiController]
    //[Authorize]
    public class BnaClassPeriodController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BnaClassPeriodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("get-bnaClassPeriod")]
        public async Task<ActionResult<List<SelectedModel>>> GetBnaClassPeriod(int baseSchoolNameId)
        {
            var ClassPeriod = await _mediator.Send(new GetBnaClassPeriodRequest
            {
                BaseSchoolNameId = baseSchoolNameId
            });
            return Ok(ClassPeriod);
        }


        [HttpPost]
        [Route("save-bnaClassPeriod")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateBnaClassPeriodDto BnaClassPeriodDto)
        {
            var command = new CreateBnaClassPeriodCommand { BnaClassPeriodDto = BnaClassPeriodDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
