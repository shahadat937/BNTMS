using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SaylorBranchs.Requests.Commands
{
    public class DeleteSaylorBranchCommand : IRequest
    {
        public int SaylorBranchId { get; set; }
    }
}
