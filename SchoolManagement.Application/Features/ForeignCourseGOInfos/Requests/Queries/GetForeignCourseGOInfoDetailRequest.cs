using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseGOInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseGOInfos.Requests.Queries
{
    public class GetForeignCourseGOInfoDetailRequest : IRequest<ForeignCourseGOInfoDto>
    {
        public int ForeignCourseGOInfoId { get; set; }
    }
}
