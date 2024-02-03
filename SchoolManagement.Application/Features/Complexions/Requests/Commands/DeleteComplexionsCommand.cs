using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Complexions.Requests.Commands
{
    public class DeleteComplexionsCommand : IRequest
    { 
        public int Id { get; set; }
    }
}
