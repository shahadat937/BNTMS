using MediatR;
using SchoolManagement.Application.DTOs.ResultStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ResultStatuses.Requests.Queries
{
    public class GetResultStatusDetailRequest : IRequest<ResultStatusDto>
    {
        public int ResultStatusId { get; set; }
    }
}
