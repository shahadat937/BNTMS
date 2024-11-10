using MediatR;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Commands
{
    public class DeleteMultipleTraineeNominationCommand : IRequest<BaseCommandResponse>
    {
        public List<int> TraineeIds { get; set; }
    }
}
