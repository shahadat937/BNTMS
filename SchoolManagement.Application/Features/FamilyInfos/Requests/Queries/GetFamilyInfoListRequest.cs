using MediatR;
using SchoolManagement.Application.DTOs.FamilyInfo;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FamilyInfos.Requests.Queries
{
   public class GetFamilyInfoListRequest : IRequest<PagedResult<FamilyInfoDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
 