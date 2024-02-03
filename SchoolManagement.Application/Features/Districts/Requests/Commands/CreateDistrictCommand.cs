using SchoolManagement.Application.DTOs.District;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Districts.Requests.Commands
{
    public class CreateDistrictCommand : IRequest<BaseCommandResponse>
    {
        public CreateDistrictDto DistrictDto { get; set; }

    }
}
