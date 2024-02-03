using MediatR;
using SchoolManagement.Application.DTOs.TdecActionStatus;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecActionStatuses.Requests.Commands
{
    public class CreateTdecActionStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateTdecActionStatusDto TdecActionStatusDto { get; set; }
    }
}
