﻿using SchoolManagement.Application.DTOs.Attendance;
using SchoolManagement.Application.Responses;
using MediatR;
using SchoolManagement.Application.DTOs.Attendance.ApprovedAttendance;
using SchoolManagement.Application.DTOs.TraineeNomination;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Commands
{
    public class UpdateTraineeNominationListForReligationCommand : IRequest<BaseCommandResponse>
    {
        public TraineeNominationListForReligation TraineeNominationList { get; set; }
    }
} 
    