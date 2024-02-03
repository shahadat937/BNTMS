using MediatR;
using SchoolManagement.Application.DTOs.TdecQuationGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecQuationGroups.Requests.Queries
{
    public class GetTdecQuationGroupDetailRequest : IRequest<TdecQuationGroupDto>
    {
        public int TdecQuationGroupId { get; set; }
    }
}
