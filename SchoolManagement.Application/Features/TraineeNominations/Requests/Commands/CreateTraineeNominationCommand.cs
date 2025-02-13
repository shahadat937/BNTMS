﻿using SchoolManagement.Application.DTOs.TraineeNomination;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Commands
{
    public class CreateTraineeNominationCommand : IRequest<BaseCommandResponse>
    {
        public CreateTraineeNominationDto TraineeNominationDto { get; set; }

    }
}
