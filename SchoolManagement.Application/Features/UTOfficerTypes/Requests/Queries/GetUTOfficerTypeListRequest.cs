using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.UtofficerType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.UtofficerTypes.Requests.Queries
{
    public class GetUtofficerTypeListRequest : IRequest<PagedResult<UtofficerTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
