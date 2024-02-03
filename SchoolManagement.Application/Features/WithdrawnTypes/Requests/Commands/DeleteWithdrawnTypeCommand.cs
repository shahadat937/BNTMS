using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.WithdrawnTypes.Requests.Commands
{
    public class DeleteWithdrawnTypeCommand : IRequest
    {
        public int WithdrawnTypeId { get; set; }
    }
}
 