using SchoolManagement.Application.DTOs.UniversityCourseResult;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UniversityCourseResults.Requests.Commands
{
    public class CreateUniversityCourseResultCommand : IRequest<BaseCommandResponse>
    {
        public CreateUniversityCourseResultDto UniversityCourseResultDto { get; set; }

    }
}
