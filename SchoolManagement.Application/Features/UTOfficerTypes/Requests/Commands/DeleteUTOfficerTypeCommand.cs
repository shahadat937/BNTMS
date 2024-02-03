using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UtofficerTypes.Requests.Commands
{
    public class DeleteUtofficerTypeCommand : IRequest
    {
        public int UtofficerTypeId { get; set; }
    }
}
