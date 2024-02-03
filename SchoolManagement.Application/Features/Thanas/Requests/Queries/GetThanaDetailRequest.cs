using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.Thana;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Thanas.Requests.Queries
{
    public class GetThanaDetailRequest : IRequest<ThanaDto>
    {
        public int ThanaId { get; set; }
    }
}
