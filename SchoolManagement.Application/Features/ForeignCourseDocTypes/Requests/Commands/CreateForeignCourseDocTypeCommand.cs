using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseDocType;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseDocTypes.Requests.Commands
{
    public class CreateForeignCourseDocTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateForeignCourseDocTypeDto ForeignCourseDocTypeDto { get; set; }
    }
}
