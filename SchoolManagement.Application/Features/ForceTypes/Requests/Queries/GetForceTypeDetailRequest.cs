using MediatR;
using SchoolManagement.Application.DTOs.ForceType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForceTypes.Requests.Queries
{
    public class GetForceTypeDetailRequest : IRequest<ForceTypeDto>
    {
        public int ForceTypeId { get; set; }
    }
}
