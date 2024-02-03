using MediatR;
using SchoolManagement.Application.DTOs.ReasonType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ReasonTypes.Requests.Commands
{
    public class UpdateReasonTypeCommand : IRequest<Unit>
    {
        public ReasonTypeDto ReasonTypeDto { get; set; }
    }
}
