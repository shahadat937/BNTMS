using SchoolManagement.Application.DTOs.BloodGroup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BloodGroups.Requests.Commands
{
    public class UpdateBloodGroupCommand : IRequest<Unit>
    {
        public BloodGroupDto BloodGroupDto { get; set; }

    }
}
