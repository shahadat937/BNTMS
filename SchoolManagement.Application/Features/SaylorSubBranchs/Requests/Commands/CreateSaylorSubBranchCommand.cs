using MediatR;
using SchoolManagement.Application.DTOs.SaylorSubBranch;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SaylorSubBranchs.Requests.Commands
{
    public class CreateSaylorSubBranchCommand : IRequest<BaseCommandResponse>
    {
        public CreateSaylorSubBranchDto SaylorSubBranchDto { get; set; }
    }
}
