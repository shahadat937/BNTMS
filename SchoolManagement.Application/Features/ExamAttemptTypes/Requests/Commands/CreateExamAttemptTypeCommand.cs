using MediatR;
using SchoolManagement.Application.DTOs.ExamAttemptType;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamAttemptTypes.Requests.Commands
{
    public class CreateExamAttemptTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateExamAttemptTypeDto ExamAttemptTypeDto { get; set; }
    }
}
 