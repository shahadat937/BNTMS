using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.ClassRoutine;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetClassRoutineListByCourseDurationIdRequest : IRequest<PagedResult<ClassRoutineDto>>
    {
        public int CourseDurationId { get; set; }
        public QueryParams QueryParams { get; set; }
    }
}
 