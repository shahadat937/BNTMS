using MediatR;
using SchoolManagement.Application.DTOs.ClassPeriod;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassPeriods.Requests.Queries
{
   public class GetClassPeriodListRequest : IRequest<PagedResult<ClassPeriodDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 