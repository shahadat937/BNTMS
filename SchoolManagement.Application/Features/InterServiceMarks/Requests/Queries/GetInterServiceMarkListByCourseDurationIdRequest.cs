using MediatR;
using SchoolManagement.Application.DTOs.InterServiceMark;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceMarks.Requests.Queries
{
    public class GetInterServiceMarkListByCourseDurationIdRequest : IRequest<object>
    {
        public int CourseDurationId { get; set; }
    }
}

