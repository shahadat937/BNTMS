using SchoolManagement.Application.DTOs.UtofficerType;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UtofficerTypes.Requests.Commands
{
    public class CreateUtofficerTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateUtofficerTypeDto UtofficerTypeDto { get; set; }

    }
}
