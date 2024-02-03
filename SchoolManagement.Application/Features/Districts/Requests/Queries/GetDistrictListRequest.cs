using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.District;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Districts.Requests.Queries
{
    public class GetDistrictListRequest : IRequest<PagedResult<DistrictDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
