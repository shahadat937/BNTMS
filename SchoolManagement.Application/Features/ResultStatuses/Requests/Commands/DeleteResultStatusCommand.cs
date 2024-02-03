using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ResultStatuses.Requests.Commands
{
    public class DeleteResultStatusCommand : IRequest
    {
        public int ResultStatusId { get; set; }
    }
}
