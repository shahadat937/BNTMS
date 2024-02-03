using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaServiceTypes.Requests.Commands
{
    public class DeleteBnaServiceTypeCommand : IRequest
    {
        public int BnaServiceTypeId { get; set; }
    }
}
 