using SchoolManagement.Application.DTOs.GrandFather;
using MediatR;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.GrandFathers.Requests.Queries
{
    public class GetGrandFatherListByTraineeRequest : IRequest<List<GrandFatherDto>>
    {
        public int Traineeid { get; set; }
    }
}
