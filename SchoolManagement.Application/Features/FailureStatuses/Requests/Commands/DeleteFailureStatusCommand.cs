using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FailureStatuses.Requests.Commands
{
    public class DeleteFailureStatusCommand : IRequest
    {
        public int FailureStatusId { get; set; }
    }
}
