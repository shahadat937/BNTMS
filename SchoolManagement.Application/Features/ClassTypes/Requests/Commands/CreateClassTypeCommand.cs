using MediatR;
using SchoolManagement.Application.DTOs.ClassType;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassTypes.Requests.Commands
{
    public class CreateClassTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateClassTypeDto ClassTypeDto { get; set; }
    }
}
