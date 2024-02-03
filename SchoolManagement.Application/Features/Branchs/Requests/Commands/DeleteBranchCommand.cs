using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Branchs.Requests.Commands
{
    public class DeleteBranchCommand : IRequest
    {
        public int Id { get; set; }
    }
}
