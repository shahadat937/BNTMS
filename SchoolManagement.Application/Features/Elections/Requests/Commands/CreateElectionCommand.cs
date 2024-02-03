using SchoolManagement.Application.DTOs.Election;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Elections.Requests.Commands
{
    public class CreateElectionCommand : IRequest<BaseCommandResponse>
    {
        public CreateElectionDto ElectionDto { get; set; }

    }
}
