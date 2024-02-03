using SchoolManagement.Application.DTOs.SwimmingDrivingLevel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SwimmingDrivingLevels.Requests.Commands
{
    public class UpdateSwimmingDrivingLevelCommand : IRequest<Unit>
    {
        public SwimmingDrivingLevelDto SwimmingDrivingLevelDto { get; set; }

    }
}
