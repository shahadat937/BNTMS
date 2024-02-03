using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ReasonTypes.Requests.Commands
{
    public class DeleteReasonTypeCommand : IRequest
    {
        public int ReasonTypeId { get; set; }
    }
}
