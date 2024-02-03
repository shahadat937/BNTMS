using SchoolManagement.Application.DTOs.MilitaryTraining;
using MediatR;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.MilitaryTrainings.Requests.Queries
{
    public class GetMilitaryTrainingListByTraineeRequest : IRequest<List<MilitaryTrainingDto>>
    {
        public int Traineeid { get; set; }
    } 
}
