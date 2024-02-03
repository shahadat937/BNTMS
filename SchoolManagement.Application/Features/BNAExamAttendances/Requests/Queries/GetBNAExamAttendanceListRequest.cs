using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BnaExamAttendance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BnaExamAttendances.Requests.Queries
{
    public class GetBnaExamAttendanceListRequest : IRequest<PagedResult<BnaExamAttendanceDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
} 
 