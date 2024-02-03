using MediatR;
using SchoolManagement.Application.DTOs.ExamType;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamTypes.Requests.Commands
{
    public class CreateExamTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateExamTypeDto ExamTypeDto { get; set; }
    }
}
