using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BloodGroup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BloodGroups.Requests.Queries
{
    public class GetBloodGroupDetailRequest : IRequest<BloodGroupDto>
    {
        public int BloodGroupId { get; set; }
    }
}
