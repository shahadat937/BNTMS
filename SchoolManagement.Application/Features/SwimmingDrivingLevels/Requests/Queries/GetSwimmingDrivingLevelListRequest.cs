using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.SwimmingDrivingLevel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.SwimmingDrivingLevels.Requests.Queries
{
    public class GetSwimmingDrivingLevelListRequest : IRequest<PagedResult<SwimmingDrivingLevelDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
