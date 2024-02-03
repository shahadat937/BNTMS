using MediatR;
using SchoolManagement.Application.DTOs.ClassType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassTypes.Requests.Commands
{
    public class UpdateClassTypeCommand : IRequest<Unit>
    {
        public ClassTypeDto ClassTypeDto { get; set; }
    }
}
