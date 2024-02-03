using MediatR;
using SchoolManagement.Application.DTOs.WithdrawnType;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.WithdrawnTypes.Requests.Commands
{
    public class CreateWithdrawnTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateWithdrawnTypeDto WithdrawnTypeDto { get; set; }
    }
}
 