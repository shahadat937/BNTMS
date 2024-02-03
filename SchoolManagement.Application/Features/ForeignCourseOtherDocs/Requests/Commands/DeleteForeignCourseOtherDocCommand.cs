using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Commands
{
    public class DeleteForeignCourseOtherDocCommand : IRequest
    {
        public int ForeignCourseOtherDocId { get; set; }
    }
}
