using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseOtherDoc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Commands
{
    public class UpdateForeignCourseOtherDocCommand : IRequest<Unit>
    {
        public ForeignCourseOtherDocListDto ForeignCourseOtherDocListDto { get; set; }
    }
}
