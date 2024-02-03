using MediatR;
using SchoolManagement.Application.DTOs.FamilyInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FamilyInfos.Requests.Queries
{
    public class GetFamilyInfoDetailRequest : IRequest<FamilyInfoDto>
    {
        public int FamilyInfoId { get; set; }
    }
}
 