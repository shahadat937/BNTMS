using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CoCurricularActivityType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CoCurricularActivityTypes.Requests.Queries
{
    public class GetCoCurricularActivityTypeListRequest : IRequest<PagedResult<CoCurricularActivityTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
