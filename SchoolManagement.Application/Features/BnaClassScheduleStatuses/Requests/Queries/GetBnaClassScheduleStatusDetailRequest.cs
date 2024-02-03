using MediatR;
using SchoolManagement.Application.DTOs.BnaClassScheduleStatuses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaClassScheduleStatuss.Requests.Queries
{
    public class GetBnaClassScheduleStatusDetailRequest : IRequest<BnaClassScheduleStatusDto>
    {
        public int BnaClassScheduleStatusId { get; set; }
    }
}
   