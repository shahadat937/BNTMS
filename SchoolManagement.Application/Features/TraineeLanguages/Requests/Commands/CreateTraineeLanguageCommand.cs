using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.TraineeLanguages;

namespace SchoolManagement.Application.Features.TraineeLanguages.Requests.Commands 
{
    public class CreateTraineeLanguageCommand : IRequest<BaseCommandResponse> 
    {
        public CreateTraineeLanguageDto TraineeLanguageDto { get; set; }      

    }
}
