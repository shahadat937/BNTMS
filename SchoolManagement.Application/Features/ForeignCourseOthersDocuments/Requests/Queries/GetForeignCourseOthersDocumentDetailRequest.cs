using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseOthersDocument;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Queries
{
    public class GetForeignCourseOthersDocumentDetailRequest : IRequest<ForeignCourseOthersDocumentDto>
    {
        public int ForeignCourseOthersDocumentId { get; set; }
    }
}
