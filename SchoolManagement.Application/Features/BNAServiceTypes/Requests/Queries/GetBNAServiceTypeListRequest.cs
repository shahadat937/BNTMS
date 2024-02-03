using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BnaServiceType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BnaServiceTypes.Requests.Queries
{
    public class GetBnaServiceTypeListRequest : IRequest<PagedResult<BnaServiceTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 