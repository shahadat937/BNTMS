using SchoolManagement.Application.DTOs.TraineeLanguages;
using MediatR;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.TraineeLanguages.Requests.Queries
{
    public class GetTraineeLanguageListByTraineeRequest : IRequest<List<TraineeLanguageDto>>
    {
        public int Traineeid { get; set; }
    } 
}
