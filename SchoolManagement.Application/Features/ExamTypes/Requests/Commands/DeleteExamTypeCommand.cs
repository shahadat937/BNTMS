using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamTypes.Requests.Commands
{
    public class DeleteExamTypeCommand : IRequest
    {
        public int ExamTypeId { get; set; }
    }
}
