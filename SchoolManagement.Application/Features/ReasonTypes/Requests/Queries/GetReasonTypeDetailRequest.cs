using MediatR;
using SchoolManagement.Application.DTOs.ReasonType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ReasonTypes.Requests.Queries
{
    public class GetReasonTypeDetailRequest : IRequest<ReasonTypeDto>
    {
        public int ReasonTypeId { get; set; }
    }
}
