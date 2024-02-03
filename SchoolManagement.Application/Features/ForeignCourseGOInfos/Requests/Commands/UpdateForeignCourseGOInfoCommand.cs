using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseGOInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseGOInfos.Requests.Commands
{
    public class UpdateForeignCourseGOInfoCommand : IRequest<Unit>
    {
        public CreateForeignCourseGOInfoDto CreateForeignCourseGOInfoDto { get; set; }
    }
}
