using MediatR;
using SchoolManagement.Application.DTOs.WithdrawnType;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.WithdrawnTypes.Requests.Queries
{
    public class GetWithdrawnTypeDetailRequest : IRequest<WithdrawnTypeDto>
    {
        public int WithdrawnTypeId { get; set; }
    }
}
 