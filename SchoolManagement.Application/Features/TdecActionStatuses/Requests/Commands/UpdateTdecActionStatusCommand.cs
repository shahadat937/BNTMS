using MediatR;
using SchoolManagement.Application.DTOs.TdecActionStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecActionStatuses.Requests.Commands
{
    public class UpdateTdecActionStatusCommand : IRequest<Unit>
    {
        public TdecActionStatusDto TdecActionStatusDto { get; set; }
    }
}
