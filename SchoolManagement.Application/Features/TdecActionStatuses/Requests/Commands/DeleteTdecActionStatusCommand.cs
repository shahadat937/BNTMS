using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecActionStatuses.Requests.Commands
{
    public class DeleteTdecActionStatusCommand : IRequest
    {
        public int TdecActionStatusId { get; set; }
    }
}
