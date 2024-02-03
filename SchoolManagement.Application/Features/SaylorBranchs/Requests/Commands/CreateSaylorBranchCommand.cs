using MediatR;
using SchoolManagement.Application.DTOs.SaylorBranch;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SaylorBranchs.Requests.Commands
{
    public class CreateSaylorBranchCommand : IRequest<BaseCommandResponse>
    {
        public CreateSaylorBranchDto SaylorBranchDto { get; set; }
    }
}
