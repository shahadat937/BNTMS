using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BnaPromotionStatus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.BnaPromotionStatuses.Requests.Queries
{
    public class GetBnaPromotionStatusListRequest : IRequest<PagedResult<BnaPromotionStatusDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 