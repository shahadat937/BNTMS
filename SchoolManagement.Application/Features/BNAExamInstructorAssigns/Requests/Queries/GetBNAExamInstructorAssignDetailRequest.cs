using MediatR;
using SchoolManagement.Application.DTOs.BnaExamInstructorAssign;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaExamInstructorAssigns.Requests.Queries
{
    public class GetBnaExamInstructorAssignDetailRequest : IRequest<BnaExamInstructorAssignDto>
    {
        public int BnaExamInstructorAssignId { get; set; }
    }
}
  