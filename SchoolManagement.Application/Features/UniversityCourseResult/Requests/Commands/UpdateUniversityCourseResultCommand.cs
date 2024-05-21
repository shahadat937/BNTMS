using SchoolManagement.Application.DTOs.UniversityCourseResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UniversityCourseResults.Requests.Commands
{
    public class UpdateUniversityCourseResultCommand : IRequest<Unit>
    {
        public UniversityCourseResultDto UniversityCourseResultDto { get; set; }

    }
}
