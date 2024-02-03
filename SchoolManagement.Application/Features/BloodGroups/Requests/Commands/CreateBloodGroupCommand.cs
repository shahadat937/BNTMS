using SchoolManagement.Application.DTOs.BloodGroup;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BloodGroups.Requests.Commands
{
    public class CreateBloodGroupCommand : IRequest<BaseCommandResponse>
    {
        public CreateBloodGroupDto BloodGroupDto { get; set; }

    }
}
