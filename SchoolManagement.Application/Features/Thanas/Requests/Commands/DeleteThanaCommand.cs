using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Thanas.Requests.Commands
{
    public class DeleteThanaCommand : IRequest
    {
        public int ThanaId { get; set; }
    }
}
