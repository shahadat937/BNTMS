using MediatR;
using SchoolManagement.Application.DTOs.ResultStatus;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ResultStatuses.Requests.Commands
{
    public class CreateResultStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateResultStatusDto ResultStatusDto { get; set; }
    }
}
