using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseOtherDoc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Queries
{
    public class GetForeignCourseOtherDocDetailRequest : IRequest<ForeignCourseOtherDocDto>
    {
        public int ForeignCourseOtherDocId { get; set; }
    }
}
