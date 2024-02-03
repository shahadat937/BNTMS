using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Assessments.Requests.Commands
{
    public class DeleteAssessmentCommand : IRequest
    {
        public int AssessmentId { get; set; }
    }
}
