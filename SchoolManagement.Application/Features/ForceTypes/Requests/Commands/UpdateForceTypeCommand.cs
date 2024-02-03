using MediatR;
using SchoolManagement.Application.DTOs.ForceType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForceTypes.Requests.Commands
{
    public class UpdateForceTypeCommand : IRequest<Unit>
    {
        public ForceTypeDto ForceTypeDto { get; set; }
    }
}
