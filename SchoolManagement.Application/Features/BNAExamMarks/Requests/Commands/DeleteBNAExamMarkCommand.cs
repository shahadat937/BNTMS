using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Commands
{
    public class DeleteBnaExamMarkCommand : IRequest
    {
        public int BnaExamMarkId { get; set; }
    }
}
 