using MediatR;
using SchoolManagement.Application.DTOs.InterServiceMark;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.InterServiceMarks.Requests.Queries
{
    public class GetInterServiceMarkDetailRequest : IRequest<InterServiceMarkDto>
    {
        public int InterServiceMarkId { get; set; }
    }
}
 