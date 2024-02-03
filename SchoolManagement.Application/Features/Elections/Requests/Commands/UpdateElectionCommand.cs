using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Election;

namespace SchoolManagement.Application.Features.Elections.Requests.Commands
{
    public class UpdateElectionCommand : IRequest<Unit>
    {
        public ElectionDto ElectionDto { get; set; } 

    }
}
