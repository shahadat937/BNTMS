using MediatR;
using SchoolManagement.Application.DTOs.ExamCenter;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamCenters.Requests.Commands
{
    public class CreateExamCenterCommand : IRequest<BaseCommandResponse>
    {
        public CreateExamCenterDto ExamCenterDto { get; set; }
    }
}
 