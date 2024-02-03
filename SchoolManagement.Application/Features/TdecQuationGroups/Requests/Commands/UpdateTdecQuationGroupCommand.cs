using MediatR;
using SchoolManagement.Application.DTOs.TdecQuationGroup;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecQuationGroups.Requests.Commands
{
    public class UpdateTdecQuationGroupCommand : IRequest<Unit>
    {
        public TdecQuationGroupDto TdecQuationGroupDto { get; set; }
    }
}
