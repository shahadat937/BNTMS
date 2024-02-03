using SchoolManagement.Application.DTOs.FailureStatus;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FailureStatuses.Requests.Commands
{
    public class CreateFailureStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateFailureStatusDto FailureStatusDto { get; set; }

    }
}
