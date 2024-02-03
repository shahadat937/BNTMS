using MediatR;
using SchoolManagement.Application.DTOs.CourseDurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseDurationDetailRequest : IRequest<CourseDurationDto> 
    {
        public int CourseDurationId { get; set; }
    }
}
