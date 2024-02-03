using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.MilitaryTraining;
using SchoolManagement.Application.DTOs.Height;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.MilitaryTrainings.Requests.Queries
{
    public class GetMilitaryTrainingDetailRequest : IRequest<MilitaryTrainingDto> 
    {
        public int Id { get; set; } 
    }
}
