using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Elections.Requests.Commands
{
    public class DeleteElectionCommand : IRequest
    {
        public int ElectionId { get; set; }
    }
}
