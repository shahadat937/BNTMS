using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForceTypes.Requests.Commands
{
    public class DeleteForceTypeCommand : IRequest
    {
        public int ForceTypeId { get; set; }
    }
}
