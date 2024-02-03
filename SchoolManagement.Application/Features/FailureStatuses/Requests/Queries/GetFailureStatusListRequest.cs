using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.FailureStatus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.FailureStatuses.Requests.Queries
{
    public class GetFailureStatusListRequest : IRequest<PagedResult<FailureStatusDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
