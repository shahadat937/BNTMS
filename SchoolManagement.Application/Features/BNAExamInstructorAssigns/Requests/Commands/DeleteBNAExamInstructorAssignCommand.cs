using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaExamInstructorAssigns.Requests.Commands
{
    public class DeleteBnaExamInstructorAssignCommand : IRequest
    {
        public int BnaExamInstructorAssignId { get; set; }
    }
}
 