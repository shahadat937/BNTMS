using SchoolManagement.Application.DTOs.GameSport;
using MediatR;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.GameSports.Requests.Queries
{
    public class GetGameSportListByTraineeRequest : IRequest<List<GameSportDto>>
    {
        public int Traineeid { get; set; }
    }
}
