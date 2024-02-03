using SchoolManagement.Application.DTOs.CoCurricularActivity;
using MediatR;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.CoCurricularActivities.Requests.Queries
{
    public class GetCoCurricularActivityListByTraineeRequest : IRequest<List<CoCurricularActivityDto>>
    {
        public int Traineeid { get; set; }
    }
}
