using MediatR;
using SchoolManagement.Application.DTOs.ForeignCourseGOInfo;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseGOInfos.Requests.Commands
{
    public class CreateForeignCourseGOInfoCommand : IRequest<BaseCommandResponse>
    {
        public CreateForeignCourseGOInfoDto ForeignCourseGOInfoDto { get; set; }
    }
}
