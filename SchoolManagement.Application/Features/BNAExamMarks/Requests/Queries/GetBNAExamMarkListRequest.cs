using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BnaExamMark;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries
{
    public class GetBnaExamMarkListRequest : IRequest<PagedResult<BnaExamMarkDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 