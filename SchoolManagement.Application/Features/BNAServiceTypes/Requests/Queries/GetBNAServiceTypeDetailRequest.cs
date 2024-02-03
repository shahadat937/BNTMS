using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BnaServiceType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaServiceTypes.Requests.Queries
{
    public class GetBnaServiceTypeDetailRequest : IRequest<BnaServiceTypeDto>
    {
        public int BnaServiceTypeId { get; set; }
    }
} 
