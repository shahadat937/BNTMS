using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamPeriodTypes.Requests.Commands
{
    public class DeleteExamPeriodTypeCommand : IRequest
    {
        public int ExamPeriodTypeId { get; set; }
    }
} 
