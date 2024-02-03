using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.SwimmingDrivingLevel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SwimmingDrivingLevels.Requests.Queries
{
    public class GetSwimmingDrivingLevelDetailRequest : IRequest<SwimmingDrivingLevelDto>
    {
        public int SwimmingDrivingLevelId { get; set; }
    }
}
