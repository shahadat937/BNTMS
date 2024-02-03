using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseDocType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseDocTypes.Requests.Queries
{
    public class GetForeignCourseDocTypeDetailRequest : IRequest<ForeignCourseDocTypeDto>
    {
        public int ForeignCourseDocTypeId { get; set; }
    }
}
