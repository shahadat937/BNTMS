using MediatR;
using SchoolManagement.Application.DTOs.Assessment;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Assessments.Requests.Queries
{
    public class GetAssessmentDetailRequest : IRequest<AssessmentDto>
    {
        public int AssessmentId { get; set; }
    }
}
