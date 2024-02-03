using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Weights.Requests.Commands
{
    public class DeleteWeightCommand : IRequest 
    {  
        public int Id { get; set; }
    }
}
