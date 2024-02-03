using SchoolManagement.Application.DTOs.District;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Districts.Requests.Commands
{
    public class UpdateDistrictCommand : IRequest<Unit>
    {
        public DistrictDto DistrictDto { get; set; }

    }
}
