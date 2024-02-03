using SchoolManagement.Application.DTOs.TraineeAssissmentGroup;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeAssissmentGroups.Requests.Commands
{
    public class CreateTraineeAssissmentGroupCommand : IRequest<BaseCommandResponse>
    {
        public CreateTraineeAssissmentGroupDto TraineeAssissmentGroupDto { get; set; }

    }
}
