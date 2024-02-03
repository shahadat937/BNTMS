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
    public class GetClassRoutineListRequest : IRequest<PagedResult<ClassRoutineDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
