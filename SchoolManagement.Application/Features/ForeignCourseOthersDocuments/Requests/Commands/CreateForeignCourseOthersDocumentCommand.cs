using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseOthersDocument;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Commands
{
    public class CreateForeignCourseOthersDocumentCommand : IRequest<BaseCommandResponse>
    {
        public CreateForeignCourseOthersDocumentDto ForeignCourseOthersDocumentDto { get; set; }
    }
}
