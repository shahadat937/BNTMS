using MediatR;
using SchoolManagement.Application.DTOs.BnaExamInstructorAssign;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaExamInstructorAssigns.Requests.Queries
{
   public class GetBnaExamInstructorAssignListRequest : IRequest<PagedResult<BnaExamInstructorAssignDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
} 
