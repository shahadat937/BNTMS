using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.FailureStatus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FailureStatuses.Requests.Queries
{
    public class GetFailureStatusDetailRequest : IRequest<FailureStatusDto>
    {
        public int FailureStatusId { get; set; }
    }
}
