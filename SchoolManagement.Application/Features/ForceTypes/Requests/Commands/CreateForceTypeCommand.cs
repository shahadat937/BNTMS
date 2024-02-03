using MediatR;
using SchoolManagement.Application.DTOs.ForceType;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForceTypes.Requests.Commands
{
    public class CreateForceTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateForceTypeDto ForceTypeDto { get; set; }
    }
}
