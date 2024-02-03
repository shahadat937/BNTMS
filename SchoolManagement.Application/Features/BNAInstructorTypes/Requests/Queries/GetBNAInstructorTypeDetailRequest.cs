using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BnaInstructorType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaInstructorTypes.Requests.Queries
{
    public class GetBnaInstructorTypeDetailRequest : IRequest<BnaInstructorTypeDto>
    {
        public int BnaInstructorTypeId { get; set; }
    }
}
