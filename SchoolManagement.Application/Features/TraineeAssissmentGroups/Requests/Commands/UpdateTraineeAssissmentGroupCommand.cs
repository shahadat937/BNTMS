using SchoolManagement.Application.DTOs.TraineeAssissmentGroup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeAssissmentGroups.Requests.Commands
{
    public class UpdateTraineeAssissmentGroupCommand : IRequest<Unit>
    {
        public TraineeAssissmentGroupDto TraineeAssissmentGroupDto { get; set; }

    }
}
