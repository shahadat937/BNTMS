using MediatR;
using SchoolManagement.Application.DTOs.ExamPeriodTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamPeriodTypes.Requests.Commands
{
    public class UpdateExamPeriodTypeCommand : IRequest<Unit>
    {
        public ExamPeriodTypeDto ExamPeriodTypeDto { get; set; }
    }
} 
