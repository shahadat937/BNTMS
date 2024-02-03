using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseDocType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseDocTypes.Requests.Commands
{
    public class UpdateForeignCourseDocTypeCommand : IRequest<Unit>
    {
        public ForeignCourseDocTypeDto ForeignCourseDocTypeDto { get; set; }
    }
}
