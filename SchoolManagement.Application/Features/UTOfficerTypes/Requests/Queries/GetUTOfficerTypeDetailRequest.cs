using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.UtofficerType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.UtofficerTypes.Requests.Queries
{
    public class GetUtofficerTypeDetailRequest : IRequest<UtofficerTypeDto>
    {
        public int UtofficerTypeId { get; set; }
    }
}
