using MediatR;
using SchoolManagement.Application.DTOs.SaylorSubBranch;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SaylorSubBranchs.Requests.Commands
{
    public class UpdateSaylorSubBranchCommand : IRequest<Unit>
    {
        public SaylorSubBranchDto SaylorSubBranchDto { get; set; }
    }
}
