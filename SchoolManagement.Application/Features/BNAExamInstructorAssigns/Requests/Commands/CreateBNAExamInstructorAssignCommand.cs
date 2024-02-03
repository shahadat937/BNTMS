using MediatR;
using SchoolManagement.Application.DTOs.BnaExamInstructorAssign;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaExamInstructorAssigns.Requests.Commands
{
    public class CreateBnaExamInstructorAssignCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaExamInstructorAssignDto BnaExamInstructorAssignDto { get; set; }
    }
}
 