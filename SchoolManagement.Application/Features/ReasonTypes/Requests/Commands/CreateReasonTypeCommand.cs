using MediatR;
using SchoolManagement.Application.DTOs.ReasonType;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ReasonTypes.Requests.Commands
{
    public class CreateReasonTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateReasonTypeDto ReasonTypeDto { get; set; }
    }
}
