using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceMarks.Requests.Commands
{
    public class DeleteInterServiceMarkCommand : IRequest
    {
        public int InterServiceMarkId { get; set; }
    }
}
 