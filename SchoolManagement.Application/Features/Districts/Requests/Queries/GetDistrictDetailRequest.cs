using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.District;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Districts.Requests.Queries
{
    public class GetDistrictDetailRequest : IRequest<DistrictDto>
    {
        public int DistrictId { get; set; }
    }
}
