using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeLanguages.Requests.Commands
{
    public class DeleteTraineeLanguageCommand : IRequest  
    {  
        public int Id { get; set; }
    }
}
