using MediatR;
using SchoolManagement.Application.DTOs.ExamCenter;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamCenters.Requests.Commands
{
    public class UpdateExamCenterCommand : IRequest<Unit>
    {
        public ExamCenterDto ExamCenterDto { get; set; }
    }
}
 