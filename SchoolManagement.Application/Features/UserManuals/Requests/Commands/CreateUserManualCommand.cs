using MediatR;
using SchoolManagement.Application.DTOs.UserManual;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UserManuals.Requests.Commands
{
    public class CreateUserManualCommand : IRequest<BaseCommandResponse>
    {
        public CreateUserManualDto UserManualDto { get; set; }
    }
}
