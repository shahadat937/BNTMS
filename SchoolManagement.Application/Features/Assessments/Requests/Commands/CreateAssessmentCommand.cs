using MediatR;
using SchoolManagement.Application.DTOs.Assessment;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Assessments.Requests.Commands
{
    public class CreateAssessmentCommand : IRequest<BaseCommandResponse>
    {
        public CreateAssessmentDto AssessmentDto { get; set; }
    }
}
