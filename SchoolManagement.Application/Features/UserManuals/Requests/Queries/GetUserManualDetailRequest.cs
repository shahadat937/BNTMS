using MediatR;
using SchoolManagement.Application.DTOs.UserManual;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UserManuals.Requests.Queries
{
    public class GetUserManualDetailRequest : IRequest<UserManualDto>
    {
        public int UserManualId { get; set; }
    }
}
