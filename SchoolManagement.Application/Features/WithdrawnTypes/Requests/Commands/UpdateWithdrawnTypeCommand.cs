using MediatR;
using SchoolManagement.Application.DTOs.WithdrawnType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.WithdrawnTypes.Requests.Commands
{
    public class UpdateWithdrawnTypeCommand : IRequest<Unit>
    {
        public WithdrawnTypeDto WithdrawnTypeDto { get; set; }
    }
}
 