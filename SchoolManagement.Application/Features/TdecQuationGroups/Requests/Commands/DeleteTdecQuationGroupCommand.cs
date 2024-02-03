using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecQuationGroups.Requests.Commands
{
    public class DeleteTdecQuationGroupCommand : IRequest
    {
        public int TdecQuationGroupId { get; set; }
    }
}
