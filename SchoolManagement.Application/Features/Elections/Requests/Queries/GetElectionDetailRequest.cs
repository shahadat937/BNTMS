using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.Election;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Elections.Requests.Queries
{
    public class GetElectionDetailRequest : IRequest<ElectionDto>
    {
        public int ElectionId { get; set; }
    }
}
