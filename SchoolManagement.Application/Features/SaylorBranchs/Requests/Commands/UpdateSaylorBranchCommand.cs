using MediatR;
using SchoolManagement.Application.DTOs.SaylorBranch;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SaylorBranchs.Requests.Commands
{
    public class UpdateSaylorBranchCommand : IRequest<Unit>
    {
        public SaylorBranchDto SaylorBranchDto { get; set; }
    }
}
