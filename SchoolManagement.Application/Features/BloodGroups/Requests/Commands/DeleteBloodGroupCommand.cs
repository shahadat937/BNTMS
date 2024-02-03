using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BloodGroups.Requests.Commands
{
    public class DeleteBloodGroupCommand : IRequest
    {
        public int BloodGroupId { get; set; }
    }
}
