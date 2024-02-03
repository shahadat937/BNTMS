using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Heights.Requests.Commands
{
    public class DeleteHeightsCommand : IRequest
    {  
        public int Id { get; set; }
    }
}
