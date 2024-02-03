using MediatR;
using SchoolManagement.Application.DTOs.CourseBudgetAllocation;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseBudgetAllocations.Requests.Commands
{
    public class CreateCourseBudgetAllocationCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseBudgetAllocationDto CourseBudgetAllocationDto { get; set; } 

    }
}
