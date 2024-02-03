using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Allowances.Requests.Commands
{
    public class DeleteAllowanceCommand : IRequest
    {
        public int AllowanceId { get; set; }
    }
}
 