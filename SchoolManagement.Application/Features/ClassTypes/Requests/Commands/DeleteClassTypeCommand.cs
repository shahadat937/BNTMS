using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassTypes.Requests.Commands
{
    public class DeleteClassTypeCommand : IRequest
    {
        public int ClassTypeId { get; set; }
    }
}
