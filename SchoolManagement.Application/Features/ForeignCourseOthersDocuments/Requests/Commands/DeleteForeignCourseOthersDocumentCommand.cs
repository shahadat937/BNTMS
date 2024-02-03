using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseOthersDocuments.Requests.Commands
{
    public class DeleteForeignCourseOthersDocumentCommand : IRequest
    {
        public int ForeignCourseOthersDocumentId { get; set; }
    }
}
