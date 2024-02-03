using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Branchs.Requests.Commands
{
    public class CreateBranchCommand : IRequest<BaseCommandResponse>
    {
        public CreateBranchDto BranchDto { get; set; } 

    }
}
