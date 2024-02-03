using MediatR;
using SchoolManagement.Application.DTOs.InterServiceCourseDocType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceCourseDocTypes.Requests.Commands
{
    public class UpdateInterServiceCourseDocTypeCommand : IRequest<Unit>
    {
        public InterServiceCourseDocTypeDto InterServiceCourseDocTypeDto { get; set; }
    }
}
