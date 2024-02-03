using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BnaPromotionStatus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaPromotionStatuses.Requests.Queries
{
    public class GetBnaPromotionStatusDetailRequest : IRequest<BnaPromotionStatusDto>
    {
        public int BnaPromotionStatusId { get; set; }
    }
}
 