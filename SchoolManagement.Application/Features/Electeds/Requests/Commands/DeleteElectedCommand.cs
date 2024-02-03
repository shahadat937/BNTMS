using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Electeds.Requests.Commands
{
    public class DeleteElectedCommand : IRequest  
    {  
        public int Id { get; set; }
    }
}
