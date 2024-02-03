using MediatR;
using SchoolManagement.Application.DTOs.InterServiceCourseDocType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceCourseDocTypes.Requests.Queries
{
    public class GetInterServiceCourseDocTypeDetailRequest : IRequest<InterServiceCourseDocTypeDto>
    {
        public int InterServiceCourseDocTypeId { get; set; }
    }
}
