using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.MilitaryTrainings.Requests.Commands
{
    public class DeleteMilitaryTrainingCommand : IRequest  
    {  
        public int Id { get; set; }
    }
}
