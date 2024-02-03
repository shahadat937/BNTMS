using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SaylorSubBranchs.Requests.Commands
{
    public class DeleteSaylorSubBranchCommand : IRequest
    {
        public int SaylorSubBranchId { get; set; }
    }
}
