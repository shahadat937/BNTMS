using MediatR;
using SchoolManagement.Application.DTOs.BnaExamInstructorAssign;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaExamInstructorAssigns.Requests.Commands
{
    public class UpdateBnaExamInstructorAssignCommand : IRequest<Unit>
    {
        public BnaExamInstructorAssignDto BnaExamInstructorAssignDto { get; set; }
    }
}
 