using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.Religion;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Religions.Requests.Queries
{
    public class GetReligionListRequest : IRequest<PagedResult<ReligionDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
