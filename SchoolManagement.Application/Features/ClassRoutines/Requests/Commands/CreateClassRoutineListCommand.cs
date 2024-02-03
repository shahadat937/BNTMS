using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Commands
{
    public class CreateClassRoutineListCommand : IRequest<BaseCommandResponse>
    {
        public ClassRoutineListDto ClassRoutineDto { get; set; }

    }
}
