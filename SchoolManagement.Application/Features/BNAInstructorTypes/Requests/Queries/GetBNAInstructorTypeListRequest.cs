using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BnaInstructorType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BnaInstructorTypes.Requests.Queries
{
    public class GetBnaInstructorTypeListRequest : IRequest<PagedResult<BnaInstructorTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
