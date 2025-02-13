﻿using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries
{
    public class GetTraineeBioDataGeneralInfoListForMidRequest : IRequest<PagedResult<TraineeBioDataGeneralInfoDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
