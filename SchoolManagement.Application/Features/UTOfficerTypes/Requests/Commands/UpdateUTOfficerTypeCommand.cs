using SchoolManagement.Application.DTOs.UtofficerType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UtofficerTypes.Requests.Commands
{
    public class UpdateUtofficerTypeCommand : IRequest<Unit>
    {
        public UtofficerTypeDto UtofficerTypeDto { get; set; }

    }
}
