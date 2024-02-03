using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeAssissmentGroups.Requests.Commands
{
    public class DeleteTraineeAssissmentGroupCommand : IRequest
    {
        public int TraineeAssissmentGroupId { get; set; }
    }
}
