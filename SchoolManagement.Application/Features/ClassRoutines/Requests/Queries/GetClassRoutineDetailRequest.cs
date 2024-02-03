using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.ClassRoutine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetClassRoutineDetailRequest : IRequest<ClassRoutineDto>
    {
        public int ClassRoutineId { get; set; }
    }
}
