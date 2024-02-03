using SchoolManagement.Application.DTOs.SwimmingDrivingLevel;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SwimmingDrivingLevels.Requests.Commands
{
    public class CreateSwimmingDrivingLevelCommand : IRequest<BaseCommandResponse>
    {
        public CreateSwimmingDrivingLevelDto SwimmingDrivingLevelDto { get; set; }

    }
}
