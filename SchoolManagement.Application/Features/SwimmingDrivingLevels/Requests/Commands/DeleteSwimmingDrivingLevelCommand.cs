using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SwimmingDrivingLevels.Requests.Commands
{
    public class DeleteSwimmingDrivingLevelCommand : IRequest
    {
        public int SwimmingDrivingLevelId { get; set; }
    }
}
