using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseGOInfos.Requests.Commands
{
    public class DeleteForeignCourseGOInfoCommand : IRequest
    {
        public int ForeignCourseGOInfoId { get; set; }
    }
}
