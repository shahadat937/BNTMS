using MediatR;
using SchoolManagement.Application.DTOs.ExamAttemptType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamAttemptTypes.Requests.Commands
{
    public class UpdateExamAttemptTypeCommand : IRequest<Unit>
    {
        public ExamAttemptTypeDto ExamAttemptTypeDto { get; set; }
    }
}
 