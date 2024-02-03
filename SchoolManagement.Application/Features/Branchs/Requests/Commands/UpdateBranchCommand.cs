using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Branchs.Requests.Commands
{
    public class UpdateBranchCommand : IRequest<Unit>
    {
        public BranchDto BranchDto { get; set; } 
    }
}
