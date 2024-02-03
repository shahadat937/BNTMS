using MediatR;
using SchoolManagement.Application.DTOs.InterServiceCourseDocType;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceCourseDocTypes.Requests.Commands
{
    public class CreateInterServiceCourseDocTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateInterServiceCourseDocTypeDto InterServiceCourseDocTypeDto { get; set; }
    }
}
