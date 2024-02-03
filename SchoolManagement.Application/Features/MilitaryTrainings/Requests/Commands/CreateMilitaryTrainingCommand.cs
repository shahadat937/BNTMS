using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.MilitaryTraining;

namespace SchoolManagement.Application.Features.MilitaryTrainings.Requests.Commands 
{
    public class CreateMilitaryTrainingCommand : IRequest<BaseCommandResponse> 
    {
        public CreateMilitaryTrainingDto MilitaryTrainingDto { get; set; }      

    }
}
