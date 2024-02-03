using MediatR;
using SchoolManagement.Application.DTOs.TdecActionStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TdecActionStatuses.Requests.Queries
{
    public class GetTdecActionStatusDetailRequest : IRequest<TdecActionStatusDto>
    {
        public int TdecActionStatusId { get; set; }
    }
}
