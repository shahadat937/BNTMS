using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CoCurricularActivityType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CoCurricularActivityTypes.Requests.Queries
{
    public class GetCoCurricularActivityTypeDetailRequest : IRequest<CoCurricularActivityTypeDto>
    {
        public int CoCurricularActivityTypeId { get; set; }
    }
}
