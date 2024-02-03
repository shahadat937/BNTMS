using MediatR;
using SchoolManagement.Application.DTOs.Assessment;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Assessments.Requests.Commands
{
    public class UpdateAssessmentCommand : IRequest<Unit>
    {
        public AssessmentDto AssessmentDto { get; set; }
    }
}
