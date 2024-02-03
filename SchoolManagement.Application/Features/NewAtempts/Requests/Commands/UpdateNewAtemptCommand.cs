using MediatR;
using SchoolManagement.Application.DTOs.NewAtempt;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NewAtempts.Requests.Commands
{
    public class UpdateNewAtemptCommand : IRequest<Unit>
    {
        public NewAtemptDto NewAtemptDto { get; set; }
    }
}
 