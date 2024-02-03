using MediatR;
using SchoolManagement.Application.DTOs.NewAtempt;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NewAtempts.Requests.Commands
{
    public class CreateNewAtemptCommand : IRequest<BaseCommandResponse>
    {
        public CreateNewAtemptDto NewAtemptDto { get; set; }
    }
}
 