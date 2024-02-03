using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseOthersDocument;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Commands
{
    public class UpdateForeignCourseOthersDocumentCommand : IRequest<Unit>
    {
        public ForeignCourseOthersDocumentDto ForeignCourseOthersDocumentDto { get; set; }
    }
}
