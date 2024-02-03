using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CoCurricularActivity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CoCurricularActivities.Requests.Queries
{
    public class GetCoCurricularActivityDetailRequest : IRequest<CoCurricularActivityDto>
    {
        public int CoCurricularActivityId { get; set; }
    }
}
