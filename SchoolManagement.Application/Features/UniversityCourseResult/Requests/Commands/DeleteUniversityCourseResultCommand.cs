using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UniversityCourseResults.Requests.Commands
{
    public class DeleteUniversityCourseResultCommand : IRequest
    {
        public int UniversityCourseResultId { get; set; }
    }
}
