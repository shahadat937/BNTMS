using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseDocTypes.Requests.Commands
{
    public class DeleteForeignCourseDocTypeCommand : IRequest
    {
        public int ForeignCourseDocTypeId { get; set; }
    }
}
