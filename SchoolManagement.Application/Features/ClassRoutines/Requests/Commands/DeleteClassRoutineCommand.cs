using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Commands
{
    public class DeleteClassRoutineCommand : IRequest
    {
        public int ClassRoutineId { get; set; }
    }
}
