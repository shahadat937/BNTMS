using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.Religion;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Religions.Requests.Queries
{
    public class GetReligionDetailRequest : IRequest<ReligionDto>
    {
        public int ReligionId { get; set; }
    }
}
