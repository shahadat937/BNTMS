using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ExamAttemptTypes.Requests.Commands
{
    public class DeleteExamAttemptTypeCommand : IRequest
    {
        public int ExamAttemptTypeId { get; set; }
    }
}
 