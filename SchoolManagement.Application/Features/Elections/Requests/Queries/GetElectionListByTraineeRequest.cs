using SchoolManagement.Application.DTOs.Election;
using MediatR;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.Elections.Requests.Queries
{
    public class GetElectionListByTraineeRequest : IRequest<List<ElectionDto>>
    {
        public int Traineeid { get; set; }
    }
}
