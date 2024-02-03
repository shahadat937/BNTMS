using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceCourseDocTypes.Requests.Commands
{
    public class DeleteInterServiceCourseDocTypeCommand : IRequest
    {
        public int InterServiceCourseDocTypeId { get; set; }
    }
}
