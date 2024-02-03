using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UserManuals.Requests.Commands
{
    public class DeleteUserManualCommand : IRequest
    {
        public int UserManualId { get; set; }
    }
}
