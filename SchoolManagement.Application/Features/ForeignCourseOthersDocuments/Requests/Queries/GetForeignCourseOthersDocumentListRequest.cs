using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.ForeignCourseOthersDocument;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Queries
{
   public class GetForeignCourseOthersDocumentListRequest : IRequest<PagedResult<ForeignCourseOthersDocumentDto>>
    {
        public QueryParams QueryParams { get; set; }
        public int CourseDurationId { get; set; }  
        public int TraineeId { get; set; }
    }
}
