using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseOtherDoc;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Commands
{
    public class CreateForeignCourseOtherDocCommand : IRequest<BaseCommandResponse>
    {
        public CreateForeignCourseOtherDocDto ForeignCourseOtherDocDto { get; set; }
    }
}
