using SchoolManagement.Application.DTOs.ClassRoutine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Commands
{
    public class UpdateClassRoutineCommand : IRequest<Unit>
    {
        public CreateClassRoutineDto ClassRoutineDto { get; set; }

    }
}
