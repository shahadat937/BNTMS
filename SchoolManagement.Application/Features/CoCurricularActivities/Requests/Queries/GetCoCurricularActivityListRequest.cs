using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CoCurricularActivity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CoCurricularActivities.Requests.Queries
{
    public class GetCoCurricularActivityListRequest : IRequest<PagedResult<CoCurricularActivityDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
