using MediatR;
using SchoolManagement.Application.DTOs.ResultStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ResultStatuses.Requests.Commands
{
    public class UpdateResultStatusCommand : IRequest<Unit>
    {
        public ResultStatusDto ResultStatusDto { get; set; }
    }
}
