using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NewAtempts.Requests.Commands
{
    public class DeleteNewAtemptCommand : IRequest
    {
        public int NewAtemptId { get; set; }
    }
}
 