using SchoolManagement.Application.DTOs.FailureStatus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FailureStatuses.Requests.Commands
{
    public class UpdateFailureStatusCommand : IRequest<Unit>
    {
        public FailureStatusDto FailureStatusDto { get; set; }

    }
}
