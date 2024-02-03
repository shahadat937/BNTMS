using MediatR;
using SchoolManagement.Application.DTOs.ExamType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamTypes.Requests.Commands
{
    public class UpdateExamTypeCommand : IRequest<Unit>
    {
        public ExamTypeDto ExamTypeDto { get; set; }
    }
}
